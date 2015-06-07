using UnityEngine;
using System.Collections;

public class ReachFinishFlag : MonoBehaviour {

	//GameObject boat;

	EdgeCollider2D collider;

	// Use this for initialization
	void Start () {
		//boat = GameObject.Find ("Boat");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D collider){

		print ("finished");

		GameObject.Find ("Boat").GetComponent<Boat>().OnFinish ();
		GameObject.Find ("TimeText").GetComponent<UpdateTime> ().OnFinish ();

		GetComponent<AudioSource> ().Play ();
		GameObject.Find ("BGM").GetComponent<AudioSource> ().Stop ();
		//isFinished = true;
	}
}
