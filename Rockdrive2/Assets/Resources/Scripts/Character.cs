/*
 * Funções básicas usadas por todos os personagens (player, inimigos) do jogo)
 */

using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public bool friend=false;
	public int maxHp=10;
	public int hp=10;
	public int level=1;
	public int power=1;
	public char type='f';
	public string state;
	bool facingRight=true;
	public bool damageEnabled;
	public bool damageDelayEnabled;
	public int damageDelay;
	int currentDamageDelay;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void changeState(string newState){
		state=newState;	
		bool facingnow=facingRight;
		if(state=="stopleft"||state=="runleft"||state=="jumpleft")facingRight=false;
		if(state=="stopright"||state=="runright"||state=="jumpright")facingRight=true;
		if(facingnow!=facingRight)gameObject.BroadcastMessage("changeDirection",facingRight);
	}
	
	// Dano e morte
	void Damage(DamageParams dp){
		
		 Debug.Log(this.name);
		
		if(friend!=dp.friendly){
			Debug.Log(this.name+" hit type-"+type+" with:"+dp.type );
			if(type=='f'){
				Debug.Log("lol");
				if(dp.type=='w') superEffective(dp);
				if(dp.type=='f') normalEffective(dp);
				if(dp.type=='g') notEffective(dp);
		}
			if(type=='w'){
				if(dp.type=='g') superEffective(dp);
				if(dp.type=='w') normalEffective(dp);
				if(dp.type=='f') notEffective(dp);
		}
			if(type=='g'){
				if(dp.type=='f') superEffective(dp);
				if(dp.type=='g') normalEffective(dp);
				if(dp.type=='w') notEffective(dp);
		}
		}
	}
	
	void Knockback(float force){
		CharacterController controller= gameObject.GetComponent("CharacterController")as CharacterController;
		//Vector3 newVelcontroller.velocity
	}
	
	void superEffective(DamageParams dp){
		hp= (int)System.Math.Round(hp-dp.damage*(float)1.25f);	
		Debug.Log(this.name+" hit for "+dp.damage*(float)1.25f+"! Super Effective!"); 
		checkDeath();
	}
	void normalEffective(DamageParams dp){
		hp= hp-dp.damage;
		Debug.Log(this.name+" hit for "+dp.damage+"!"); 
		checkDeath();
	}
	void notEffective(DamageParams dp){
		hp= (int)System.Math.Round(hp-dp.damage*0.75f);	
		Debug.Log(this.name+" hit for "+dp.damage*(float)0.75f+"! It's not very effective!"); 
		checkDeath();
	}
	
	void checkDeath(){
		Debug.Log("Checking for death HP:"+maxHp);
		if(hp<=0) Destroy(gameObject);
	}
	
	//Tipo
	void changeType(char newType){
		type= newType;	
		Debug.Log("New Type: "+newType);
	}
}
