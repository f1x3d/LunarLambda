﻿using System;
using System.Collections.Generic;
using System.Drawing;

using LudicrousElectron.Engine.Window;
using LudicrousElectron.GUI;
using LudicrousElectron.GUI.Elements;
using LudicrousElectron.GUI.Geometry;
using LudicrousElectron.GUI.Text;

namespace LunarLambda.GUI.Menus.Controls
{
	public class Header : UIPanel
	{
		protected string LabelText = string.Empty;
		protected int Font = -1;

		protected UILabel LabelControl = null;

		public Header(RelativeRect rect, string label, int font = -1) : base(rect, "ui/KeyValueBackground.png")
		{
			FillMode = UIFillModes.Stretch4Quad;
			IgnoreMouse = true;
			Font = font;
			SetText(label);
		}

		public virtual void SetText(string text)
		{
			LabelText = text;
			if (LabelControl == null)
				SetupLabel();
			else
			{
				LabelControl.Text = text;
				SetDirty();
			}
		}

		public string GetText()
		{
			return LabelText;
		}

		protected virtual void SetupLabel()
		{
			if (!WindowManager.Inited())
				return;

			if (Font == -1)
				Font = FontManager.DefaultFont;

			LabelControl = new UILabel(Font, LabelText, RelativePoint.Center, RelativeSize.FullHeight + (0.35f));
			LabelControl.DefaultMaterial.Color = Color.White;
			AddChild(LabelControl);
		}

		public override void FlushMaterial()
		{
			base.FlushMaterial();
			if (LabelControl != null)
			{
				LabelControl.DefaultMaterial.Color = Color.White; ;
				LabelControl.FlushMaterial();
			}
		}

		public override void Resize(int x, int y)
		{
			if (LabelText != string.Empty && LabelControl == null)
				SetupLabel();

			base.Resize(x, y);
		}
	}
}
