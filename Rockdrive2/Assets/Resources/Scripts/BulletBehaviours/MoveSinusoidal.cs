using UnityEngine;
using System.Collections;

public class MoveSinusoidal : MonoBehaviour {
	public int angle;
	public float speed=1;
	public float angularSpeed=1;
	public float amplitude=1;
	Vector3 delta,sinDelta;
	float x=0;
	// Use this for initialization
	void Start () {
		transform.Rotate(new Vector3(0,angle,0));
	}
	
	// Update is called once per frame
	void Update () {
		x=x+0.1f;
		sinDelta= Quaternion.Euler(0,0,angle)* new Vector3(0,amplitude*0.05f*Mathf.Cos(angularSpeed*x),0);
		delta= Quaternion.Euler(0,0,angle)*(new Vector3(speed*0.1f,0,0));
		transform.localPosition= transform.localPosition+ delta+sinDelta;
		
	}
}
