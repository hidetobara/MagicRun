using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scenario.Story
{
	using Array = List<System.Object>;
	using Hash = Dictionary<string, System.Object>;

	public enum FarType { BACKGROUND, BACK, DEFAULT, FRONT }
	public enum AnchorType { CENTER, LEFT, RIGHT, TOP, BOTTOM, FAR_LEFT, FAR_RIGHT, FAR_TOP, FAR_BOTTOM }

	public class Story : Unit
	{
		public static readonly Story Instance = new Story();

		const string NAME = "Story";
		const string TITEL_KEY = "Title";
		public string Title { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			var i = new Story();
			i.Title = RetrieveString(h, TITEL_KEY);
			i.AssignUnits(h, UNITS_KEY, Block.Instance);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { TITEL_KEY, Title } };
			h[UNITS_KEY] = Units2Hash();
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Title + "]"; }
	}

	public class Block : Unit
	{
		public static readonly Block Instance = new Block();

		const string NAME = "Block";
		const string NUMBER_KEY = "Number";
		public int Number { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			var i = new Block();
			i.Number = RetrieveInt(h, NUMBER_KEY);
			i.AssignUnits(h, UNITS_KEY, Cut.Instance, Image.Instance, Text.Instance);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { NUMBER_KEY, Number } };
			h[UNITS_KEY] = Units2Hash();
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Number + "]"; }
	}

	public class Cut : Unit
	{
		public static readonly Cut Instance = new Cut();

		const string NAME = "Cut";
		const string LABEL_KEY = "Label";
		public string Label { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			var i = new Cut();
			i.Label = RetrieveString(h, LABEL_KEY);
			i.AssignUnits(h, UNITS_KEY, Image.Instance, Text.Instance);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { LABEL_KEY, Label } };
			h[UNITS_KEY] = Units2Hash();
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Label + "]"; }
	}

	public class Image : Unit
	{
		public static readonly Image Instance = new Image();

		const string NAME = "Image";
		const string NAME_KEY = "Name";
		public string Name { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			var i = new Image();
			i.Name = RetrieveString(h, NAME_KEY);
			i.AssignUnits(h, UNITS_KEY, Fix.Instance);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { NAME_KEY, Name } };
			h[UNITS_KEY] = Units2Hash();
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Name + "]"; }
	}

	public class Text : Unit
	{
		public static readonly Text Instance = new Text();

		const string NAME = "Text";
		const string SPEAKER_KEY = "Speaker";
		const string MESSAGE_KEY = "Message";
		public string Speaker { set; get; }
		public string Message { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			var i = new Text();
			i.Speaker = RetrieveString(h, SPEAKER_KEY);
			i.Message = RetrieveString(h, MESSAGE_KEY);
			i.AssignUnits(h, UNITS_KEY, Fix.Instance);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { SPEAKER_KEY, Speaker }, { MESSAGE_KEY, Message } };
			h[UNITS_KEY] = Units2Hash();
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Message + "]"; }
	}

	public class Fix : Unit
	{
		public static readonly Fix Instance = new Fix();

		const string NAME = "Fix";
		const string ANCHOR_KEY = "Anchor";
		const string FAR_KEY = "Far";
		const string WIDTH_KEY = "Width";
		const string HEIGHT_KEY = "Height";
		public AnchorType Anchor { set; get; }
		public FarType Far { set; get; }
		public float Width { set; get; }
		public float Height { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			var i = new Fix();
			i.Anchor = RetrieveEnum<AnchorType>(h, ANCHOR_KEY);
			i.Far = RetrieveEnum<FarType>(h, FAR_KEY);
			i.Width = RetrieveFloat(h, WIDTH_KEY);
			i.Height = RetrieveFloat(h, HEIGHT_KEY);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { ANCHOR_KEY, Anchor.ToString() }, { FAR_KEY, Far.ToString() }, { WIDTH_KEY, Width }, { HEIGHT_KEY, Height } };
			return h;
		}
		public override string ToString() { return "[" + NAME + "]"; }
	}

}
