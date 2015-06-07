using UnityEngine;
using System.Collections;

public class MountainController : MonoBehaviour {

	public float scale = 0.001f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Rotate(float angular){

		transform.Translate (Vector3.left * angular * scale);
	}
}
