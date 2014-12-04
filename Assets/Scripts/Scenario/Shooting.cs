using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scenario
{
	using Array = List<System.Object>;
	using Hash = Dictionary<string, System.Object>;

	public class ShootingGame : Unit
	{
		public static readonly ShootingGame Instance = new ShootingGame();

		const string NAME = "ShootingGame";
		const string TITEL_KEY = "Title";
		public string Title { set; get; }
		public Stage GetStage(int number)
		{
			foreach(var u in Units)
			{
				Stage s = u as Stage;
				if (s != null && s.Number == number) return s;
			}
			return null;
		}

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null && !h.ContainsKey(CLASS_KEY) && h[CLASS_KEY].ToString() != NAME) return null;

			ShootingGame i = new ShootingGame();
			i.Title = RetrieveString(h, TITEL_KEY);
			i.Units = RetrieveUnits(h, UNITS_KEY, Stage.Instance);
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

	public class Stage : Unit
	{
		public static readonly Stage Instance = new Stage();

		const string NAME = "Stage";
		const string NUMBER_KEY = "Number";
		public int Number { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null && !h.ContainsKey(CLASS_KEY) && h[CLASS_KEY].ToString() != NAME) return null;
			
			Stage i = new Stage();
			i.Number = RetrieveInt(h, NUMBER_KEY);
			i.Units = RetrieveUnits(h, UNITS_KEY, Timeline.Instance);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { {CLASS_KEY, NAME}, {NUMBER_KEY, Number} };
			h[UNITS_KEY] = Units2Hash();
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Number + "]"; }
	}

	public class Timeline : Unit
	{
		public static readonly Timeline Instance = new Timeline();

		const string NAME = "Timeline";
		const string SECOND_KEY = "Second";
		public float Second { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null && !h.ContainsKey(CLASS_KEY) && h[CLASS_KEY].ToString() != NAME) return null;

			Timeline i = new Timeline();
			i.Second = RetrieveFloat(h, SECOND_KEY);
			i.Units = RetrieveUnits(h, UNITS_KEY, Enemy.Instance);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { SECOND_KEY, Second } };
			h[UNITS_KEY] = Units2Hash();
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Second + "]"; }
	}

	public class Enemy : Unit
	{
		public static readonly Enemy Instance = new Enemy();

		const string NAME = "Enemy";
		const string BREED_KEY = "Breed";
		public string Breed { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null && !h.ContainsKey(CLASS_KEY) && h[CLASS_KEY].ToString() != NAME) return null;

			Enemy i = new Enemy();
			i.Breed = RetrieveString(h, BREED_KEY);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { BREED_KEY, Breed } };
			h[UNITS_KEY] = Units2Hash();
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Breed + "]"; }
	}
}
