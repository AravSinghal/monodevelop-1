// 
// VersionControlView.cs
//  
// Author:
//       Mike Krüger <mkrueger@novell.com>
// 
// Copyright (c) 2010 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Linq;
using System.IO;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Components.Diff;
using System.Collections.Generic;

namespace MonoDevelop.VersionControl.Views
{
	internal class ComparisonView : BaseView, IAttachableViewContent 
	{
		ComparisonWidgetContainer widget;

		public override Gtk.Widget Control { 
			get {
				return widget;
			}
		}

		public static void AttachViewContents (Document document, VersionControlItem item)
		{
			IWorkbenchWindow window = document.Window;
			if (window.SubViewContents.Any (sub => sub is ComparisonView))
				return;
			window.AttachViewContent (new ComparisonView (document, item));
			window.AttachViewContent (new BlameView (document, item));
			window.AttachViewContent (new LogView (item.Repository, item.Path));
		}

		public static void Show (VersionControlItemList items)
		{
			foreach (VersionControlItem item in items) {
				var document = IdeApp.Workbench.OpenDocument (item.Path);
				ComparisonView.AttachViewContents (document, item);
				document.Window.SwitchView (1);
			}
		}
		
		public static bool CanShow (VersionControlItemList items)
		{
			foreach (VersionControlItem item in items) {
				if (item.Repository.IsModified (item.Path))
					return true;
			}
			return false;
		}

		public ComparisonView (Document doc, VersionControlItem item) : base ("Comparison")
		{
			widget = new ComparisonWidgetContainer (doc, item);
		}

		#region IAttachableViewContent implementation
		public void Selected ()
		{
			widget.ComparisonWidget.LeftEditor.Document.IgnoreFoldings = true;
		}
		

		public void Deselected ()
		{
			widget.ComparisonWidget.LeftEditor.Document.IgnoreFoldings = false;
		}

		public void BeforeSave ()
		{
		}

		public void BaseContentChanged ()
		{
		}
		#endregion
	}
}

