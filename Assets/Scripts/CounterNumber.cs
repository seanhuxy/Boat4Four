using UnityEngine;
using System.Collections;

public class CounterNumber : MonoBehaviour {
	SpriteRenderer render;
	// Use this for initialization
	void Start () {
		render = GetComponent<SpriteRenderer>();
	}
	
	public float FadeoutInterval;
	float fadeout_count = 0;
	void Update () {
		float s = 1 + 1 * (fadeout_count / FadeoutInterval);
		transform.localScale = new Vector3(s, s, 1);
		
		float a = 0.3f - 0.3f * (fadeout_count / FadeoutInterval);
		render.color = new Color(1, 1, 1, a);
		
		fadeout_count += Time.deltaTime;
		if(fadeout_count >= FadeoutInterval) {
			GameObject.Destroy(gameObject);
		}
	}
}
