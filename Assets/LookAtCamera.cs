using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {

	public Transform camera;

	// Use this for initialization
	void Start () {

		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (camera, Vector3.back); 

		float dist = Vector3.Distance (camera.position, transform.position);

		if (dist < 200) {
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		} else if (dist < 210) {
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1 - (dist - 200) / 10);
		} else {
			GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
		}


		//transform.eulerAngles = new Vector3 (-transform.eulerAngles.x, 0, -transform.eulerAngles.z );
	}
}
