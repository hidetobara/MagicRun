using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Scenario.Story;


namespace Scenario
{
	public class ImagesDialog : MonoBehaviour
	{
		const int IMAGE_MAX = 10;
		Vector2 _ScreenSize = new Vector2(300, 400);

		static ImagesDialog _Instance = null;
		public static ImagesDialog Instance
		{
			get { if (_Instance == null) _Instance = FindObjectOfType<ImagesDialog>(); return _Instance; }
		}

		TextureManager _Manager;
		UITexture[] _Textures;

		void Start()
		{
			_Manager = TextureManager.Singleton();
			_Textures = new UITexture[IMAGE_MAX];

			for (int i = 0; i < IMAGE_MAX; i++)
			{
				GameObject go = new GameObject("texture" + i);
				_Textures[i] = go.AddComponent<UITexture>();
				go.transform.parent = this.transform;
				go.transform.localScale = Vector3.one;
			}
		}

		public void Setup(List<Image> list)
		{
			for (int i = 0; i < IMAGE_MAX; i++)
			{
				UITexture t = _Textures[i];
				if (i >= list.Count)
				{
					t.mainTexture = null;
					continue;
				}
				Image image = list[i];

				t.mainTexture = _Manager.Get(image.Name);
				t.SetDimensions(t.mainTexture.width, t.mainTexture.height);

				Fix fix = image.Search<Fix>() as Fix;
				if (fix != null)
				{
					t.transform.localPosition = Anchor2Vector3(fix.Origin);
					t.depth = (int)fix.Far * 10 + (int)fix.Origin;
					ModifyDimenssion(t, fix);

					Move m = fix as Move;
					if (m != null) StartCoroutine(Moving(t, m));
				}
			}
		}

		private void ModifyDimenssion(UITexture t, Fix f)
		{
			Texture texture = t.mainTexture;
			if (texture == null) return;

			if(f.Width == 0 && f.Height == 0)
			{
				t.SetDimensions((int)_ScreenSize.x, (int)_ScreenSize.y);
			}
			else if(f.Width == 0)
			{
				float h = f.Height * _ScreenSize.y;
				float w = (f.Height * _ScreenSize.x / _ScreenSize.y) * _ScreenSize.x;
				t.SetDimensions((int)w, (int)h);
			}
			else if(f.Height == 0)
			{
				float w = f.Width * _ScreenSize.x;
				float h = (f.Width * _ScreenSize.y / _ScreenSize.x) * _ScreenSize.y;
				t.SetDimensions((int)w, (int)h);
			}
			else
			{
				float w = f.Width * _ScreenSize.x;
				float h = f.Height * _ScreenSize.y;
				t.SetDimensions((int)w, (int)h);
			}
		}

		private IEnumerator Moving(UITexture texture, Move m)
		{
			Vector3 o = Anchor2Vector3(m.Origin);
			Vector3 d = Anchor2Vector3(m.Destination);
			for(float life = m.Time; life > 0; life -= Time.deltaTime)
			{
				float t = 1 - life / m.Time;
				float theta = (1 - Mathf.Cos(t * Mathf.PI)) / 2.0f;
				Vector3 p = Vector3.Lerp(o, d, theta);
				texture.transform.localPosition = p;
				yield return 0;
			}
			texture.transform.localPosition = d;
		}

		private Vector3 Anchor2Vector3(AnchorType a)
		{
			Vector3 p = Vector3.zero;
			switch (a)
			{
				case AnchorType.BOTTOM: p = new Vector3(0, -0.5f, 0); break;
				case AnchorType.FAR_BOTTOM: p = new Vector3(0, -1, 0); break;
				case AnchorType.TOP: p = new Vector3(0, 0.5f, 0); break;
				case AnchorType.FAR_TOP: p = new Vector3(0, 1, 0); break;
				case AnchorType.LEFT: p = new Vector3(-0.5f, 0, 0); break;
				case AnchorType.FAR_LEFT: p = new Vector3(-1, 0, 0); break;
				case AnchorType.RIGHT: p = new Vector3(0.5f, 0, 0); break;
				case AnchorType.FAR_RIGHT: p = new Vector3(1, 0, 0); break;
			}
			return new Vector3(_ScreenSize.x * p.x, _ScreenSize.y * p.y, 0);
		}

		public void Clear()
		{
			foreach (UITexture t in _Textures) t.mainTexture = null;
		}
	}
}