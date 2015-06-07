using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartScript : MonoBehaviour {


	GameObject GameUI;

	Text IPText;

	bool[] isConnected;

	GameObject boat;

	// Use this for initialization
	void Start () {

		GameUI = GameObject.Find ("GameUI");
		GameUI.SetActive (false);

		boat = GameObject.Find ("Boat");

		string ipaddr = Network.player.ipAddress;

		IPText = GameObject.Find ("IPText").GetComponent<Text>();
		IPText.text = "Serving:\n"+ipaddr;

		isConnected = new bool[4];
		for (int i=0; i<isConnected.Length; i++) {
			isConnected [i] = false;
		}
	}

	public void OnClientConnected(int id){

		isConnected [id] = true;
		boat.GetComponent<Boat> ().OnDisplay (id);

		print ("OnClient Connected");

		//bool isAllConnected = true;
		for (int i=0; i<isConnected.Length; i++) {
			if( isConnected[i] == false){
				//isAllConnected = false;
				return;
			}
		}

		// all connected
		OnBegin();
	}

	public void OnBegin(){
		GameObject.Find ("Counter").GetComponent<CounterEmmiter> ().OnBegin ();
		GameObject.Find ("CameraCarrier").GetComponent<SmartFollower> ().OnBegin ();
		GameUI.SetActive (true);
		gameObject.SetActive (false);
	}

	public void OnClientDisconnected(int id){
		isConnected [id] = false;
		boat.GetComponent<Boat> ().OnHide (id);
	}


	bool first = false;
	// Update is called once per frame
	void Update () {

		if (first) {
			OnClientConnected (0);
			OnClientConnected (1);
			OnClientConnected (2);
			OnClientConnected (3);
		}
	
	}
}
