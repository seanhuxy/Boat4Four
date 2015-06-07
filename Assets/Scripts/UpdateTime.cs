using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateTime : MonoBehaviour {

	Text timeText;
	float startTime;
	//Time passedTime;

	bool isPlaying;

	public void OnBegin(){
		isPlaying = true;
		startTime = Time.realtimeSinceStartup;
	}

	public void OnFinish(){
		isPlaying = false;
	}

	// Use this for initialization
	void Start () {
		isPlaying = false;
		timeText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isPlaying)
			return;

		float passedTime = Time.realtimeSinceStartup - startTime;

		int ms = (int)(passedTime * 100) % 100;
		int sc = (int)passedTime % 60;
		int min = (int)passedTime / 60;

		string text = "";

		if (min < 10)
			text += "0" + min;
		else
			text += min;

		text += " : ";

		if (sc < 10)
			text += "0" + sc;
		else
			text += sc;

		text += " : ";

		if (ms < 10)
			text += "0" + ms;
		else
			text += ms;

		timeText.text = text;
	}
}
