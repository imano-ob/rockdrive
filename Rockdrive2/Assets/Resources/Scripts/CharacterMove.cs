

using UnityEngine;
using System.Collections;

// Require a character controller to be attached to the same game object
[RequireComponent (typeof (CharacterController))]

public class CharacterMove : MonoBehaviour {
	
	enum CharacterSide{
		Left=0,
		Right=1,
	}
	
	bool Firing;
	bool Grounded;
	enum CharacterState {
		Idle = 0,
		Running = 1,
		Jumping = 2,
		Damaged = 3,
	}
	
	// Use this for initialization
	void Start () {
		//CharacterSide=0;
		Firing=false;
		//CharacterState=0;
		Grounded=true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/*bool IsGrounded () {
		return (collisionFlags & CollisionFlags.CollidedBelow) != 0;
	}*/
}
