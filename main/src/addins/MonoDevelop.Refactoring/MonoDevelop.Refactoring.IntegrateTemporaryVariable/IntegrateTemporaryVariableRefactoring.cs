// 
// IntegrateTemporaryVariable.cs
//  
// Author:
//       Andrea Krüger <andrea@icsharpcode.net>
// 
// Copyright (c) 2009 Andrea Krüger
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
using MonoDevelop.Projects.Dom.Parser;
using MonoDevelop.Projects.Dom;
using MonoDevelop.Ide.Gui;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory;
using MonoDevelop.Core.Gui;

namespace MonoDevelop.Refactoring.IntegrateTemporaryVariable
{
	public class IntegrateTemporaryVariableRefactoring : RefactoringOperation
	{
		public IntegrateTemporaryVariableRefactoring ()
		{
			Name = "Integrate Temporary Variable";
		}
		
		INode GetMemberBodyNode (MonoDevelop.Refactoring.RefactoringOptions options)
		{
			if (options.ResolveResult == null)
				return null;
			IMember member = options.ResolveResult.CallingMember;
			if (member == null)
				return null;
			int start = options.Document.TextEditor.GetPositionFromLineColumn (member.BodyRegion.Start.Line, member.BodyRegion.Start.Column);
			int end = options.Document.TextEditor.GetPositionFromLineColumn (member.BodyRegion.End.Line, member.BodyRegion.End.Column);
			string memberBody = options.Document.TextEditor.GetText (start, end);
			INRefactoryASTProvider provider = options.GetASTProvider ();
			if (provider == null) {
				Console.WriteLine("!!!Provider not found!");
				return null;
			}
			return provider.ParseText (memberBody);
		}

		LocalVariableDeclaration GetVariableDeclaration (RefactoringOptions options)
		{
			//			ParsedDocument doc = ProjectDomService.Parse (dom.Project, document.FileName, DesktopService.GetMimeTypeForUri (document.FileName), document.TextEditor.Text);
			//			if (doc == null || doc.CompilationUnit == null)
			//				return null;
			//			int line, column;
			//			document.TextEditor.GetLineColumnFromPosition (document.TextEditor.CursorPosition, out line, out column);
			//			IMember member = doc.CompilationUnit.GetMemberAt (line, column);
			INode result = GetMemberBodyNode (options);
			if (result == null)
				return null;
			Location cursorLocation = new Location (options.Document.TextEditor.CursorColumn, options.Document.TextEditor.CursorLine - options.ResolveResult.CallingMember.BodyRegion.Start.Line);
			// relativ to the memberBody
			Location selectionStartLocation;
			int l, c;
			if (options.Document.TextEditor.SelectionStartPosition.Equals (options.Document.TextEditor.CursorPosition)) {
				options.Document.TextEditor.GetLineColumnFromPosition (options.Document.TextEditor.SelectionEndPosition, out l, out c);
			} else {
				options.Document.TextEditor.GetLineColumnFromPosition (options.Document.TextEditor.SelectionStartPosition, out l, out c);
			}
			selectionStartLocation = new Location (c, l - options.ResolveResult.CallingMember.BodyRegion.Start.Line); // relativ to the memberBody
			INode statementAtCursor = null;
//			Console.WriteLine ("!!! Suche Variablendeklaration an Position: " + cursorLocation.ToString ());
			while (result is BlockStatement) {
				foreach (Statement child in result.Children) {
//					Console.WriteLine ("!!! child an: " + child.StartLocation.ToString () + " --- " + child.EndLocation.ToString ());
					if (child.StartLocation <= cursorLocation && child.EndLocation >= cursorLocation) {
						statementAtCursor = child;
//						Console.WriteLine ("!!! Gefunden, Typ: " + statementAtCursor.GetType ().ToString ());
						if (child.StartLocation > selectionStartLocation || child.EndLocation < selectionStartLocation) {
//							Console.WriteLine ("!!!SelectionStart ausserhalb");
							return null;
						}
						break;
					}
				}
				result = statementAtCursor;
			}
			if (statementAtCursor is LocalVariableDeclaration)
				return (LocalVariableDeclaration)statementAtCursor;
			return null;
		}

		
		public override bool IsValid (RefactoringOptions options)
		{
			return GetVariableDeclaration (options) != null;
		}
		
		public override List<Change> PerformChanges (RefactoringOptions options, object properties)
		{
			LocalVariableDeclaration declaration = GetVariableDeclaration (options);
			INode memberNode = GetMemberBodyNode (options);
			List<Change> changes = new List<Change> ();
			memberNode.AcceptVisitor (new IntegrateTemporaryVariableVisitor (), new IntegrateTemporaryVariableVisitorOptions(changes, options, declaration));
			
			return null;
		}
		
		public override void Run (RefactoringOptions options)
		{
		}
		
		class IntegrateTemporaryVariableVisitor : ICSharpCode.NRefactory.Visitors.AbstractAstVisitor
		{
			public override object VisitAssignmentExpression (AssignmentExpression assignmentExpression, object data)
			{
				if (assignmentExpression.Left is IdentifierExpression && ((IdentifierExpression)assignmentExpression.Left).Identifier == ((IntegrateTemporaryVariableVisitorOptions)data).GetName())
				assignmentExpression.Left.AcceptVisitor(this, data);
				return assignmentExpression.Right.AcceptVisitor(this, data);
			}
		}
		class IntegrateTemporaryVariableVisitorOptions
		{
			bool isvalid = true;
			public bool IsValid {
				get { return isvalid; }
			}
			public List<Change> Changes {
				get;
				set;
			}
			public RefactoringOptions Options {
				get;
				set;
			}
			public LocalVariableDeclaration Declaration {
				get;
				set;
			}
			public string GetName ()
			{
				return Declaration.Variables[0].Name;
			}
			public IntegrateTemporaryVariableVisitorOptions(List<Change> changes, RefactoringOptions options, LocalVariableDeclaration declaration)
			{
				Changes = changes;
				Options = options;
				Declaration = declaration;
			}
		}
	}
}
