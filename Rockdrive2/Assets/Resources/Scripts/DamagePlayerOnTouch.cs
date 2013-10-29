using UnityEngine;
using System.Collections;

public class DamagePlayerOnTouch : MonoBehaviour {

	public string type="f";
	public int damage= 1;
	public float knockback= 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		if(col.name=="Player"){
			DamageParams dp= new DamageParams(damage,type[0],false);
			col.BroadcastMessage("Damage",dp);
			//col.BroadcastMessage("Knockback",knockback);
			col.BroadcastMessage("Knockback",new Vector3(-20f,10f,0));
		}
	}
}
