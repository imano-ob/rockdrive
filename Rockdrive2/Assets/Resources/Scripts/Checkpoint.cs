using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider duck){
		if(duck.name=="Player") duck.BroadcastMessage("SetCheckpoint",transform.position);
	}	
		
	}