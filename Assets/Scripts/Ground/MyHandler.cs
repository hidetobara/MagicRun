using UnityEngine;
using System.Collections;

public class MyHandler : MonoBehaviour
{
	private PowerHandler _Power;
	private FingerStatus _Finger;

	public GameObject BallPanel;
    public GameObject Ball;

    void Start()
    {
		_Finger = new FingerStatus();
		_Power = new PowerHandler(this.gameObject);
		_Power.PowerColor = new Color(1.0f, 0.5f, 0.5f);
		_Power.Stop();

		StartCoroutine(Firing(1.0f));
    }

    void Update()
    {
		if (_Finger.IsPressed)
		{
			_Finger.Time += Time.deltaTime;
			if (_Finger.IsChargedStand) _Power.Fire();
		}
    }

	private float _PressTime;
	private Vector2 _Move;
	void OnPress(bool press)
	{
		if(press)
		{
			_Finger.Press();
			_Power.Load();
		}
		else
		{
			if (_Finger.IsChargedStand)
			{
				GameObject go = Instantiate(Resources.Load("FirePrefab")) as GameObject;
				FireHandler h = go.GetComponent<FireHandler>();
				h.Life = 20;
				AdjustGameObject(go, Vector3.zero);
			}
			_Finger.Clear();
			_Power.Stop();
		}
	}

	void OnDrag(Vector2 delta)
	{
		_Finger.Move += delta;
		if (_Finger.IsMoving) _Power.Stop();
	}

    IEnumerator Firing(float sec)
    {
        while(true)
        {
            GameObject go = Instantiate(Ball) as GameObject;
			AdjustGameObject(go, Vector3.zero);
            go.rigidbody2D.velocity = new Vector2(0, 1);
            yield return new WaitForSeconds(sec);
        }
    }

	private void AdjustGameObject(GameObject go, Vector3 p)
	{
		go.transform.parent = BallPanel.transform;
		go.transform.localScale = Vector3.one;
		go.transform.localPosition = this.transform.localPosition + p;
	}

	class PowerHandler
	{
		ParticleSystem _Particle;
		public PowerHandler(GameObject o)
		{
			_Particle = o.GetComponentInChildren<ParticleSystem>();
		}
		public Color PowerColor{ set { _Particle.startColor = value;} }
		public void Stop() { _Particle.Stop(); _Particle.Clear(); }
		public void Load() { _Particle.startSpeed = 0.2f; _Particle.startSize = 0.2f; if (!_Particle.isPlaying) _Particle.Play(); }
		public void Fire() { _Particle.startSpeed = 0.5f; _Particle.startSize = 0.5f; if (!_Particle.isPlaying) _Particle.Play(); }
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
