using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	
	
	public int damage=1;
	public char type='f';
	public int level=1;
	public bool isPlayer=false;
	public string bulletName="GenericBullet";//Name of the current bullet prefab
	public bool hold=false;
	public bool charge=false;
	public int chargetime=1;
	public bool facingRight=true;
	
	public float centerDiff=0;//Distance from the center of the gun from where the bullets appear
	//Delays between bullets
	public int fireDelay=10;
	public int waterDelay=5;
	public int grassDelay=10;
	//Current frame of delay
	int currentFireDelay=0;
	public bool multiFire;
	public bool friendly=true;// if the character is friendly to the player
	public string[] fireBulletTable;//tabela de tiros de fogo, por nivel
	public string[] waterBulletTable;//idem, agua
	public string[] grassBulletTable;//idem, grama
	public bool breakFire=false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Updates the character level stored on the gun
	void UpdateLevel(int newLevel){
		level=newLevel;
		checkBullet();
	}
	
	//Changes the gun's type
	void changeType(char newType){
		
		type=newType;
		if(isPlayer==true){
			if(newType=='w'){
				multiFire=true;
				breakFire=false;	
			}
			else multiFire=false;
		}
		checkBullet();
	}
	
	//Checks which bullet to fire (with type and level)
	void checkBullet(){
		if(type=='w')
			for(int i=0;i<waterBulletTable.Length;i++)
				if(i<=level)bulletName=waterBulletTable[i];	
		if(type=='f')
			for(int i=0;i<fireBulletTable.Length;i++)
				if(i<=level)bulletName=fireBulletTable[i];
		if(type=='g')
			for(int i=0;i<grassBulletTable.Length;i++)
				if(i<=level)bulletName=grassBulletTable[i];
	}
	
	//Changes the direction of the bullet
	void changeDirection(bool newDir){
		facingRight=newDir;	
	}
	
	//Starts the firing process, call this with BroadcastMessage to fire
	void Fire(){
		breakFire=false;
		FireBullet();
	}
	
	//Spawns the bullet
	void FireBullet(){
		int i;
		if(facingRight==true)i=1;
			else i=-1;
		
		GameObject bullet= Instantiate(Resources.Load("Bullets/"+bulletName)as GameObject,transform.position+new Vector3(i*centerDiff,0,0),Quaternion.Euler(new Vector3(90,180,0) ))as GameObject;
		bullet.BroadcastMessage("setFriendly",true);
		if(facingRight==true)bullet.BroadcastMessage("setSide",true);
			else bullet.BroadcastMessage("setSide",false);
		
		//For multifiring bullets (water)
		if(multiFire==true){
			if(breakFire==false){
				StartCoroutine(FiringDelay());
				
			}
		}
	}
	
	//Stops fire
	void stopFire(){
		//breakFire=true;
		StopCoroutine("FiringDelay");
	}
	
	//Stops fire (for water, seriously need to change this later)
	IEnumerator stopFireImmediate(){
		breakFire=true;
		StopCoroutine("FiringDelay");
		yield return null;
		//breakFire=false;
	}
	
	//Counts the delay between two consecutive shots, and re-enables firing
	IEnumerator FiringDelay(){
		if(type=='f'){
			currentFireDelay=0;
			while(currentFireDelay<=fireDelay){
				
				currentFireDelay++;
				yield return new WaitForSeconds(Time.deltaTime);
			}
			
			//FireBullet ();
		}
		
		if(type=='g'){
			currentFireDelay=0;
			while(currentFireDelay<=grassDelay){
				
				currentFireDelay++;
				yield return new WaitForSeconds(Time.deltaTime);
			}
			
			//FireBullet ();
		}
		
		if(type=='w'){
			currentFireDelay=0;
			while(currentFireDelay<=waterDelay){
				
				currentFireDelay++;
				yield return new WaitForSeconds(Time.deltaTime);
			}
			
			FireBullet ();
		}
	}
	
	
}
