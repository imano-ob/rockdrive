using UnityEngine;
using System.Collections;

public class LifeCheckpointController : MonoBehaviour {
	Character character;
	Vector3 checkpoint;
	// Use this for initialization
	void Start () {
		checkpoint=transform.position;
		character= GetComponent("Character")as Character;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void PlayerDeath(){
		character.hp= character.maxHp;
		transform.position=checkpoint;
		
	}
	
	void SetCheckpoint(Vector3 nc){
		checkpoint= nc;
	}
}
