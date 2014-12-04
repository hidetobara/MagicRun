using System;
using System.Collections.Generic;
using System.Text;


namespace Scenario
{
	public class Unit
	{
		public const string CLASS_KEY = "Class";
		public const string UNITS_KEY = "Units";

		public List<Unit> Units = new List<Unit>();

		public virtual Unit Parse(System.Object o)
		{
			return null;
		}

		public virtual System.Object ToHash() { return null; }
		public virtual string ToString() { return "[Unit]"; }

		public void Add(Unit u) { if (u != null) Units.Add(u); }

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

		protected List<System.Object> Units2Hash()
		{
			List<System.Object> list = new List<System.Object>();
			foreach (var u in Units) { var o = u.ToHash(); if (o != null) list.Add(o); }
			return list;
		}

		protected List<Unit> RetrieveUnits(Dictionary<string, System.Object> hash, string name, params Unit[] instances)
		{
			List<Unit> units = new List<Unit>();

			if (!hash.ContainsKey(name) || hash[name] == null) return units;
			List<System.Object> list = hash[name] as List<System.Object>;
			if (list == null) return units;

			foreach (var o in list)
			{
				foreach (var i in instances) { var u = i.Parse(o); if (u != null) units.Add(u); }
			}
			return units;
		}
	}
}
