﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


namespace Scenario
{
	public class Unit
	{
		public const string CLASS_KEY = "Class";
		public const string UNITS_KEY = "Units";

		public Unit Parent { get; private set; }
		private List<Unit> _Units = new List<Unit>();
		public List<Unit> Units { get { return _Units; } }

		public virtual Unit Parse(System.Object o)
		{
			return null;
		}

		public virtual System.Object ToHash() { return null; }
		public virtual string ToString() { return "[Unit]"; }

		public void Add(Unit u) { if (u == null) return; Units.Add(u); u.Parent = this; }

		protected static int RetrieveInt(Dictionary<string, System.Object> hash, string name)
		{
			if (!hash.ContainsKey(name)) return 0;
			string s = hash[name].ToString();
			if (string.IsNullOrEmpty(s)) return 0;
			int o = 0;
			int.TryParse(s, out o);
			return o;
		}

		protected static float RetrieveFloat(Dictionary<string, System.Object> hash, string name)
		{
			if (!hash.ContainsKey(name)) return 0;
			string s = hash[name].ToString();
			if (string.IsNullOrEmpty(s)) return 0;
			float o = 0;
			float.TryParse(s, out o);
			return o;
		}

		protected static string RetrieveString(Dictionary<string, System.Object> hash, string name)
		{
			if (!hash.ContainsKey(name) || hash[name] == null) return null;
			return hash[name] as string;
		}

		protected System.Object Floats2Hash(float[] floats)
		{
			if (floats == null) return null;
			if (floats.Length == 3) return floats[0] + "," + floats[1] + "," + floats[2];
			return null;
		}
		protected static float[] RetrieveFloat3(Dictionary<string, System.Object> hash, string name)
		{
			float[] floats = new float[3];
			if (!hash.ContainsKey(name)) return floats;
			string s = hash[name].ToString();
			if (string.IsNullOrEmpty(s)) return floats;

			try
			{
				string[] cells = s.Split(',');
				for (int i = 0; i < cells.Length && i < floats.Length; i++) floats[i] = float.Parse(cells[i]);
			}
			catch
			{
				return floats;
			}
			return floats;
		}

		protected static T RetrieveEnum<T>(Dictionary<string, System.Object> hash, string name)
		{
			if (!hash.ContainsKey(name)) return default(T);
			string s = hash[name].ToString();
			if(string.IsNullOrEmpty(s)) return default(T);

			foreach(var t in Enum.GetValues(typeof(T)))
			{
				if (s == t.ToString()) return (T)t;
			}
			return default(T);
		}

		protected List<System.Object> Units2Hash()
		{
			List<System.Object> list = new List<System.Object>();
			foreach (var u in Units) { var o = u.ToHash(); if (o != null) list.Add(o); }
			return list;
		}
		protected void AssignUnits(Dictionary<string, System.Object> hash, string name, params Unit[] instances)
		{
			this.Units.Clear();

			if (!hash.ContainsKey(name) || hash[name] == null) return;
			List<System.Object> list = hash[name] as List<System.Object>;
			if (list == null) return;

			foreach (var o in list)
			{
				foreach (var i in instances) { var u = i.Parse(o); if (u != null) this.Add(u); }
			}
		}

		public Unit Search<T>()
		{
			foreach(Unit u in Units)
			{
				if (u is T) return u;
				Unit uu = u.Search<T>();
				if (uu != null) return uu;
			}
			return null;
		}

		public void RemoveSelf()
		{
			if (Parent == null) return;
			Parent.Units.Remove(this);
		}
	}
}
