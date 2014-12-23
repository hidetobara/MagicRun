using UnityEngine;
using System.Collections;

public class MyHandler : MonoBehaviour
{
	private static MyHandler _Instance;
	public static MyHandler Singleton()
	{
		if (_Instance == null) _Instance = FindObjectOfType<MyHandler>();
		return _Instance;
	}

	private FingerStatus _Finger;
	private LifeManager _Life;

	public GameObject EnemyPanel;
	public GameObject FriendPanel;

	public Vector3 Position { get { return transform.parent.transform.localPosition; } }

    void Start()
    {
		Singleton();
//		gameObject.layer = Define.FRIEND_LAYER;

		_Finger = new FingerStatus();
		_Life = LifeManager.Singleton();

		StartCoroutine(Firing(1.0f));
    }

    void Update()
    {
		if (_Finger.IsPressed)
		{
			_Finger.Time += Time.deltaTime;
		}
    }

	private float _PressTime;
	private Vector2 _Move;
	void OnPress(bool press)
	{
		if(press)
		{
			_Finger.Press();
		}
		else
		{
			if (_Finger.IsChargedStand)
			{
				GameObject go = Define.InstantiateFire();
				FireHandler h = go.GetComponent<FireHandler>();
				h.Life = 20;
				AdjustGameObjectForEnemy(go, Position);
			}
			_Finger.Clear();
		}
	}

	void OnDrag(Vector2 delta)
	{
		_Finger.Move += delta;
	}

    IEnumerator Firing(float sec)
    {
        while(true)
        {
            GameObject go = Define.InstantiateBall();
			go.layer = Define.ENEMY_FIRE_LAYER;
			AdjustGameObjectForEnemy(go, Position);
            go.rigidbody2D.velocity = new Vector2(0, 1);
            yield return new WaitForSeconds(sec);
        }
    }

	public void AdjustGameObjectForFriend(GameObject go, Vector3 p)
	{
		go.transform.parent = FriendPanel.transform;
		go.transform.localScale = Vector3.one;
		go.transform.localPosition = p;
	}

	public void AdjustGameObjectForEnemy(GameObject go, Vector3 p)
	{
		go.transform.parent = EnemyPanel.transform;
		go.transform.localScale = Vector3.one;
		go.transform.localPosition = p;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		GameObject go = col.gameObject;
		BallHandler ball = go.GetComponent<BallHandler>();
		if(go.layer == Define.FRIEND_FIRE_LAYER || go.layer == Define.FRIEND_LAYER)
		{
			if(ball != null)
			{
				_Life.Damage(ball.Damage);
				ball.DecomeDying(1.0f);
			}
		}
	}

	class FingerStatus
	{
		const float CHARGE_TIME = 1.5f;

		public Vector2 Move;
		public float Time;
		public bool IsPressed;
		public void Press() { Move = Vector2.zero; Time = 0; IsPressed = true; }
		public void Clear() { IsPressed = false; }

		public bool IsMoving { get { return Vector2.Distance(Move, Vector2.zero) > 2.0f; } }
		public bool IsChargedStand { get { return IsPressed && Time > CHARGE_TIME && !IsMoving; } }
	}
}
