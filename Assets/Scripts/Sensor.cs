using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sensor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		Input.gyro.updateInterval = 0.01f;
	}

	public float Sample_Frequncy;
	private float sample_counter = 0;

	private Vector3 acc = Vector3.zero;
	private float t = 0;
	// Update is called once per frame
	void Update () {
		acc += Input.gyro.userAcceleration * Time.deltaTime;
		t += Time.deltaTime;
		
		sample_counter += Time.deltaTime;
		if (sample_counter >= 1 / Sample_Frequncy) {
			sample_counter -= 1 / Sample_Frequncy;
			if(t > 0) {
				Sample(acc, t);
				acc = Vector3.zero;
				t = 0;
			} else {
				//Sample(Vector3.zero, 0);
				acc = Vector3.zero;
				t = 0;
			}
		}
	}

	public float Threshold;
	private int last_direction = 1;
	private int Shake_Count = 0;
	public Text text;
	public void Sample(Vector3 acc, float t) {
		int direction = 0;
		if(Mathf.Abs((acc / t).x) >= Threshold) {
			if(Mathf.Sign(acc.x) > 0) {
				direction = 1;
			} else {
				direction = -1;
			}
		}
		if(direction * last_direction == -1 && direction < 0) {
			float strength = acc.magnitude / t;
			if(strength >= 1) {
				OnShake(strength);
			}
		}
		last_direction = direction;
	}

	public Client client;
	public void OnShake(float strength) {
		Shake_Count++;
		text.text = Shake_Count + "";

		client.message(strength);
	}
}
