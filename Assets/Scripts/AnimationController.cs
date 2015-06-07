using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	public bool isRowing;

	public float speed;
	public AudioSource audioSource;

	Animator anim;

	// Use this for initialization
	void Start () {

		isRowing = false;
		speed = 0.5f;

		anim = GetComponent<Animator> ();
		anim.speed = speed;

		audioSource = GameObject.Find ("RowingSound").GetComponent<AudioSource> ();
	}

	public void play(bool isRowing){

		if (isRowing) {
			anim.Play ("Rowing");
			audioSource.Play();
		} else {
			anim.Play ("Idle");
		}
	}

	public void OnFinish(){
		anim.Play ("TurnBack");
	}

	public void setSpeed(float speed){
		anim.speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		//anim.SetBool ("isRowing", true);

		//anim.speed = speed;

//		if (isRowing) {
//
//			anim.Play ("P1_Rowing");
//		} else {
//
//			anim.Play ("P1_Idle");
//		}
	}
}
