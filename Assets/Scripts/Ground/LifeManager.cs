using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


class LifeManager : MonoBehaviour
{
	private static LifeManager _Instance;
	public static LifeManager Singleton()
	{
		if (_Instance == null) _Instance = FindObjectOfType<LifeManager>();
		return _Instance;
	}

	const string FULL_KEY = "heart-full";
	const string EMPTY_KEY = "heart-empty";

	public UIAtlas Atlas;
	private UIGrid Grid;

	float _Current = 5;
	float _Max = 5;
	UISprite[] _Hearts;

	private void Start()
	{
		Singleton();
		Grid = transform.GetComponentInChildren<UIGrid>();
		SetLifeMax(3);
	}

	public float GetLifeMax() { return _Max; }
	public void SetLifeMax(float life)
	{
		for (int i = 0; _Hearts != null && i < _Hearts.Length; i++) DestroyImmediate(_Hearts[i].gameObject);

		_Max = life;
		if (_Current > _Max) _Current = _Max;
		_Hearts = new UISprite[(int)life];
		for (int i = 0; i < life; i++) _Hearts[i] = AddHeart(i);
		Grid.Reposition();
		UpdateHearts();
	}

	private UISprite AddHeart(int index)
	{
		GameObject go = new GameObject("Heart" + index);
		go.transform.parent = Grid.transform;
		go.transform.localScale = Vector3.one;
		go.transform.localPosition = Vector3.zero;

		UISprite s = go.AddComponent<UISprite>();
		s.atlas = Atlas;
		s.spriteName = FULL_KEY;
		s.SetDimensions(16, 16);
		s.depth = index;
		return s;
	}

	public void Damage(float life)
	{
		_Current -= life;
		UpdateHearts();
		print("Life:" + _Current + "/" + _Max);
	}

	public void Heal(float life)
	{
		_Current += life;
		if (_Current > _Max) _Current = _Max;
		UpdateHearts();
	}

	private void UpdateHearts()
	{
		for (int i = 0; i < _Max; i++)
		{
			_Hearts[i].spriteName = (i + 1.0f <= _Current) ? FULL_KEY : EMPTY_KEY;
		}
	}

	public bool IsAlive()
	{
		return _Current > 0;
	}
}
