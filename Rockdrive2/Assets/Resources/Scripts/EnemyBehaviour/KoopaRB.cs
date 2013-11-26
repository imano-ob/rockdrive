using UnityEngine;
using System.Collections;

public class KoopaRB : MonoBehaviour {
	
	CharacterMotor motor;
	CharacterController controller;
	
	public Rigidbody body;
	public float speed;
	float distToGround;
	public bool moveRight=true;
	GameObject player;
	BoxCollider collider;
	bool activated=false;
	// Use this for initialization
	void Start () {
		//motor= gameObject.GetComponent("CharacterMotor")as CharacterMotor;
		Physics.IgnoreCollision(GameObject.Find("Player").collider,gameObject.collider);
		//controller= gameObject.GetComponent("CharacterController")as CharacterController;
		body= gameObject.GetComponent("Rigidbody")as Rigidbody;
		collider= gameObject.GetComponent("BoxCollider") as BoxCollider;
		distToGround = collider.bounds.extents.y;
		player= GameObject.Find("Player");
		if(moveRight==true)
				BroadcastMessage("changeState","right");
		else
				BroadcastMessage("changeState","left");
	}
	
	public bool IsGrounded(){
		//Debug.Log(Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f));
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.renderer.isVisible){
			if(player.transform.position.x> transform.position.x && moveRight==true){
				moveRight=false;
				BroadcastMessage("changeState","left");
			}
			
			if(player.transform.position.x< transform.position.x && moveRight==false){
				moveRight=true;
				BroadcastMessage("changeState","right");
			}
			
			if(moveRight==true){
			
				if(IsGrounded()== true){
				//if(body.==true){
					Debug.Log("AAA");
					//motor.SetVelocity(new Vector3(-speed,motor.movement.velocity.y,motor.movement.velocity.z));
					//body.AddForce(Vector3.left*speed);
					body.velocity=new Vector3(-speed,body.velocity.y,body.velocity.z);
					//body.
				}
				
			}else
				if(IsGrounded()==true){
				//motor.SetVelocity(new Vector3(speed,motor.movement.velocity.y,motor.movement.velocity.z));
				//body.AddForce(new Vector3(-speed,0,0));
				//body.AddForce(Vector3.left*speed);
				body.velocity=new Vector3(speed,body.velocity.y,body.velocity.z);
			}
		}
	}
}
