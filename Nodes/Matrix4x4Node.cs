﻿using System.Runtime.InteropServices;
using ReClassNET.UI;

namespace ReClassNET.Nodes
{
	public class Matrix4x4Node : BaseMatrixNode
	{
		[StructLayout(LayoutKind.Explicit)]
		struct Matrix4x4Data
		{
			[FieldOffset(0)]
			public float _11;
			[FieldOffset(4)]
			public float _12;
			[FieldOffset(8)]
			public float _13;
			[FieldOffset(12)]
			public float _14;
			[FieldOffset(16)]
			public float _21;
			[FieldOffset(20)]
			public float _22;
			[FieldOffset(24)]
			public float _23;
			[FieldOffset(28)]
			public float _24;
			[FieldOffset(32)]
			public float _31;
			[FieldOffset(36)]
			public float _32;
			[FieldOffset(40)]
			public float _33;
			[FieldOffset(44)]
			public float _34;
			[FieldOffset(48)]
			public float _41;
			[FieldOffset(52)]
			public float _42;
			[FieldOffset(56)]
			public float _43;
			[FieldOffset(60)]
			public float _44;
		}

		/// <summary>Size of the node in bytes.</summary>
		public override int MemorySize => 16 * 4;

		/// <summary>Draws this node.</summary>
		/// <param name="view">The view information.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <returns>The height the node occupies.</returns>
		public override int Draw(ViewInfo view, int x2, int y2)
		{
			return DrawMatrixType(view, x2, y2, "Matrix (4x4)", (ref int x, ref int y, int defaultX) =>
			{
				var value = view.Memory.ReadObject<Matrix4x4Data>(Offset);

				y += view.Font.Height;
				x = defaultX;
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, "|");
				x = AddText(view, x, y, Program.Settings.ValueColor, 0, $"{value._11,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 1, $"{value._12,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 2, $"{value._13,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 3, $"{value._14,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, "|");

				y += view.Font.Height;
				x = defaultX;
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, "|");
				x = AddText(view, x, y, Program.Settings.ValueColor, 4, $"{value._21,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 5, $"{value._22,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 6, $"{value._23,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 7, $"{value._24,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, "|");

				y += view.Font.Height;
				x = defaultX;
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, "|");
				x = AddText(view, x, y, Program.Settings.ValueColor, 8, $"{value._31,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 9, $"{value._32,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 10, $"{value._33,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 11, $"{value._34,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, "|");

				y += view.Font.Height;
				x = defaultX;
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, "|");
				x = AddText(view, x, y, Program.Settings.ValueColor, 12, $"{value._41,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 13, $"{value._42,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 14, $"{value._43,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, ",");
				x = AddText(view, x, y, Program.Settings.ValueColor, 15, $"{value._44,14:0.000}");
				x = AddText(view, x, y, Program.Settings.NameColor, HotSpot.NoneId, "|");
			});
		}

		protected override int CalculateValuesHeight(ViewInfo view)
		{
			return 4 * view.Font.Height;
		}

		public override void Update(HotSpot spot)
		{
			base.Update(spot);

			Update(spot, 16);
		}
	}
}
