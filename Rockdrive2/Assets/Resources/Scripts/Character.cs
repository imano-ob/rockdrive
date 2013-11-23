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
	public string typeS="f";
	public char type='f';
	public string state;
	bool facingRight=true;
	public bool damageEnabled;
	bool damageable=true;
	public bool damageDelayEnabled;
	public float damageDelay;
	public float currentDamageDelay;
	public bool knockbackDelayEnabled;
	public float knockbackDelay;
	public float currentKnockbackDelay;
	ImpactReceiver impactReceiver;
	MeshRenderer meshRenderer;
	CharacterMotor characterMotor;
	// Use this for initialization
	void Start () {
		type= typeS[0];
		impactReceiver= gameObject.GetComponent("ImpactReceiver")as ImpactReceiver;
		meshRenderer= gameObject.GetComponent("MeshRenderer")as MeshRenderer;
		characterMotor= gameObject.GetComponent("CharacterMotor")as CharacterMotor;
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
		if(damageable==true){
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
			if(damageDelayEnabled)StartCoroutine(DamageDelay());
		}
	}
	
	IEnumerator DamageDelay(){
		damageable=false;
		currentDamageDelay=0;
		while(currentDamageDelay<=damageDelay){
			yield return new WaitForSeconds(Time.deltaTime);
			currentDamageDelay= currentDamageDelay+Time.deltaTime;
			meshRenderer.enabled=false;
			yield return new WaitForSeconds(Time.deltaTime);
			currentDamageDelay= currentDamageDelay+Time.deltaTime;
			meshRenderer.enabled=true;
		}
		damageable=true;
	}
	
	IEnumerator KnockbackDelay(){
		currentKnockbackDelay=0;
		characterMotor.canControl=false;
		while(currentKnockbackDelay<=knockbackDelay){
			yield return new WaitForSeconds(Time.deltaTime);
			currentKnockbackDelay=currentKnockbackDelay+Time.deltaTime;	
		}
		characterMotor.canControl=true;
	}
	void Knockback(Vector3 force){
		//CharacterController controller= gameObject.GetComponent("CharacterController")as CharacterController;
		//Vector3 newVelcontroller.velocity
		gameObject.BroadcastMessage("AddImpact",force);
		StartCoroutine(KnockbackDelay());
	}
	
	void superEffective(DamageParams dp){
		hp= (int)System.Math.Round(hp-dp.damage*(float)1.25f);	
		Debug.Log(this.name+" hit for "+dp.damage*(float)1.25f+"! Super Effective!"); 
		if(dp.hasKnockback==true){
			dp.knockback= new Vector3(dp.knockback.x*1.5f,dp.knockback.y,dp.knockback.z);
			Knockback(dp.knockback);
		}
		checkDeath();
	}
	void normalEffective(DamageParams dp){
		hp= hp-dp.damage;
		Debug.Log(this.name+" hit for "+dp.damage+"!");
		if(dp.hasKnockback==true){
			Knockback(dp.knockback);
		}
		checkDeath();
	}
	void notEffective(DamageParams dp){
		hp= (int)System.Math.Round(hp-dp.damage*0.75f);	
		Debug.Log(this.name+" hit for "+dp.damage*(float)0.75f+"! It's not very effective!"); 
		if(dp.hasKnockback==true){
			dp.knockback= new Vector3(dp.knockback.x*0.75f,dp.knockback.y,dp.knockback.z);
			Knockback(dp.knockback);
		}
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
