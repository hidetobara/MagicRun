﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Chunker
{
	public class Chunk
	{
		const string HEADER = "CHNK";
		public Dictionary<string, Resource> Table = new Dictionary<string, Resource>();

		public static Chunk Merge(params Chunk[] cs)
		{
			Chunk i = new Chunk();
			foreach (var c in cs)
			{
				foreach (var r in c.Table.Values) i.Table[r.Name] = r;
			}
			return i;
		}

		public bool Save(string path)
		{
			BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create));
			writer.Write(StringToBytes(HEADER));

			foreach (var pair in this.Table.Values)
			{
				Write(writer, pair.Name);

				try
				{
					switch (pair.Extension)
					{
						case ".json":
							Write(writer, Json.Serialize(pair.Body));
							break;
						default:
							Write(writer, pair.Body as byte[]);
							break;
					}
				}
				catch (Exception ex)
				{
					Write(writer, ex.Message);
				}
			}
			writer.Close();
			return true;
		}

		private static byte[] StringToBytes(string s) { return Encoding.UTF8.GetBytes(s); }
		private static string BytesToString(byte[] bs) { return Encoding.UTF8.GetString(bs); }

		private void Write(BinaryWriter w, string v)
		{
			if (string.IsNullOrEmpty(v))
			{
				w.Write(0);
				return;
			}
			byte[] bytes = StringToBytes(v);
			w.Write(bytes.Length);
			w.Write(bytes);
		}
		private void Write(BinaryWriter w, byte[] bs)
		{
			if(bs == null || bs.Length == 0)
			{
				w.Write(0);
				return;
			}
			w.Write(bs.Length);
			w.Write(bs);
		}

		public static Chunk Load(byte[] bytes)
		{
			if (bytes == null || bytes.Length == 0) return null;

			try
			{
				return Load(new BinaryReader(new MemoryStream(bytes)));
			}
			catch(Exception ex)
			{
				return null;
			}
		}

		public static Chunk Load(string path)
		{
			if (!File.Exists(path)) return null;

			try
			{
				using (FileStream s = File.OpenRead(path))
				{
					return Load(new BinaryReader(s));
				}
			}
			catch(Exception ex)
			{
				return null;
			}
		}

		private static Chunk Load(BinaryReader reader)
		{
			Chunk c = new Chunk();
			try
			{
				byte[] bytes = reader.ReadBytes(4);
				string header = Encoding.UTF8.GetString(bytes);
				if (header != HEADER) return null;

				while (true)
				{
					if (reader.BaseStream.Position >= reader.BaseStream.Length) break;	// 終了
					Resource r = new Resource();
					r.Name = ReadString(reader);
					switch (r.Extension)
					{
						case ".json":
							r.Body = Json.Deserialize(ReadString(reader));
							break;
						default:
							r.Body = ReadBytes(reader);
							break;
					}
					c.Table[r.Name] = r;
				}
			}
			catch (Exception ex)
			{
			}
			return c;
		}

		private static string ReadString(BinaryReader r)
		{
			int length = r.ReadInt32();
			if (length <= 0) return null;

			byte[] bytes = r.ReadBytes(length);
			return Encoding.UTF8.GetString(bytes);
		}
		private static byte[] ReadBytes(BinaryReader r)
		{
			int length = r.ReadInt32();
			if (length <= 0) return null;

			return r.ReadBytes(length);
		}

		public Chunk Cutout(params string[] names)
		{
			Chunk i = new Chunk();
			foreach(string name in names)
			{
				if(Table.ContainsKey(name))
				{
					Resource r = Table[name];
					Table.Remove(name);
					i.Table[name] = r;
				}
			}
			return i;
		}

		public Resource AddBytes(string filename, byte[] bytes)
		{
			Resource r = new Resource();
			r.Name = filename;
			switch (r.Extension)
			{
				case ".json":
					r.Body = Json.Deserialize(BytesToString(bytes));
					break;
				default:
					r.Body = bytes;
					break;
			}
			Table[r.Name] = r;
			return r;
		}
		public Resource AddFile(string path)
		{
			if (!File.Exists(path)) return null;

			string filename = Path.GetFileName(path);
			FileStream s = new FileStream(path, FileMode.Open);
			byte[] bytes = new byte[s.Length];
			s.Read(bytes, 0, bytes.Length);
			s.Close();
			Resource r = AddBytes(filename, bytes);
			return r;
		}
		public Resource AddObject(string name, Object o)
		{
			Resource r = new Resource();
			r.Name = name;
			r.Body = o;
			Table[r.Name] = r;
			return r;
		}

		public Resource Get(string name)
		{
			if (!Table.ContainsKey(name)) return null;
			return Table[name];
		}

		public void Remove(string name)
		{
			Table.Remove(name);
		}
	}

	public class Resource
	{
		public string Name { set; get; }
		public string Extension { get { return Path.GetExtension(Name); } }

		public System.Object Body;
	}
}
