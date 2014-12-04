using UnityEngine;
using System.Collections;

public class FireHandler : MonoBehaviour
{
	UI2DSprite _Sprite;

	public Sprite[] Sprites;
	public int Life;

	// Use this for initialization
	void Start()
	{
		_Sprite = GetComponent<UI2DSprite>();
		StartCoroutine(Firing(0.25f, 1.25f));
	}

	void Update()
	{
		if (Sprites.Length > 0)
		{
			_Sprite.sprite2D = Sprites[(int)(Time.timeSinceLevelLoad * 5) % Sprites.Length];
		}
	}

	IEnumerator Firing(float living, float waiting)
	{
		yield return new WaitForSeconds(living);

		if (Life > 0)
		{
			GameObject go = Instantiate(Resources.Load("FirePrefab")) as GameObject;
			FireHandler h = go.GetComponent<FireHandler>();
			h.Life = this.Life - 1;
			go.transform.parent = this.transform.parent;
			go.transform.localScale = Vector3.one;
			go.transform.localPosition = this.transform.localPosition + new Vector3(0, 30.0f, 0);
		}

		yield return new WaitForSeconds(waiting);

		float fading = 1.0f;
		collider2D.enabled = false;
		while(fading > 0)
		{
			_Sprite.color = new Color(fading, fading, fading, fading);
			fading -= Time.deltaTime;
			yield return 0;
		}
		DestroyImmediate(this.gameObject);
	}
}
