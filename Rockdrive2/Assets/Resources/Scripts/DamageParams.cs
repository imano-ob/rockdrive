using UnityEngine;
using System.Collections;

public class DamageParams {
	
	public int damage;
	public char type;
	public bool friendly;
	public Vector3 knockback;
	public bool hasKnockback=false;
	public DamageParams(int dam,char typ,bool friend){
		damage=dam;
		type=typ;
		friendly=friend;
		Debug.Log("DP "+damage+" "+type);
	}
	
	public DamageParams(int dam,char typ,bool friend,Vector3 knockb){
		damage=dam;
		type=typ;
		friendly=friend;
		knockback=knockb;
		Debug.Log("DP "+damage+" "+type);
		hasKnockback=true;
	}
	
	public DamageParams(int dam,char typ,bool friend,Vector3 knockb,bool over){
		damage=dam;
		type=typ;
		friendly=friend;
		knockback=knockb;
		Debug.Log("DP "+damage+" "+type);
		hasKnockback=over;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	char getType(){
		return type;	
	}
	
	int getDamage(){
		return damage;	
	}
	
	bool getFriendly(){
		return friendly;	
	}
}
