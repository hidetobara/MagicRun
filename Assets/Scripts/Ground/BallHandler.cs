using UnityEngine;
using System.Collections;

public class BallHandler : MonoBehaviour
{
	private UI2DSprite _Sprite;
	private float _Remain = float.MaxValue;
	public float Damage = 1.0f;

    void Start()
    {
		_Sprite = gameObject.GetComponent<UI2DSprite>();
		StartCoroutine(Fading(3.0f));
    }

	public void DecomeDying(float sec)
	{
		StartCoroutine(Fading(sec));
	}

    IEnumerator Fading(float sec)
    {
		if (_Remain < sec) yield break;
		_Remain = sec;

        while (_Remain > 0)
        {
			if (_Remain < 1)
			{
				_Sprite.color = new Color(sec, sec, sec, sec);
			}
			_Remain -= Time.deltaTime;
			yield return 0;
        }
		DestroyImmediate(this.gameObject);
    }
}
