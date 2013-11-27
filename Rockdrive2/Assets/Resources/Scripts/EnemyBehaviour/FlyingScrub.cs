using UnityEngine;
using System.Collections;

public class FlyingScrub : MonoBehaviour {

CharacterMotor motor;
	CharacterController controller;
	public float speed;
	public bool moveRight=true;
	public GameObject player;
	bool activated=false;
	public int delay=10;
	int currentDelay;
	// Use this for initialization
	void Start () {
		player=GameObject.Find("Player");
		Physics.IgnoreCollision(player.collider,gameObject.collider);
	//	motor= gameObject.GetComponent("CharacterMotor")as CharacterMotor;
	//	controller= gameObject.GetComponent("CharacterController")as CharacterController;
		if(moveRight==true)
				BroadcastMessage("changeState","right");
		else
				BroadcastMessage("changeState","left");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		
		
		if(gameObject.renderer.isVisible){
			
			if(player.transform.position.x> transform.position.x && moveRight==true){
				moveRight=false;
				BroadcastMessage("changeState","left");
			}
			
			if(player.transform.position.x< transform.position.x && moveRight==false){
				moveRight=true;
				BroadcastMessage("changeState","right");
			}
			
			currentDelay++;
			if(delay<=currentDelay){
			currentDelay=0;	
			BroadcastMessage("Fire");
			}
		}
	}
}