using UnityEngine;
using System.Collections;

public class MegaCamera : MonoBehaviour {
	public Vector3 distance;
	public GameObject target;
	PlayerStateControl playerstate;
	public float maxDistY=2f;
	public float maxDistX=2f;
	public float calc;
	bool lastGrounded=true;
	float lastGround;
	CharacterController controller;
	// Use this for initialization
	void Start () {
		controller= target.GetComponent("CharacterController")as CharacterController;
		playerstate= target.GetComponent("PlayerStateControl")as PlayerStateControl;
		gameObject.transform.position= target.transform.position+ distance;
	}	
	
	// Update is called once per frame
	void Update () {
		//calc= (target.transform.position.y)-transform.position.y;
		calc= (target.transform.position.y)-lastGround;
		if(controller.isGrounded==true){
			lastGround= transform.position.y;
			gameObject.transform.position= new Vector3(target.transform.position.x+distance.x,gameObject.transform.position.y,target.transform.position.z+distance.z);
			gameObject.transform.position= Vector3.Lerp(gameObject.transform.position,new Vector3(target.transform.position.x+distance.x,target.transform.position.y+distance.y,target.transform.position.z+distance.z),0.3f);
			
			
			//gameObject.transform.position= target.transform.position+ distance;
		}else{
			//HIGH JUMP
			if(calc<maxDistY){
				gameObject.transform.position= new Vector3(target.transform.position.x+distance.x,transform.position.y,target.transform.position.z+distance.z);
				gameObject.transform.position= Vector3.Lerp(gameObject.transform.position,new Vector3(transform.position.x,target.transform.position.y+distance.y,transform.position.z),0.5f);
			}//gameObject.transform.position= new Vector3(target.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
			else
				//gameObject.transform.position= target.transform.position+ distance;
				//LOW JUMP
				Debug.Log("low");
				gameObject.transform.position= new Vector3(target.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
			//gameObject.transform.position= new Vector3(target.transform.position.x,lastGround,gameObject.transform.position.z);
		}
		lastGrounded= playerstate.grounded;
	}
}
