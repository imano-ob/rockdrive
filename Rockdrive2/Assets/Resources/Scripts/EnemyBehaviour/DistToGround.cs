using UnityEngine;
using System.Collections;

public class DistToGround : MonoBehaviour {
	
	float distToGround;
	public bool grounded=true;
	BoxCollider collider;
	// Use this for initialization
	void Start () {
		collider= gameObject.GetComponent("BoxCollider") as BoxCollider;
		distToGround = collider.bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public bool IsGrounded(){
		//Debug.Log(Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f));
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
}
