using UnityEngine;
using System.Collections;

public class HudControl : MonoBehaviour {
	GUITexture lifeHUD;
	GameObject player;
	Character playerData;
	GameObject[] lifeBar;
	GameObject test;
	int lasthp=0;
	// Use this for initialization
	void Start () {
		playerData= GameObject.Find("Player").GetComponent("Character")as Character;
		for(int i=0;i<playerData.maxHp;i++){
			Debug.Log("lowawasl");
		 	GameObject lifeunit= Instantiate(Resources.Load("LifeUnit"))as GameObject;
			lifeunit.transform.parent= gameObject.transform;
			lifeunit.transform.localPosition= new Vector3(0.44f+0.077f*i,-0.05f,0);
			lifeunit.transform.localScale=new Vector3(0.1f,0.3f,0.1f);
			lifeunit.BroadcastMessage("SetNumber",i);
			//lifeBar[i]=lifeunit;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(playerData.hp!=lasthp)
			gameObject.BroadcastMessage("UpdateLifeBar",playerData.hp);
		lasthp=playerData.hp;
	}
	
	void changeType(char newType){
		switch(newType){
		case'f':
			guiTexture.texture= Resources.Load("Textures/lifeBarFire")as Texture2D;	
		break;		
			
		case'w':
			guiTexture.texture= Resources.Load("Textures/lifeBarWater")as Texture2D;	
		break;	
			
		case'g':
			guiTexture.texture= Resources.Load("Textures/lifeBarGrass")as Texture2D;	
		break;	
		}
			
	}
}
