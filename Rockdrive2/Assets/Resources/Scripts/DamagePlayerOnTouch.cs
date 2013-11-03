using UnityEngine;
using System.Collections;

public class DamagePlayerOnTouch : MonoBehaviour {

	public string type="f";
	public int damage= 1;
	public float knockback= 30f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){
		if(col.name=="Player"){
			if(transform.position.x>=col.transform.position.x)knockback=-1*knockback;
			DamageParams dp= new DamageParams(damage,type[0],false,new Vector3(knockback,10f,0));
			
			col.BroadcastMessage("Damage",dp);
			
		}
	}
}
