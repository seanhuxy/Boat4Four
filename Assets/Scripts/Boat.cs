using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

	public float deltaAngluarForce;
	public float deltaForce;
	
	public float resistance;
	public float AngularResistence;

	float mass = 1;
	float radius = 1;
	
	float velocity;
	float angularVelocity;
	
	GameObject[] players = new GameObject[4];
	GameObject foreMountain;
	GameObject backMountain;

	bool isPlaying = false;

	// Use this for initialization
	void Start () {
		velocity = 0 ;
		angularVelocity = 0;

		players[0] = GameObject.Find ("P1"); // Up Left
		players[1] = GameObject.Find ("P2"); // Up Right
		players[2] = GameObject.Find ("P3"); // Down Left
		players[3] = GameObject.Find ("P4"); // Down Right

		for (int i=0; i< players.Length; i++) {
			players[i].SetActive(false);
		}

		foreMountain = GameObject.Find ("ForeMountain");
		backMountain = GameObject.Find ("BackMountain");
	}

	public void OnDisplay(int id){
		players [id].SetActive (true);
	}

	public void OnHide(int id){
		players [id].SetActive (false);
	}

	public void OnBegin(){

		isPlaying = true;
	}

	public void OnFinish(){
		for (int i=0; i<players.Length; i++) {
			players [i].GetComponent<AnimationController> ().OnFinish ();
		}

		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

		isPlaying = false;
	}

	public void OnShake(int id, float strength){
		
		float force = 0;
		float angularForce = 0;

		if (!isPlaying)
			return;

		if (id == 0 || id == 2)
			angularForce += deltaAngluarForce * Mathf.Sqrt (strength);
		else
			angularForce -= deltaAngluarForce * Mathf.Sqrt (strength);

		force += deltaForce * Mathf.Sqrt (strength);

		players[id].GetComponent<AnimationController> ().play(true);

		velocity = (force - resistance * velocity) * Time.deltaTime / mass + velocity;
		angularVelocity = (angularForce - AngularResistence * angularVelocity) * Time.deltaTime / (mass*radius) + angularVelocity;
		
		transform.Translate( Vector3.up * Time.deltaTime * velocity);
		transform.Rotate (Vector3.forward * Time.deltaTime * angularVelocity );  // rotate to right

		foreMountain.GetComponent<MountainController> ().Rotate (angularVelocity);
		backMountain.GetComponent<MountainController> ().Rotate (angularVelocity);
	}
	
	// Update is called once per frame
	void Update () {

		float force = 0;
		float angularForce = 0;

		if (!isPlaying)
			return;

		if (Input.GetKeyDown (KeyCode.R)) {
			angularForce += deltaAngluarForce;
			force += deltaForce;
			players[0].GetComponent<AnimationController> ().play(true);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			angularForce += deltaAngluarForce;
			force += deltaForce;
			players[2].GetComponent<AnimationController> ().play(true);
		}
		if (Input.GetKeyDown (KeyCode.U)) {
			angularForce -= deltaAngluarForce;
			force += deltaForce;
			players[1].GetComponent<AnimationController> ().play(true);
		}
		if (Input.GetKeyDown (KeyCode.N)) {
			angularForce -= deltaAngluarForce;
			force += deltaForce;
			players[3].GetComponent<AnimationController> ().play(true);
		}
		velocity = (force - resistance * velocity) * Time.deltaTime / mass + velocity;
		angularVelocity = (angularForce - AngularResistence * angularVelocity) * Time.deltaTime / (mass*radius) + angularVelocity;

		transform.Translate( Vector3.up * Time.deltaTime * velocity);
		transform.Rotate (Vector3.back * Time.deltaTime * angularVelocity );  // rotate to right

		foreMountain.GetComponent<MountainController> ().Rotate (angularVelocity);
		backMountain.GetComponent<MountainController> ().Rotate (angularVelocity);
	}
}
