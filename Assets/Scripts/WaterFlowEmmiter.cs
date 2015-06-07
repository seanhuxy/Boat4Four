using UnityEngine;
using System.Collections;

public class WaterFlowEmmiter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public float GenerateInterval;
	float generate_counter = 0;
	void Update () {
		generate_counter += Time.deltaTime;
		if(generate_counter >= GenerateInterval) {
			generate_counter-= GenerateInterval;
			generate();
		}
	}

	public GameObject Root;
	public GameObject WaterFlow;
	public Vector3 generate_offset;
	void generate() {
		GameObject water_flow = GameObject.Instantiate(WaterFlow, transform.position, Quaternion.identity) as GameObject;
		water_flow.transform.SetParent(transform.parent);
		water_flow.transform.localPosition = generate_offset;
		water_flow.transform.SetParent(Root.transform);
		water_flow.SetActive(true);
	}
}
