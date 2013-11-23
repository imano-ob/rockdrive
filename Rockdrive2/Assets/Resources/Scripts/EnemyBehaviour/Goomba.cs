using UnityEngine;
using System.Collections;

public class Goomba : MonoBehaviour {
	
	CharacterMotor motor;
	CharacterController controller;
	public float speed;
	public bool moveRight=true;
	public GameObject player;
	bool activated=false;
	// Use this for initialization
	void Start () {
		motor= gameObject.GetComponent("CharacterMotor")as CharacterMotor;
		controller= gameObject.GetComponent("CharacterController")as CharacterController;
		if(moveRight==true)
				BroadcastMessage("changeState","right");
		else
				BroadcastMessage("changeState","left");
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.renderer.isVisible){
			if(moveRight==true){
				//Debug.Log("AAAAAA");
				//motor.inputMoveDirection=new Vector3(speed,5,5);
				if(motor.IsGrounded()==true)motor.SetVelocity(new Vector3(-speed,motor.movement.velocity.y,motor.movement.velocity.z));
				
				
			}else
				if(motor.IsGrounded()==true)motor.SetVelocity(new Vector3(speed,motor.movement.velocity.y,motor.movement.velocity.z));
		}
	}
}
