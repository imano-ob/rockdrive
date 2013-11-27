using UnityEngine;
using System.Collections;

public class PlayerElementalControl : MonoBehaviour {
	GameObject HUD;
	Character player;
	// Use this for initialization
	void Start () {
		HUD= GameObject.Find("HUD");
		player= gameObject.GetComponent("Character")as Character;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void updateHUD(){
	}
	
	void previousType(){
		switch(player.type){
		case 'f':
			gameObject.BroadcastMessage("changeType",'g');
			HUD.BroadcastMessage("changeType",'g');
			break;
		case 'w':
			gameObject.BroadcastMessage("changeType",'f');
			HUD.BroadcastMessage("changeType",'f');
			break;
		case 'g':
			gameObject.BroadcastMessage("changeType",'w');
			HUD.BroadcastMessage("changeType",'w');
			break;
		}
	}
	
	void nextType(){
		switch(player.type){
		case 'f':
			gameObject.BroadcastMessage("changeType",'w');
			HUD.BroadcastMessage("changeType",'w');
			break;
		case 'w':
			gameObject.BroadcastMessage("changeType",'g');
			HUD.BroadcastMessage("changeType",'g');
			break;
		case 'g':
			gameObject.BroadcastMessage("changeType",'f');
			HUD.BroadcastMessage("changeType",'f');
			break;
		}
	}
	
	
}
