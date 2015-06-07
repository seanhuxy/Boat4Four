using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Server : MonoBehaviour {
	int PORT = 2234;

	GameObject boat;

	// Use this for initialization
	void Start () {
		StartServer ();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;

		for(int i = 0; i < 4; i++) {
			Users[i] = null;
		}

		boat = GameObject.Find ("Boat");
	}

	public void StartServer() {
		NetworkConnectionError error = Network.InitializeServer (12, PORT, false);
		
		switch(error){
		case NetworkConnectionError.NoError:
			print("服务端启动成功。");
			print("IP地址：" + Network.player.ipAddress);
			print("服务端口：" + Network.player.port);
			break;
		default:
			print("服务端启动异常: \n" + error);
			break;
		}
	}

	Dictionary<int, string> Users = new Dictionary<int, string>();
	public NetworkView nv;
	void OnPlayerConnected(NetworkPlayer player) {
		int ID = -1;
		for(int i = 0; i < 4; i++) {
			if(Users[i] == null) {
				ID = i;
				Users[i] = player.guid;
				break;
			}
		}
		if(ID != -1) {
			nv.RPC ("ConnectedToServer", RPCMode.Others, player.guid, ID);
			//print (Users[ID] + " connected as player " + ID);
			OnPlyerLogin(ID);
		}
	}

	void OnPlayerDisconnected(NetworkPlayer player) {
		int ID = -1;
		for(int i = 0; i < 4; i++) {
			if(Users[i] == player.guid) {
				ID = i;
				Users[i] = null;
				break;
			}
		}
		if(ID != -1) {
			nv.RPC ("DisconnectedToServer", RPCMode.Others, player.guid, ID);
			print (Users[ID] + " disconnected as player " + ID);
			OnPlayerLogout(ID);
		}
	}
	
	[RPC]  
	void OnClientShake(int ID, float strength, NetworkMessageInfo info){   
		print ("Player" + ID + "摇了" + strength);

		boat.GetComponent<Boat> ().OnShake (ID, strength);
	}

	public void OnPlyerLogin(int ID) {
		GameObject.Find ("StartUI").GetComponent<StartScript> ().OnClientConnected (ID);
	}

	public void OnPlayerLogout(int ID){
		GameObject.Find ("StartUI").GetComponent<StartScript> ().OnClientDisconnected (ID);
	}
}
