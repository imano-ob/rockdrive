using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {
	public int state=0;
	public int fallDelay;
	public int returnDelay;
	Rigidbody body;
	Vector3 startPosition;
	public int currentDelay=0;
	// Use this for initialization
	void Start () {
		body= GetComponent("Rigidbody")as Rigidbody;
		startPosition= transform.position;
	}
	
	void PlayerTouch(){
		Debug.Log("WHAT");
		if(state==0)state=1;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if(state==1){
			//Debug.Log("lololol");
		currentDelay++;
		if(currentDelay>=fallDelay){
			currentDelay=0;
			state=2;
			body.useGravity=true;
			}
		}
		
		if(state==2){
		currentDelay++;
		if(currentDelay>=returnDelay){
			currentDelay=0;
			state=0;
			body.useGravity=false;
				body.velocity= new Vector3(0,0,0);
			transform.position=startPosition;
			
			}
		}
	}
}
