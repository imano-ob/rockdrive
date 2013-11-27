using UnityEngine;
using System.Collections;

public class MoveToPlayer : MonoBehaviour {

	public float angle;
	public float speed;
	Vector3 delta;
	Rigidbody body;
	Vector3 targetPosition,startPosition;
	// Use this for initialization
	void Start () {
		//Vector3 distance= transform.position- GameObject.Find("Player").transform.position;
		targetPosition= GameObject.Find("Player").transform.position;
		
		Debug.Log("jogador em"+ targetPosition);
		//angle= Vector3.Angle(GameObject.Find("Player").transform.position,transform.position)-90;
		//transform.Rotate(new Vector3(0,angle,0));
		
		body= gameObject.GetComponent("Rigidbody")as Rigidbody;
		//body.velocity= Quaternion.Euler(0,0,angle)*(new Vector3(speed,0,0));
		//StartCoroutine(moveBullet());
		delta= Vector3.MoveTowards(transform.position,targetPosition,0.03f*speed)-transform.position;
	}
	
	void setDirection(int val){
		//angle=val;	
	}
	void setSide(bool val){
		//if(val==true)angle=0;
		//else angle=180;
	}
	
	IEnumerator moveBullet(){
		while(true){
			yield return new WaitForSeconds(Time.deltaTime);
			//delta= Quaternion.Euler(0,0,angle)*(new Vector3(speed*0.3f,0,0));
			//transform.localPosition= transform.localPosition+ delta;
			
			//transform.position= Vector3.Lerp(transform.position,targetPosition,0.3f*speed);
		}
	}
	// Update is called once per frame
	void Update () {
		transform.localPosition= transform.localPosition+delta;
		
		//delta= Quaternion.Euler(0,0,angle)*(new Vector3(speed*0.1f,0,0));
		//transform.localPosition= transform.localPosition+ delta;
	}

}