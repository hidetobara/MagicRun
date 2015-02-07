using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using UnityEngine;


namespace Scenario.Shooting
{
	using Array = List<System.Object>;
	using Hash = Dictionary<string, System.Object>;

	public enum PositionType { ABSOLUTE, RELATIVE }

	public class Shooting : Unit
	{
		public static readonly Shooting Instance = new Shooting();

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
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			Shooting i = new Shooting();
			i.Title = RetrieveString(h, TITEL_KEY);
			i.AssignUnits(h, UNITS_KEY, Stage.Instance);
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
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;
			
			var i = new Stage();
			i.Number = RetrieveInt(h, NUMBER_KEY);
			i.AssignUnits(h, UNITS_KEY, Timeline.Instance);
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
		const string SECOND_KEY = "Time";
		public float Time { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			var i = new Timeline();
			i.Time = RetrieveFloat(h, SECOND_KEY);
			i.AssignUnits(h, UNITS_KEY, Enemy.Instance);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { SECOND_KEY, Time } };
			h[UNITS_KEY] = Units2Hash();
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Time + "]"; }
	}

	public class Enemy : Unit
	{
		public static readonly Enemy Instance = new Enemy();

		const string NAME = "Enemy";
		const string BREED_KEY = "Breed";
		const string LABEL_KEY = "Label";
		const string REFERENCE_KEY = "Reference";
		public string Breed { set; get; }
		public string Label { set; get; }
		public string Reference { set; get; }

		public Enemy() { }
		public Enemy(Vector3 p)
		{
			ActMove m = new ActMove(p);
			Add(m);
		}

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			var i = new Enemy();
			i.Breed = RetrieveString(h, BREED_KEY);
			i.Label = RetrieveString(h, LABEL_KEY);
			i.Reference = RetrieveString(h, REFERENCE_KEY);
			i.AssignUnits(h, UNITS_KEY, ActMove.Instance, ActFire.Instance);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { BREED_KEY, Breed } };
			if (!string.IsNullOrEmpty(Label)) h[LABEL_KEY] = Label;
			if (!string.IsNullOrEmpty(Reference)) h[REFERENCE_KEY] = Reference;
			h[UNITS_KEY] = Units2Hash();
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Breed + "]"; }
	}

	public class Act : Unit
	{
		protected const string START_KEY = "Start";
		protected const string END_KEY = "End";

		[Category("Time")]
		public float Start { set; get; }
		[Category("Time")]
		public float End { set; get; }

		protected void RetrieveStartEnd(Hash h)
		{
			this.Start = RetrieveFloat(h, START_KEY);
			this.End = RetrieveFloat(h, END_KEY);
		}

		protected void InsertStartEnd(Hash h)
		{
			h[START_KEY] = this.Start;
			h[END_KEY] = this.End;
		}
	}

	public class ActMove : Act
	{
		public static readonly ActMove Instance = new ActMove();

		const string NAME = "Move";
		const string TYPE_KEY = "Type";
		const string MOVE_KEY = "Move";
		public PositionType Type { set; get; }
		public float[] _Move { set; get; }
		public Vector3 Move
		{
			set { _Move[0] = value.x; _Move[1] = value.y; _Move[2] = value.z; }
			get { return new Vector3(_Move[0], _Move[1], _Move[2]); }
		}

		public bool IsFirst() { return Start == 0 && End == 0 && Type == PositionType.ABSOLUTE; }

		public ActMove()
		{
			_Move = new float[3];
		}
		public ActMove(Vector3 p) : this()
		{
			_Move[0] = p.x; _Move[1] = p.y; _Move[2] = p.z;
			Type = PositionType.ABSOLUTE;
		}

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			var i = new ActMove();
			i.Type = RetrieveEnum<PositionType>(h, TYPE_KEY);
			i._Move = RetrieveFloat3(h, MOVE_KEY);
			i.RetrieveStartEnd(h);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { TYPE_KEY, Type.ToString() } };
			h[MOVE_KEY] = Floats2Hash(_Move);
			InsertStartEnd(h);
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Move + "]"; }
	}

	public class ActFire : Act
	{
		public static readonly ActFire Instance = new ActFire();

		const string NAME = "Fire";
		const string WEAPON_KEY = "Weapon";
		public string Weapon { set; get; }

		public override Unit Parse(System.Object o)
		{
			Hash h = o as Hash;
			if (h == null || !h.ContainsKey(CLASS_KEY) || h[CLASS_KEY].ToString() != NAME) return null;

			var i = new ActFire();
			i.Weapon = RetrieveString(h, WEAPON_KEY);
			i.RetrieveStartEnd(h);
			return i;
		}

		public override System.Object ToHash()
		{
			Hash h = new Hash() { { CLASS_KEY, NAME }, { WEAPON_KEY, Weapon } };
			InsertStartEnd(h);
			return h;
		}
		public override string ToString() { return "[" + NAME + ":" + Weapon + "]"; }
	}
}
