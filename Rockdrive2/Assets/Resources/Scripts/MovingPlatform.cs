using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public GameObject endPlace;
	Vector3 origin,destiny;
	public int stoppedDelay=50;
	public int currentDelay;
	public float speed=1f;
	public int state=0;
	// Use this for initialization
	void Start () {
		origin=transform.position;
		destiny=endPlace.transform.position;
		Destroy(endPlace);
	}
	
	void FixedUpdate(){
		
		if(state==0){
			//Debug.Log("lololol");
		currentDelay++;
		if(currentDelay>=stoppedDelay){
			currentDelay=0;
			state=1;
			}
		}
		
		if(state==2){
		currentDelay++;
		if(currentDelay>=stoppedDelay){
			currentDelay=0;
			state=3;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
		if(state==1){
			//Debug.Log("lololol");
			transform.position= Vector3.MoveTowards(transform.position,destiny,speed/10f);
			if(Vector3.Equals(transform.position,destiny))state=2;
		}
		if(state==3){
			transform.position= Vector3.MoveTowards(transform.position,origin,speed/10f);
			if(Vector3.Equals(transform.position,origin))state=0;
		}
	}
}
