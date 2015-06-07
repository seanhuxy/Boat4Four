using UnityEngine;
using System.Collections;

public class CounterEmmiter : MonoBehaviour {
	void Start() {

		sprites = new Sprite[Numbers.Length];
		for(int i = 0; i < Numbers.Length; i++) {
			sprites[i] = Numbers[i].GetComponent<SpriteRenderer>().sprite;
		}
	}

	public void OnBegin(){
		this.enabled = true;
	}

	public float GenerateInterval;
	float generate_counter = -0.5f;
	void Update () {
		if(count > Numbers.Length) {
			render.sprite = null;
			return;
		}
			 
		generate_counter += Time.deltaTime;
		if(generate_counter >= GenerateInterval) {
			generate_counter-= GenerateInterval;
			if(count < Numbers.Length) {
				emmit();
			}
			count++;
			if(count > Numbers.Length) {
				OnGo();
			}
		}
	}

	public SpriteRenderer render;
	public GameObject[] Numbers;
	Sprite[] sprites;
	int count = 0;
	public Vector3 generate_offset;
	void emmit() {
		GameObject number = GameObject.Instantiate(Numbers[count], transform.position, Quaternion.identity) as GameObject;
		number.transform.SetParent(transform);
		number.transform.localPosition = Vector3.zero;
		number.transform.localRotation = Quaternion.identity;
		number.SetActive(true);

		render.sprite = sprites[count];
	}

	public void OnGo() {
		print ("GOGOGO");

		GameObject.Find ("Boat").GetComponent<Boat>().OnBegin ();
		GameObject.Find ("TimeText").GetComponent<UpdateTime>().OnBegin ();
	}
}
