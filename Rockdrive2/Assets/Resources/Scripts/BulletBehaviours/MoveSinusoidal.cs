using UnityEngine;
using System.Collections;

public class MoveSinusoidal : MonoBehaviour {
	public int angle;
	public float speed=1;
	public float angularSpeed=1;
	public float amplitude=1;
	Vector3 delta,sinDelta;
	float x=0;
	Rigidbody body;
	// Use this for initialization
	void Start () {
		transform.Rotate(new Vector3(0,angle,0));
		body= gameObject.GetComponent("Rigidbody")as Rigidbody;
	}
	
	void setDirection(int val){
		angle=val;	
	}
	void setSide(bool val){
		if(val==true)angle=0;
		else angle=180;
	}
	// Update is called once per frame
	void FixedUpdate () {
		x=x+0.1f;
		sinDelta= Quaternion.Euler(0,0,angle)* new Vector3(0,amplitude*Mathf.Cos(angularSpeed*x),0);
		delta= Quaternion.Euler(0,0,angle)*(new Vector3(speed,0,0));
		body.velocity= delta+sinDelta;
		//transform.localPosition= transform.localPosition+ delta+sinDelta;
		
	}
}
