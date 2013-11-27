using UnityEngine;
using System.Collections;

public class FallingPlatformTrigger : MonoBehaviour {
	public GameObject platform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider colli){
		
		if(colli.gameObject.name=="Player"){
			
			platform.BroadcastMessage("PlayerTouch");
		}
	}
}
