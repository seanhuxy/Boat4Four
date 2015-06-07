using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//timeout_count = TimeOut;
	}

	public float R;
	float r = 0;
	float a = 0;
	float shake_x = 0;
	float shake_y = 0;
	public float TimeOut;
	float timeout_count = 0;
	public void Shake() {
		if(timeout_count == 0) {
			r = R;
			timeout_count = TimeOut;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space)) {
			Shake();
		}

		timeout_count -= Time.deltaTime;
		timeout_count = Mathf.Max(timeout_count, 0);

		r -= Time.deltaTime * 10;
		a += 100000 * Time.deltaTime;
		r = Mathf.Max(0, r);

		if(r == 0) {
			return;
		}
		
		shake_x = (float)Mathf.Cos(Mathf.Deg2Rad * a) * r;
		//shake_y = (float)Mathf.Sin(Mathf.Deg2Rad * a) * r;

		transform.localPosition = new Vector3(shake_x, shake_y, transform.localPosition.z);
	}
}
