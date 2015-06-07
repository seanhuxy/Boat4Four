using UnityEngine;
using System.Collections;

public class RiverCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		GameObject.Find ("Camera").GetComponent<CameraShaker> ().Shake ();
	}

	void OnCollisionStay2D(Collision2D collision){
		GameObject.Find ("Camera").GetComponent<CameraShaker> ().Shake ();
	}
}
