﻿using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace ReClassNET.UI
{
	class SettingsTextBox : TextBox, ISettingsBindable
	{
		private PropertyInfo property;
		private Settings source;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string SettingName
		{
			get { return property?.Name; }
			set { property = typeof(Settings).GetProperty(value); ReadSetting(); }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Settings Source
		{
			get { return source; }
			set { source = value; ReadSetting(); }
		}

		private void ReadSetting()
		{
			if (property != null && source != null)
			{
				var value = property.GetValue(source);
				if (value is string)
				{
					Text = (string)value;
				}
			}
		}

		private void WriteSetting()
		{
			if (property != null && source != null)
			{
				property.SetValue(source, Text);
			}
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);

			WriteSetting();
		}
	}
}
