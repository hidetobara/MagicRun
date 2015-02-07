using System;
using System.Collections.Generic;
using UnityEngine;
using Chunker;
using System.IO;


namespace Scenario
{
	class TextureManager
	{
		static TextureManager _Instance = null;
		public static TextureManager Singleton()
		{
			if (_Instance == null) _Instance = new TextureManager();
			return _Instance;
		}

		Chunk _Chunk;
		private Dictionary<string, Texture2D> _Textures = new Dictionary<string, Texture2D>();

		public void Build(Chunk c)
		{
			_Chunk = c;
		}

		public Texture2D Get(string name)
		{
			string id = Path.GetFileNameWithoutExtension(name);
			if (_Textures.ContainsKey(id)) return _Textures[id];

			Resource r = _Chunk.Get(name);
			if (r == null) return null;
			byte[] bytes = r.Body as byte[];
			if(bytes == null) return null;

			Texture2D t = new Texture2D(4, 4);
			t.LoadImage(bytes);
			t.wrapMode = TextureWrapMode.Clamp;
			t.name = id;
			_Textures[id] = t;
			return t;
		}

		public void Clear()
		{
			foreach(Texture2D t in _Textures.Values)
			{
				MonoBehaviour.Destroy(t);
			}
			_Textures.Clear();
		}
	}
}
