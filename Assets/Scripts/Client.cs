using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Client : MonoBehaviour {
	public InputField IP;
	int PORT = 2234;
	
	public NetworkView nv;
	void Start() {
		ConnectToServer ();
		Input.gyro.enabled = true;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	
	public void ConnectToServer() {
		print("正在连接到服务器。");
		NetworkConnectionError error = Network.Connect (IP.text, PORT);
		//连接状态
		switch(error){
		case NetworkConnectionError.NoError:
			try {
				print("连接成功。");
			} catch (Exception e) {
				print("发生异常：" + e.ToString());
			}
			break;
		default:
			print("连接错误：" + error);
			break;
		}
	}
	
	public void Reconnect() {
		ConnectToServer ();
	}

	public void Disconnect() {
		Network.Disconnect ();
	}
	
	public void message(float strength) {
		switch (Network.peerType) {
		case NetworkPeerType.Client :
			nv.RPC("OnClientShake", RPCMode.Server, ID, strength);
			break;
		default:
			break;
		}
	}

	public int ID = -1;
	[RPC]  
	void ConnectedToServer(string msg, int ID, NetworkMessageInfo info){
		if(msg == Network.player.guid) {
			//Handheld.Vibrate ();
			this.ID = ID;
			Choose(ID);
		}
	}

	[RPC]  
	void DisconnectedToServer(string msg, int ID, NetworkMessageInfo info){
		if(msg == Network.player.guid) {
			//Handheld.Vibrate ();
			this.ID = -1;
			Choose(ID);
		}
	}

	public GameObject NullImage;
	public GameObject P0Image;
	public GameObject P1Image;
	public GameObject P2Image;
	public GameObject P3Image;
	void Choose(int ID) {
		switch(ID) {
		case 0:
			NullImage.SetActive(false);
			P0Image.SetActive(true);
			P1Image.SetActive(false);
			P2Image.SetActive(false);
			P3Image.SetActive(false);
			break;
		case 1:
			NullImage.SetActive(false);
			P0Image.SetActive(false);
			P1Image.SetActive(true);
			P2Image.SetActive(false);
			P3Image.SetActive(false);
			break;
		case 2:
			NullImage.SetActive(false);
			P0Image.SetActive(false);
			P1Image.SetActive(false);
			P2Image.SetActive(true);
			P3Image.SetActive(false);
			break;
		case 3:
			NullImage.SetActive(false);
			P0Image.SetActive(false);
			P1Image.SetActive(false);
			P2Image.SetActive(false);
			P3Image.SetActive(true);
			break;
		default:
			NullImage.SetActive(true);
			P0Image.SetActive(false);
			P1Image.SetActive(false);
			P2Image.SetActive(false);
			P3Image.SetActive(false);
			break;
		}
	}

	void OnDisconnectedFromServer(NetworkDisconnection info) {
		//Handheld.Vibrate ();
		//this.ID = -1;
	}
}
