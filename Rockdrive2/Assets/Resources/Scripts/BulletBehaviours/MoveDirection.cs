using UnityEngine;
using System.Collections;

public class MoveDirection : MonoBehaviour {

	public int angle;
	public float speed;
	Vector3 delta;
	Rigidbody body;
	// Use this for initialization
	void Start () {
		transform.Rotate(new Vector3(0,angle,0));
		body= gameObject.GetComponent("Rigidbody")as Rigidbody;
		body.velocity= Quaternion.Euler(0,0,angle)*(new Vector3(speed,0,0));
		//StartCoroutine(moveBullet());
	}
	
	void setDirection(int val){
		angle=val;	
	}
	void setSide(bool val){
		if(val==true)angle=0;
		else angle=180;
	}
	
	IEnumerator moveBullet(){
		while(true){
			yield return new WaitForSeconds(Time.deltaTime);
			delta= Quaternion.Euler(0,0,angle)*(new Vector3(speed*0.3f,0,0));
			transform.localPosition= transform.localPosition+ delta;
			
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		//delta= Quaternion.Euler(0,0,angle)*(new Vector3(speed*0.1f,0,0));
		//transform.localPosition= transform.localPosition+ delta;
		
		
	}
}
