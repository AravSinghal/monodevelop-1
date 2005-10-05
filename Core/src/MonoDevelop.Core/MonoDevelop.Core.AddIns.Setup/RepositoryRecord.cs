//
// RepositoryRecord.cs
//
// Author:
//   Lluis Sanchez Gual
//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
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
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


namespace MonoDevelop.Core.AddIns.Setup
{
	public class RepositoryRecord
	{
		string id;
		bool isReference;
		string file;
		string url;
		DateTime lastModified;
		
		[XmlAttribute ("id")]
		public string Id {
			get { return id; }
			set { id = value; }
		}
		
		public bool IsReference {
			get { return isReference; }
			set { isReference = value; }
		}
		
		public string File {
			get { return file; }
			set { file = value; }
		}
		
		public string Url {
			get { return url; }
			set { url = value; }
		}
		
		public DateTime LastModified {
			get { return lastModified; }
			set { lastModified = value; }
		}
		
		public Repository GetCachedRepository ()
		{
			return (Repository) SetupService.ReadObject (File, typeof(Repository));
		}
		
		public void ClearCachedRepository ()
		{
			if (System.IO.File.Exists (File))
				System.IO.File.Delete (File);
		}
		
		public void UpdateCachedRepository (Repository newRep)
		{
			newRep.url = Url;
			if (newRep.Name == null)
				newRep.Name = new Uri (Url).Host;
			SetupService.WriteObject (File, newRep);
		}
	}
}
