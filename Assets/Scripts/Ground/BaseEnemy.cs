using UnityEngine;
using System.Collections;
using Scenario;
using Scenario.Shooting;


public class BaseEnemy : MonoBehaviour
{
	protected Vector3 _CurrentPosition { set { transform.localPosition = value; } get { return transform.localPosition; } }
	protected EnemyManager _Manager;
	protected UI2DSprite _Sprite;

	protected float _Second;
	protected Enemy _Emeny;
	public Enemy Enemey { get { return _Emeny; } }

	public Vector3 Position { get { return transform.localPosition; } }
	public Vector3 FirstPosition
	{
		set
		{
			foreach (Unit u in _Emeny.Units) { ActMove m = u as ActMove; if (m != null && m.IsFirst()) { m.Move = value; return; } }
			_Emeny.Add(new ActMove(value));
		}
		get
		{
			foreach (Unit u in _Emeny.Units) { ActMove m = u as ActMove; if (m != null && m.IsFirst()) return m.Move; }
			return Vector3.zero;
		}
	}

	public virtual void Birth(EnemyManager m, Enemy e)
	{
		_Manager = m;
		_Emeny = e;
		_Sprite = GetComponent<UI2DSprite>();

		gameObject.layer = Define.ENEMY_LAYER;
		transform.localScale = Vector3.one;
		transform.localPosition = FirstPosition;
	}

	public virtual void DieSoon()
	{
		DestroyImmediate(this.gameObject);
	}
	public virtual void Die()
	{
		StartCoroutine(Dying(1.0f));
	}

	public virtual void Update()
	{
		float start = _Second;
		float end = _Second + Time.deltaTime;

		Act a = GetComingAct(start, end);
		if (a != null && a is ActMove) StartCoroutine(Moving(a as ActMove));

		_Second = end;
	}

	protected Act GetComingAct(float start, float end)
	{
		Act ret = null;
		foreach(Unit u in _Emeny.Units)
		{
			Act a = u as Act;
			if (a == null) continue;
			if (start <= a.Start && a.Start < end) ret = a;
		}
		return ret;
	}

	protected IEnumerator Moving(ActMove act)
	{
		if (act == null) yield break;

		print(act.Start + "-" + act.End + ":" + act.Move);
		Vector3 origin = Vector3.zero;  
		if(act.Type == PositionType.RELATIVE) origin = _CurrentPosition;

		if(act.End == act.Start)
		{
			_CurrentPosition = origin + act.Move;
			//print("*" + _CurrentPosition);
			yield break;
		}

		while (_Second < act.Start) yield return 0;
		while (_Second < act.End)
		{
			float t = (_Second - act.Start) / (act.End - act.Start);
			float theta = Mathf.Sin(t * Mathf.PI * 0.5f);
			theta *= theta;
			Vector3 diff = Vector3.Lerp(Vector3.zero, act.Move, theta);
			_CurrentPosition = origin + diff;
			//print("&" + _CurrentPosition);
			yield return 0;
		}
	}

	protected IEnumerator Dying(float sec)
	{
		collider2D.enabled = false;
		while (sec > 0)
		{
			_Sprite.color = new Color(sec, sec, sec, sec);
			sec -= Time.deltaTime;
			yield return 0;
		}
		DestroyImmediate(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		_Manager.Unregister(this);
	}
}
