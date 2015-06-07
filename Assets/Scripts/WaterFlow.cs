using UnityEngine;
using System.Collections;

public class WaterFlow : MonoBehaviour {
	SpriteRenderer render;
	// Use this for initialization
	void Start () {
		fadeout_count = FadeoutInterval;
		render = GetComponent<SpriteRenderer>();
	}
	
	public float FadeoutInterval;
	public float Speed;
	float fadeout_count;
	void Update () {
		float s = 0.1f + 0.4f * (fadeout_count / FadeoutInterval);
		transform.localScale = new Vector3(s, s, 1);

		float a = 0 + 0.2f * (fadeout_count / FadeoutInterval);
		render.color = new Color(1, 1, 1, a);

		transform.position += new Vector3(0, 1, 0) * Time.deltaTime * Speed;

		fadeout_count -= Time.deltaTime;
		if(fadeout_count <= 0) {
			GameObject.Destroy(gameObject);
		}
	}
}
