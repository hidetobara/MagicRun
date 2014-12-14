using UnityEngine;
using System.Collections;

public class BallHandler : MonoBehaviour
{
	private UI2DSprite _Sprite;

    void Start()
    {
		_Sprite = gameObject.GetComponent<UI2DSprite>();
		StartCoroutine(Fading(3.0f));
    }

    IEnumerator Fading(float sec)
    {
        while (sec > 0)
        {
			if (sec < 1)
			{
				_Sprite.color = new Color(sec, sec, sec, sec);
			}
			sec -= Time.deltaTime;
			yield return 0;
        }
		DestroyImmediate(this.gameObject);
    }
}
