// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike KrÃ¼ger" email="mike@icsharpcode.net"/>
//     <version value="$version"/>
// </file>

using System;
using System.Collections;
using System.Text;

using MonoDevelop.Projects.Parser;
using MonoDevelop.Core;
using MonoDevelop.Projects.Ambience;

namespace CSharpBinding
{
	public class CSharpAmbience : Ambience
	{
		static string[,] typeConversionList = new string[,] {
			{"System.Void",    "void"},
			{"System.Object",  "object"},
			{"System.Boolean", "bool"},
			{"System.Byte",    "byte"},
			{"System.SByte",   "sbyte"},
			{"System.Char",    "char"},
			{"System.Enum",    "enum"},
			{"System.Int16",   "short"},
			{"System.Int32",   "int"},
			{"System.Int64",   "long"},
			{"System.UInt16",  "ushort"},
			{"System.UInt32",  "uint"},
			{"System.UInt64",  "ulong"},
			{"System.Single",  "float"},
			{"System.Double",  "double"},
			{"System.Decimal", "decimal"},
			{"System.String",  "string"}
		};
		
		static Hashtable typeConversionTable = new Hashtable();
		
		public static Hashtable TypeConversionTable {
			get {
				return typeConversionTable;
			}
		}
		
		static CSharpAmbience()
		{
			for (int i = 0; i < typeConversionList.GetLength(0); ++i) {
				typeConversionTable[typeConversionList[i, 0]] = typeConversionList[i, 1];
			}
		}
		
		bool ModifierIsSet(ModifierEnum modifier, ModifierEnum query)
		{
			return (modifier & query) == query;
		}
		
		public override string Convert(ModifierEnum modifier, ConversionFlags conversionFlags)
		{
			if (ShowAccessibility(conversionFlags)) {
				if (ModifierIsSet(modifier, ModifierEnum.Public)) {
					return "public ";
				} else if (ModifierIsSet(modifier, ModifierEnum.Private)) {
					return "private ";
				} else if (ModifierIsSet(modifier, ModifierEnum.ProtectedAndInternal)) {
					return "protected internal ";
				} else if (ModifierIsSet(modifier, ModifierEnum.ProtectedOrInternal)) {
					return "internal protected ";
				} else if (ModifierIsSet(modifier, ModifierEnum.Internal)) {
					return "internal ";
				} else if (ModifierIsSet(modifier, ModifierEnum.Protected)) {
					return "protected ";
				}
			}
			
			return string.Empty;
		}
		
		string GetModifier(IDecoration decoration, ConversionFlags conversionFlags)
		{	
			string mod;
			
			if (decoration.IsStatic)        mod = "static ";
			else if (decoration.IsFinal)    mod = "final ";
			else if (decoration.IsVirtual)  mod = "virtual ";
			else if (decoration.IsOverride) mod = "override ";
			else if (decoration.IsNew)      mod = "new ";
			else return "";
			
			if (IncludeHTMLMarkup(conversionFlags) | IncludePangoMarkup(conversionFlags))
				return "<i>" + mod + "</i>";
			else
				return mod;
		}
		
		string ConvertTypeName (string typeName, ConversionFlags conversionFlags)
		{
			int p = typeName.IndexOf ('`');
			if (p == -1)
				return GetIntrinsicTypeName (typeName);

			StringBuilder res = new StringBuilder (GetIntrinsicTypeName (typeName.Substring (0, p)));
			int i = typeName.IndexOf ('[', p);
			if (i == -1)
				return typeName.Substring (0, p);

			if (!ParseGenericParamList (res, typeName, ref i, conversionFlags))
				return typeName;
			
			res.Append (typeName.Substring (i));
			return res.ToString ();
		}
		
		bool ParseTypeName (StringBuilder res, string str, ref int i, ConversionFlags conversionFlags)
		{
			int p = str.IndexOfAny (new char [] { '`', ',', '*', '[', ']'}, i);
			if (p == -1)
				return false;
			
			res.Append (GetIntrinsicTypeName (str.Substring (i, p - i)));
			while (true) {
				char c = str [p];
				if (c == '`') {
					// It's a generic type
					i = str.IndexOf ('[', p);
					if (i == -1) return false;
					return ParseGenericParamList (res, str, ref i, conversionFlags);
				}
				else if (c == ',' || c == ']') {
					// end of name
					i = p;
					return true;
				}
				else if (c == '[') {
					// It's an array, skip it and continue searching
					i = str.IndexOf (']', p + 1);
					if (i == -1) return false;
					res.Append (str, p, i - p + 1);
					p = i + 1;
				}
				else if (c == '*') {
					// It's an array, skip it and continue searching
					res.Append (c);
					p++;
				}
				else
					return false;
			}
		}
		
		bool ParseGenericParamList (StringBuilder res, string str, ref int i, ConversionFlags conversionFlags)
		{
			// Parses a list of generic parameters (including the brackets)
			
			bool includeMarkup = IncludeHTMLMarkup (conversionFlags) || IncludePangoMarkup (conversionFlags);
			res.Append ((includeMarkup) ? "&lt;" : "<");

			int p = i + 1;
			while (p < str.Length && str [p] != ']') {
				if (!ParseTypeName (res, str, ref p, conversionFlags))
					return false;
				if (str [p] == ',') {
					res.Append (',');
					p++;
				}
			}
			res.Append ((includeMarkup) ? "&gt;" : ">");
			i = p + 1;
			return true;
		}
		
		public override string Convert(IClass c, ConversionFlags conversionFlags)
		{
			StringBuilder builder = new StringBuilder();
			
			builder.Append(Convert(c.Modifiers, conversionFlags));
			
			if (ShowClassModifiers(conversionFlags)) {
				if (c.IsSealed) {
					switch (c.ClassType) {
						case ClassType.Delegate:
						case ClassType.Struct:
						case ClassType.Enum:
							break;
						
						default:
							AppendPangoHtmlTag (builder, "sealed ", "i", conversionFlags);
							break;
					}
				} else if (c.IsAbstract && c.ClassType != ClassType.Interface) {
					AppendPangoHtmlTag (builder, "abstract ", "i", conversionFlags);
				}
			}
			
			if (ShowClassModifiers(conversionFlags)) {
				switch (c.ClassType) {
					case ClassType.Delegate:
						builder.Append("delegate");
						// Only display the return type when modifiers are to be
						// shown - this fixes the vay delegates are shown in the
						// popup window
						if (c.Methods.Count > 0) {
							foreach(IMethod m in c.Methods) {
								if (m.Name != "Invoke") continue;
								builder.Append (' ');
								builder.Append (Convert(m.ReturnType));
							}
						}
						break;
					case ClassType.Class:
						builder.Append("class");
						break;
					case ClassType.Struct:
						builder.Append("struct");
						break;
					case ClassType.Interface:
						builder.Append("interface");
						break;
					case ClassType.Enum:
						builder.Append("enum");
						break;
				}
				builder.Append(' ');
			}
			
			if (c.ClassType == ClassType.Delegate && c.Methods.Count > 0) {
				foreach(IMethod m in c.Methods) {
					if (m.Name != "Invoke") continue;
					
					builder.Append(Convert(m.ReturnType, conversionFlags));
					builder.Append(' ');
				}
			} else if (UseFullyQualifiedMemberNames(conversionFlags)) {
				AppendPangoHtmlTag (builder, ConvertTypeName (c.FullyQualifiedName, conversionFlags), "b", conversionFlags);
			} else {
				AppendPangoHtmlTag (builder, ConvertTypeName (c.Name, conversionFlags), "b", conversionFlags);
			}
			
			// Display generic parameters only if told so
			if (ShowGenericParameters(conversionFlags) && c.GenericParameters != null && c.GenericParameters.Count > 0) {
				bool includeMarkup = IncludeHTMLMarkup(conversionFlags) || IncludePangoMarkup(conversionFlags);
				builder.Append ((includeMarkup) ? "&lt;" : "<");
				// Since we know that there is at least one generic parameter in
				// the list, we can add it outside the loop - so, we don't have
				// to check whether we may append a comma or not
				builder.Append (c.GenericParameters[0].Name);
				// Now continue with the others, if there are any
				for (int i = 1; i < c.GenericParameters.Count; i++) {
					builder.Append (", ");
					builder.Append (c.GenericParameters[i].Name);
				}
				builder.Append ((includeMarkup) ? "&gt;" : ">");
			}
			
			if (c.ClassType == ClassType.Delegate) {
				builder.Append(" (");
				if (IncludeHTMLMarkup(conversionFlags)) builder.Append("<br>");
				
				foreach(IMethod m in c.Methods) {
					if (m.Name != "Invoke") continue;
					
					for (int i = 0; i < m.Parameters.Count; ++i) {
						if (IncludeHTMLMarkup(conversionFlags)) builder.Append("&nbsp;&nbsp;&nbsp;");
						
						builder.Append(Convert(m.Parameters[i], conversionFlags));
						if (i + 1 < m.Parameters.Count) builder.Append(", ");
						
						if (IncludeHTMLMarkup(conversionFlags)) builder.Append("<br>");
					}
				}
				builder.Append(')');
				
			} else if (ShowInheritanceList(conversionFlags) && c.ClassType != ClassType.Enum) {
				if (c.BaseTypes.Count > 0) {
					builder.Append (" : ");
					builder.Append (Convert(c.BaseTypes[0]));
					for (int i = 1; i < c.BaseTypes.Count; ++i) {
						builder.Append (", ");
						builder.Append (Convert(c.BaseTypes[i]));
					}
				}
			}
			
			if (IncludeBodies(conversionFlags)) {
				builder.Append("\n{");
			}
			
			return builder.ToString();		
		}
		
		public override string ConvertEnd(IClass c, ConversionFlags conversionFlags)
		{
			return "}";
		}
		
		public override string Convert(IField field, ConversionFlags conversionFlags)
		{
			StringBuilder builder = new StringBuilder();
			
			builder.Append(Convert(field.Modifiers, conversionFlags));
			
			if (ShowMemberModifiers(conversionFlags)) {
				if (field.IsStatic && field.IsLiteral)
					AppendPangoHtmlTag (builder, "const ", "i", conversionFlags);
				else if (field.IsStatic)
					AppendPangoHtmlTag (builder, "static ", "i", conversionFlags);
				
				if (field.IsReadonly) {
					AppendPangoHtmlTag (builder, "readonly ", "i", conversionFlags);
				}
			}
			
			if (field.ReturnType != null) {
				builder.Append(Convert(field.ReturnType, conversionFlags));
				builder.Append(' ');
			}
			
			if (UseFullyQualifiedMemberNames(conversionFlags))
				AppendPangoHtmlTag (builder, ConvertTypeName (field.FullyQualifiedName, conversionFlags), "b", conversionFlags);
			else
				AppendPangoHtmlTag (builder, field.Name, "b", conversionFlags);
			
			if (IncludeBodies(conversionFlags))
				builder.Append(";");
			
			return builder.ToString();			
		}
		
		public override string Convert(IProperty property, ConversionFlags conversionFlags)
		{
			StringBuilder builder = new StringBuilder();
			
			builder.Append(Convert(property.Modifiers, conversionFlags));
			
			if (ShowMemberModifiers(conversionFlags)) {
				builder.Append(GetModifier(property, conversionFlags));
			}
			
			if (property.ReturnType != null) {
				builder.Append(Convert(property.ReturnType, conversionFlags));
				builder.Append(' ');
			}
			
			if (UseFullyQualifiedMemberNames(conversionFlags))
				AppendPangoHtmlTag (builder, ConvertTypeName (property.FullyQualifiedName, conversionFlags), "b", conversionFlags);
			else
				AppendPangoHtmlTag (builder, property.Name, "b", conversionFlags);
			
			if (property.Parameters.Count > 0) {
				builder.Append(" (");

			if (IncludeHTMLMarkup(conversionFlags)) builder.Append("<br>&nbsp;&nbsp;&nbsp;");
			builder.Append (Convert (property.Parameters[0], conversionFlags));
			
				for (int i = 0; i < property.Parameters.Count; ++i) {
					if (IncludeHTMLMarkup(conversionFlags)) builder.Append("<br>&nbsp;&nbsp;&nbsp;");
					builder.Append(", ");
					builder.Append(Convert(property.Parameters[i], conversionFlags));
				}
				if (IncludeHTMLMarkup(conversionFlags)) builder.Append("<br>");
				
				builder.Append(')');
			}
			
			builder.Append(" { ");
			
			if (property.CanGet) {
				builder.Append("get; ");
			}
			if (property.CanSet) {
				builder.Append("set; ");
			}
			
			builder.Append(" } ");
			
			return builder.ToString();
		}
		
		public override string Convert(IEvent e, ConversionFlags conversionFlags)
		{
			StringBuilder builder = new StringBuilder();
			
			builder.Append(Convert(e.Modifiers, conversionFlags));
			
			if (ShowMemberModifiers(conversionFlags)) {
				builder.Append(GetModifier(e, conversionFlags));
			}
			
			if (e.ReturnType != null) {
				builder.Append(Convert(e.ReturnType, conversionFlags));
				builder.Append(' ');
			}
			
			if (UseFullyQualifiedMemberNames(conversionFlags))
				AppendPangoHtmlTag (builder, ConvertTypeName (e.FullyQualifiedName, conversionFlags), "b", conversionFlags);
			else
				AppendPangoHtmlTag (builder, e.Name, "b", conversionFlags);
			
			if (IncludeBodies(conversionFlags)) builder.Append(";");
			
			return builder.ToString();
		}
		
		public override string Convert(IIndexer m, ConversionFlags conversionFlags)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(Convert(m.Modifiers, conversionFlags));
			
			if (ShowMemberModifiers(conversionFlags) && m.IsStatic)
				AppendPangoHtmlTag (builder, "static", "i", conversionFlags);
			
			if (m.ReturnType != null) {
				builder.Append(Convert(m.ReturnType, conversionFlags));
				builder.Append(' ');
			}
			
			if (UseFullyQualifiedMemberNames (conversionFlags))
				AppendPangoHtmlTag (builder, ConvertTypeName (m.FullyQualifiedName, conversionFlags), "b", conversionFlags);
			else
				AppendPangoHtmlTag (builder, ConvertTypeName (m.Name, conversionFlags), "b", conversionFlags);
			
			builder.Append(" [");
			
			Convert (m.Parameters, builder, conversionFlags);
			
			builder.Append(']');
			
			if (IncludeBodies(conversionFlags)) builder.Append(";");
			
			return builder.ToString();
		}
		
		public void Convert (ParameterCollection parameters, StringBuilder builder, ConversionFlags conversionFlags)
		{
			if (parameters.Count > 0) {
				if (IncludeHTMLMarkup(conversionFlags)) builder.Append ("<br>&nbsp;&nbsp;&nbsp;");
				builder.Append (Convert (parameters[0], conversionFlags));
				for (int i = 1; i < parameters.Count; ++i) {
					builder.Append (", ");
					if (IncludeHTMLMarkup(conversionFlags)) builder.Append("<br>&nbsp;&nbsp;&nbsp;");
					builder.Append(Convert(parameters[i], conversionFlags));
				}
				if (IncludeHTMLMarkup(conversionFlags)) builder.Append("<br>");
			}
		}
		
		public override string Convert(IMethod m, ConversionFlags conversionFlags)
		{
			bool includeMarkup = IncludeHTMLMarkup(conversionFlags) || IncludePangoMarkup(conversionFlags);
			
			StringBuilder builder = new StringBuilder();
			builder.Append(Convert(m.Modifiers, conversionFlags));
			if (ShowMemberModifiers(conversionFlags)) {
				builder.Append(GetModifier(m, conversionFlags));
			}
			
			if (m.ReturnType != null) {
				builder.Append(Convert(m.ReturnType, conversionFlags));
				builder.Append(' ');
			}
			
			string name = m.Name;
			if (m.IsSpecialName) {
				name = GetSpecialMethodName (name);
				if (includeMarkup) {
					name = name.Replace ("<", "&lt;");
					name = name.Replace (">", "&gt;");
				}
			}
			
			if (m.IsConstructor) {
				if (m.DeclaringType != null)
					AppendPangoHtmlTag (builder, ConvertTypeName (m.DeclaringType.Name, conversionFlags), "b", conversionFlags);
				else
					AppendPangoHtmlTag (builder, name, "b", conversionFlags);
			} else {
				if (UseFullyQualifiedMemberNames(conversionFlags)) {
					string fq = m.DeclaringType.FullyQualifiedName + "." + name;
					AppendPangoHtmlTag (builder, ConvertTypeName (fq, conversionFlags), "b", conversionFlags);
				}
				else
					AppendPangoHtmlTag (builder, name, "b", conversionFlags);
			}
			
			// Display generic parameters only if told so
			if (ShowGenericParameters(conversionFlags) && m.GenericParameters != null && m.GenericParameters.Count > 0) {
				builder.Append ((includeMarkup) ? "&lt;" : "<");
				// Since we know that there is at least one generic parameter in
				// the list, we can add it outside the loop - so, we don't have
				// to check whether we may append a comma or not
				builder.Append (m.GenericParameters[0].Name);
				// Now continue with the others, if there are any
				for (int i = 1; i < m.GenericParameters.Count; i++) {
					builder.Append (", ");
					builder.Append (m.GenericParameters[i].Name);
				}
				builder.Append ((includeMarkup) ? "&gt;" : ">");
			}
			
			builder.Append(" (");
			Convert (m.Parameters, builder, conversionFlags);
			builder.Append(')');
			
			if (IncludeBodies(conversionFlags)) {
				if (m.DeclaringType != null) {
					if (m.DeclaringType.ClassType == ClassType.Interface) {
						builder.Append(";");
					} else {
						builder.Append(" {");
					}
				} else {
					builder.Append(" {");
				}
			}
			return builder.ToString();
		}
		
		string GetSpecialMethodName (string name)
		{
			switch (name) {
				case "op_UnaryPlus":
				case "op_Addition": return "operator +";
				case "op_Subtraction":
				case "op_UnaryNegation": return "operator -";
				case "op_Multiply": return "operator *";
				case "op_Division": return "operator /";
				case "op_Modulus": return "operator %";
				case "op_LogicalNot": return "operator !";
				case "op_BitwiseAnd": return "operator &";
				case "op_BitwiseOr": return "operator |";
				case "op_ExclusiveOr": return "operator ^";
				case "op_LeftShift": return "operator <<";
				case "op_RightShift": return "operator >>";
				case "op_GreaterThan": return "operator >";
				case "op_GreaterThanOrEqual": return "operator >=";
				case "op_Equality": return "operator ==";
				case "op_Inequality": return "operator !=";
				case "op_LessThan": return "operator <";
				case "op_LessThanOrEqual": return "operator <=";
				case "op_Increment": return "operator ++";
				case "op_Decrement": return "operator --";
				case "op_True": return "operator true";
				case "op_False": return "operator false";
			}
			return name;
		}
		
		public override string ConvertEnd(IMethod m, ConversionFlags conversionFlags)
		{
			return "}";
		}
		
		public override string Convert(IReturnType returnType, ConversionFlags conversionFlags)
		{
			if (returnType == null) {
				return String.Empty;
			}
			StringBuilder builder = new StringBuilder();
			
			//bool linkSet = false;
			
			//if (UseLinkArrayList(conversionFlags)) {
				//SharpAssemblyReturnType ret = returnType as SharpAssemblyReturnType;
				//if (ret != null) {
				//	if (ret.UnderlyingClass != null) {
				//		builder.Append("<a href='as://" + linkArrayList.Add(ret.UnderlyingClass) + "'>");
				//		linkSet = true;
				//	}
				//}
			//}
			
			if (typeConversionTable[returnType.FullyQualifiedName] != null) {
				builder.Append(typeConversionTable[returnType.FullyQualifiedName].ToString());
			} else {
				if (UseFullyQualifiedMemberNames(conversionFlags)) {
					builder.Append (ConvertTypeName (returnType.FullyQualifiedName, conversionFlags));
				} else {
					builder.Append (ConvertTypeName (returnType.Name, conversionFlags));
				}
			}
			
			// Display generic parameters only if told so
			if (ShowGenericParameters(conversionFlags) && returnType.GenericArguments != null && returnType.GenericArguments.Count > 0) {
				bool includeMarkup = IncludeHTMLMarkup(conversionFlags) || IncludePangoMarkup(conversionFlags);
				builder.Append ((includeMarkup) ? "&lt;" : "<");
				// Since we know that there is at least one generic argument in
				// the list, we can add it outside the loop - so, we don't have
				// to check whether we may append a comma or not
				builder.Append (Convert(returnType.GenericArguments[0], conversionFlags));
				// Now continue with the others, if there are any
				for (int i = 1; i < returnType.GenericArguments.Count; i++) {
					builder.Append (", ");
					builder.Append ( Convert(returnType.GenericArguments[i], conversionFlags));
				}
				builder.Append ((includeMarkup) ? "&gt;" : ">");
			}
			
//			if (linkSet) {
//				builder.Append("</a>");
//			}
			
			for (int i = 0; i < returnType.PointerNestingLevel; ++i) {
				builder.Append('*');
			}
			
			for (int i = 0; i < returnType.ArrayCount; ++i) {
				builder.Append('[');
				for (int j = 1; j < returnType.ArrayDimensions[i]; ++j) {
					builder.Append(',');
				}
				builder.Append(']');
			}
			
			return builder.ToString();
		}
		
		public override string Convert(IParameter param, ConversionFlags conversionFlags)
		{
			StringBuilder builder = new StringBuilder();
			
			if (param.IsRef)
				AppendPangoHtmlTag (builder, "ref ", "i", conversionFlags);
			else if (param.IsOut)
				AppendPangoHtmlTag (builder, "out ", "i", conversionFlags);
			else if (param.IsParams)
				AppendPangoHtmlTag (builder, "params ", "i", conversionFlags);
			
			builder.Append(Convert(param.ReturnType, conversionFlags));
			
			if (ShowParameterNames(conversionFlags)) {
				builder.Append(' ');
				AppendPangoHtmlTag (builder, param.Name, "b", conversionFlags);
			}
			return builder.ToString();
		}

		public override string Convert(LocalVariable localVariable, ConversionFlags conversionFlags)
		{
			StringBuilder builder = new StringBuilder();						
			
			builder.Append(Convert(localVariable.ReturnType, conversionFlags));						
			builder.Append(' ');
			AppendPangoHtmlTag (builder, localVariable.Name, "b", conversionFlags);
			
			return builder.ToString();
		}
		
		// pango has some problems with
		// <i>static </i>bool <b>Equals</b> (<i></i>object a, <i></i>object b)
		// it will make "object a" italics. so rather tan appending a markup
		// tag if there might be a modifier, we only do it if there is.
		void AppendPangoHtmlTag (StringBuilder sb, string str, string tag, ConversionFlags conversionFlags)
		{
			if (IncludeHTMLMarkup(conversionFlags) | IncludePangoMarkup(conversionFlags)) sb.Append ('<').Append (tag).Append ('>');
			
			sb.Append (str);
			
			if (IncludeHTMLMarkup(conversionFlags) | IncludePangoMarkup(conversionFlags)) sb.Append ("</").Append (tag).Append ('>');
		}
		
		public override string WrapAttribute(string attribute)
		{
			return "[" + attribute + "]";
		}
		
		public override string WrapComment(string comment)
		{
			return "// " + comment;
		}

		public override string GetIntrinsicTypeName(string dotNetTypeName)
		{
			if (typeConversionTable[dotNetTypeName] != null) {
				return (string)typeConversionTable[dotNetTypeName];
			}
			return dotNetTypeName;
		}
		
	}
}
