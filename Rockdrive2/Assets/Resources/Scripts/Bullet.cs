/*Define um tiro qualquer
 * vai servir tanto para tiros do jogador quanto de inimigos
 */

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public int damage;
	public char type;
	public string types="f";
	public bool friendly=true;
	public bool pierce=false;
	public Bullet(int dam,char typ){
		damage=dam;
		type=typ;
	}
	// Use this for initialization
	void Start () {
		type=types[0];
	}
	
	
	void OnTriggerEnter(Collider target){
		Character targetData= target.GetComponent("Character")as Character;
		if( targetData!=null && targetData.friend!=friendly){
			Debug.Log("DUCK!!!");
			DamageParams damp= new DamageParams(damage,type,friendly);
			Debug.Log("Criar DP "+damage+" "+type+" friend-"+friendly+" para "+target.gameObject.name);
			target.BroadcastMessage("Damage",damp);
			if(pierce==false)Destroy(gameObject);
		}
	}
	/*
	void OnCollisionEnter(Collision target){
		Debug.Log("DUCK!!!");
		DamageParams damp= new DamageParams(damage,type,friendly);
		Debug.Log("Criar DP "+damage+" "+type+" friend-"+friendly+" para "+target.gameObject.name);
		target.gameObject.BroadcastMessage("Damage",damp);
	}
	
	void OnControllerColliderHit(ControllerColliderHit target){
		Debug.Log("DUCK!!!");
		DamageParams damp= new DamageParams(damage,type,friendly);
		Debug.Log("Criar DP "+damage+" "+type+" friend-"+friendly+" para "+target.gameObject.name);
		target.gameObject.BroadcastMessage("Damage",damp);
	}*/
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void setFriendly(bool val){
		friendly=val;	
	}
}
