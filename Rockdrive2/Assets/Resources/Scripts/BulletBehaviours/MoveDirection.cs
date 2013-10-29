using UnityEngine;
using System.Collections;

public class MoveDirection : MonoBehaviour {

	public int angle;
	public float speed;
	Vector3 delta;
	// Use this for initialization
	void Start () {
		transform.Rotate(new Vector3(0,angle,0));
	}
	
	void setDirection(int val){
		angle=val;	
	}
	void setSide(bool val){
		if(val==true)angle=0;
		else angle=180;
	}
	// Update is called once per frame
	void Update () {
		
		//gameObject.transform.Translate(rotation*new Vector3(-0.1f,0,0));
		delta= Quaternion.Euler(0,0,angle)*(new Vector3(speed*0.1f,0,0));
		transform.localPosition= transform.localPosition+ delta;
		
		//gameObject.transform.position= Vector3.r transform.position
	}
}
