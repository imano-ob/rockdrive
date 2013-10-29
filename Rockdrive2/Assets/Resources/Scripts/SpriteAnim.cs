using UnityEngine;
using System.Collections;

public class SpriteAnim : MonoBehaviour {
	
	//Spritesheet parameters
	public float sides=4;
	public float anim_sprites=4;
	public float spriteWidth=24;
	public float spriteHeight=24;
	public string[] spriteType;
	public string currentState="jumpright";
	public float spriteSheetWidth=128;//Needed to overcome Unity's stupid limitations
	public float spriteSheetHeight=128;
	
	public float anim_delay=5;
	public float delay_current=0;
	public float anim_current=0;
	string side="down";
	public GameObject sprite;
	public bool moving=true;
	public bool shooting=false;
	public string shootingTag="fire";
	CharacterController player;
	
	// Use this for initialization
	void Start () {
		player= gameObject.GetComponent("CharacterController")as CharacterController;
		
		sprite= this.gameObject;
		StartCoroutine(Animate());
		//sprite.renderer.material.mainTextureScale= new Vector2(1f/((spriteWidth-spriteSheetSize-anim_sprites*spriteWidth)/spriteSheetSize),1f/sides);
		sprite.renderer.material.mainTextureScale= new Vector2((spriteWidth/spriteSheetWidth),(spriteHeight/spriteSheetHeight));
	}
	
	void changeState(string side){
		currentState=side;
		int sideNumber=0;
		if(shooting==true) side= shootingTag+side;
		//Debug.Log(side);
		/*
		if(side=="down")sideNumber=3;
		if(side=="left")sideNumber=2;
		if(side=="right") sideNumber=1;
		if(side=="up") sideNumber=0;
		*/
		for(int i=0;i<spriteType.GetLength(0);i++){
			if(spriteType[i].Equals(side))sideNumber=(int)sides-i-1;
		}
		
		sprite.renderer.material.SetTextureOffset("_MainTex",new Vector2(sprite.renderer.material.mainTextureOffset.x,((spriteSheetHeight-spriteHeight*sides)/spriteSheetHeight)+(sideNumber*spriteHeight/spriteSheetHeight)));
	}
	
	void Fire(){
		shooting=true;
		changeState(currentState);
		
	}
	void stopFire(){
		shooting=false;	
		changeState(currentState);
	}
	void setMoving(bool state){
		//moving=state;
		if(state==true)StartCoroutine(Animate());
		else {
		//	sprite.renderer.material.SetTextureOffset("_MainTex",new Vector2(0,sprite.renderer.material.mainTextureOffset.y));
		//	anim_current=0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	IEnumerator Animate(){
		while(moving==true){
			yield return new WaitForSeconds(Time.deltaTime);
			delay_current++;
			//Debug.Log("boijo "+anim_current.ToString());
			if(delay_current>=anim_delay){
				//Debug.Log("boo "+anim_current.ToString());
				delay_current=0;
				anim_current++;
				if(anim_current>=anim_sprites)anim_current=0;
				//float dx=(float)(anim_sprites/spriteSheetSize)*(float)(spriteWidth-spriteSheetSize+anim_current*spriteWidth);
				float dx= (spriteWidth)/spriteSheetWidth;
				//Debug.Log("dx "+dx.ToString());
				sprite.renderer.material.SetTextureOffset("_MainTex",new Vector2(dx*(anim_current),sprite.renderer.material.mainTextureOffset.y));
				
				//sprite.renderer.material.mainTextureOffset.Set(0.25f*anim_current,sprite.renderer.material.mainTextureOffset.y);
			}
		}	
	}
	
	void changeType(char newType){
		
		if (newType=='f')gameObject.renderer.material.SetTexture("_MainTex",Resources.Load("Textures/"+this.name+"Fire") as Texture);
		if (newType=='w')gameObject.renderer.material.SetTexture("_MainTex",Resources.Load("Textures/"+this.name+"Water") as Texture);
		if (newType=='g')gameObject.renderer.material.SetTexture("_MainTex",Resources.Load("Textures/"+this.name+"Grass") as Texture);
		
		
	}
}
