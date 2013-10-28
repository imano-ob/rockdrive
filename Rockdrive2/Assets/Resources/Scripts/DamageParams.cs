using UnityEngine;
using System.Collections;

public class DamageParams {
	
	public int damage;
	public char type;
	
	public DamageParams(int dam,char typ){
		damage=dam;
		type=typ;
		Debug.Log("DP "+damage+" "+type);
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
}
