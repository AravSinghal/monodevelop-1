// MSBuildItemTypeExtensionNode.cs
//
// Author:sdfsdf
//   Lluis Sanchez Gual <lluis@novell.com>
//
// Copyright (c) 2008 Novell, Inc (http://www.novell.com)
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
//
//
 
using System;
using System.IO;
using System.Xml;
using Mono.Addins;
using MonoDevelop.Projects.Formats.MSBuild;
using MonoDevelop.Core;
using System.Threading.Tasks;
using MonoDevelop.Core.ProgressMonitoring;
using System.Runtime.Remoting.Messaging;

namespace MonoDevelop.Projects.Extensions
{
	[ExtensionNode (ExtensionAttributeType=typeof(ExportSolutionItemTypeAttribute))]
	public abstract class SolutionItemTypeNode: ExtensionNode
	{
		[NodeAttribute (Required=true)]
		string guid = null;
		
		[NodeAttribute]
		string extension = null;
		
		[NodeAttribute]
		string import = null;
		
		[NodeAttribute]
		string type = null;

		protected SolutionItemTypeNode ()
		{
		}
		
		protected SolutionItemTypeNode (string guid, string extension, string import)
		{
			this.guid = guid;
			this.extension = extension;
			this.import = import;
		}
		
		[NodeAttribute ("tag")]
		public string TypeTag { get; set; }

		public string Guid {
			get { return guid; }
			set { guid = value; }
		}

		public string Extension {
			get { return extension; }
			set { extension = value; }
		}

		public string Import {
			get { return import; }
			set { import = value; }
		}

		internal string ItemTypeName {
			get { return type; }
			set { type = value; }
		}

		public virtual Type ItemType {
			get { return Addin.GetType (type, true); }
		}
		
		public virtual bool CanHandleFile (string fileName, string typeGuid)
		{
			if (typeGuid != null && string.Compare (typeGuid, guid, true) == 0)
				return true;
			if (!string.IsNullOrEmpty (extension) && System.IO.Path.GetExtension (fileName) == "." + extension)
				return true;
			return false;
		}

		SolutionItemFactory factory;
		
		public virtual async Task<SolutionItem> CreateSolutionItem (ProgressMonitor monitor, string fileName)
		{
			SolutionItem item;

			if (typeof(SolutionItemFactory).IsAssignableFrom (ItemType)) {
				if (factory == null)
					factory = (SolutionItemFactory)Activator.CreateInstance (ItemType);
				item = await factory.CreateItem (fileName, Guid);
			} else {
				try {
					// Some subclasses (such as ProjectTypeNode) need to assign some data to
					// the object before it is initialized. However, by default initialization
					// is automatically made by the constructor, so to support this scenario
					// the initialization has to be delayed. This is done by setting the
					// MonoDevelop.DelayItemInitialization logical context property.
					// When this property is set, the object is not initialized, and it has
					// to be manually initialized by calling EnsureInitialized.
					CallContext.LogicalSetData ("MonoDevelop.DelayItemInitialization", true);
					item = (SolutionItem)Activator.CreateInstance (ItemType, true);
				} finally {
					CallContext.LogicalSetData ("MonoDevelop.DelayItemInitialization", false);
				}
			}
			item.TypeGuid = Guid;
			return item;
		}

		public virtual bool CanCreateSolutionItem (string type, ProjectCreateInformation info, System.Xml.XmlElement projectOptions)
		{
			return type.Equals (Guid, StringComparison.OrdinalIgnoreCase) || type == TypeTag;
		}

		public virtual SolutionItem CreateSolutionItem (string type, ProjectCreateInformation info, System.Xml.XmlElement projectOptions)
		{
			var item = CreateSolutionItem (new ProgressMonitor (), null).Result;
			item.EnsureInitialized ();
			item.InitializeFromTemplate (info, projectOptions);
			return item;
		}
	}
}