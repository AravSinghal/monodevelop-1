// 
// GlobalUserInformationPanelWidget.cs
// 
// Author:
//   Michael Hutchinson <mhutchinson@novell.com>
// 
// Copyright (C) 2009 Novell, Inc (http://www.novell.com)
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
using MonoDevelop.Core;
using MonoDevelop.Core.Gui.Dialogs;

namespace MonoDevelop.Ide.Gui.OptionPanels
{
	class GlobalUserInformationPanel : OptionsPanel
	{
		GlobalUserInformationPanelWidget widget;
		
		public override Gtk.Widget CreatePanelWidget ()
		{
			return widget = new GlobalUserInformationPanelWidget ();
		}

		public override void ApplyChanges ()
		{
			widget.Save ();
		}
	}
	
	partial class GlobalUserInformationPanelWidget : Gtk.Bin
	{
		
		public GlobalUserInformationPanelWidget()
		{
			this.Build ();
			
			nameEntry.Text = UserInformation.Default.Name ?? "";
			emailEntry.Text = UserInformation.Default.Email ?? "";
		}
		
		public void Save ()
		{
			PropertyService.Set ("User.Name", UserInformation.Default.Name);
			PropertyService.Set ("User.Email", UserInformation.Default.Email);
		}
	}
}
