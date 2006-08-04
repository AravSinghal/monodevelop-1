//
// Document.cs
//
// Author:
//   Lluis Sanchez Gual
//
// Copyright (C) 2006 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using MonoDevelop.Ide.Codons;
using MonoDevelop.Core;
using MonoDevelop.Core.Gui.Utils;

namespace MonoDevelop.Ide.Gui
{
	public class FileViewer
	{
		IDisplayBinding binding;
		DesktopApplication app;
		
		internal FileViewer (DesktopApplication app)
		{
			this.app = app;
		}
		
		internal FileViewer (IDisplayBinding binding)
		{
			this.binding = binding;
		}
		
		public string Title {
			get { return binding != null ? binding.DisplayName : app.DisplayName; }
		}
		
		public bool IsExternal {
			get { return binding == null; }
		}
		
		public override bool Equals (object ob)
		{
			FileViewer fv = ob as FileViewer;
			if (fv == null) return false;
			return binding == fv.binding || app.Command == fv.app.Command;
		}
		
		public override int GetHashCode ()
		{
			if (binding != null)
				return binding.GetHashCode ();
			else
				return app.Command.GetHashCode ();
		}
		
		public void OpenFile (string filePath)
		{
			if (binding != null)
				IdeApp.Workbench.OpenDocument (filePath, -1, -1, true, null, binding);
			else
				app.Launch (filePath);
		}
	}
}
