﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;
using ReClassNET.Logger;
using ReClassNET.Nodes;
using ReClassNET.Util;

namespace ReClassNET.DataExchange
{
	public partial class ReClassNetFile : IReClassImport, IReClassExport
	{
		public const string FormatName = "ReClass.NET File";
		public const string FileExtension = ".rcnet";

		private const string Version1 = "1";

		private const string DataFileName = "Data.xml";

		private const string SerialisationClassName = "__Serialization_Class__";

		public const string XmlRootElement = "reclass";
		public const string XmlClassesElement = "classes";
		public const string XmlClassElement = "class";
		public const string XmlNodeElement = "node";
		public const string XmlMethodElement = "method";
		public const string XmlVersionAttribute = "version";
		public const string XmlUuidAttribute = "uuid";
		public const string XmlNameAttribute = "name";
		public const string XmlCommentAttribute = "comment";
		public const string XmlAddressAttribute = "address";
		public const string XmlTypeAttribute = "type";
		public const string XmlReferenceAttribute = "reference";
		public const string XmlCountAttribute = "count";
		public const string XmlBitsAttribute = "bits";
		public const string XmlLengthAttribute = "length";

		private ReClassNetProject project;

		public ReClassNetFile(ReClassNetProject project)
		{
			Contract.Requires(project != null);

			this.project = project;
		}

		private static Dictionary<string, Type> BuildInStringToTypeMap = new Type[]
		{
			typeof(BitFieldNode),
			typeof(ClassInstanceArrayNode),
			typeof(ClassInstanceNode),
			typeof(ClassPtrArrayNode),
			typeof(ClassPtrNode),
			typeof(DoubleNode),
			typeof(FloatNode),
			typeof(FunctionPtrNode),
			typeof(Hex8Node),
			typeof(Hex16Node),
			typeof(Hex32Node),
			typeof(Hex64Node),
			typeof(Int8Node),
			typeof(Int16Node),
			typeof(Int32Node),
			typeof(Int64Node),
			typeof(Matrix3x3Node),
			typeof(Matrix3x4Node),
			typeof(Matrix4x4Node),
			typeof(UInt8Node),
			typeof(UInt16Node),
			typeof(UInt32Node),
			typeof(UInt64Node),
			typeof(UTF8TextNode),
			typeof(UTF8TextPtrNode),
			typeof(UTF16TextNode),
			typeof(UTF16TextPtrNode),
			typeof(UTF32TextNode),
			typeof(UTF32TextPtrNode),
			typeof(Vector2Node),
			typeof(Vector3Node),
			typeof(Vector4Node),
			typeof(VTableNode)
		}.ToDictionary(t => t.Name, t => t);
		private static Dictionary<Type, string> BuildInTypeToStringMap = BuildInStringToTypeMap.ToDictionary(kv => kv.Value, kv => kv.Key);
	}
}
