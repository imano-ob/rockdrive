using UnityEngine;
using System.Collections;

public class PlayerStateControl : MonoBehaviour {
	public string currentState="jumpright";
	public bool facingRight;
	public bool rightPressed=false;
	public bool leftPressed=false;
	public bool jumping;
	public bool shooting;
	public int shootingDelay=10;
	int shootingCurrentDelay;
	public bool grounded=false;
	bool pastFacingRight=false,pastRightPressed=false,pastLeftPressed=false,pastJumping=false,pastGrounded=false;
	public bool animate=true;
	CharacterController player;
	Character playerData;
	
	// Use this for initialization
	void Start () {
		facingRight=true;
		player= gameObject.GetComponent("CharacterController")as CharacterController;
		gameObject.BroadcastMessage("changeState",currentState);
		playerData=gameObject.GetComponent("Character")as Character;
		//playerCharacter= gameObject.GetComponent("Character")as Character;
		//StartCoroutine(UpdateSprite());
	}
	
	
	// Update is called once per frame
	void Update () {
		
			pastJumping=jumping;
			pastLeftPressed=leftPressed;
			pastRightPressed=rightPressed;
			pastGrounded=grounded;
			pastFacingRight=facingRight;
			pastJumping=jumping;
			
			if(player.isGrounded==true) grounded=true;
				else grounded=false;
			
			
				
			if(Input.GetKeyDown("left")){
					leftPressed=true;
					}
		
			if(Input.GetKeyUp("left")){
				leftPressed=false;
			}
			
			if(Input.GetKeyDown("right")){
				rightPressed=true;
				}
		
			if(Input.GetKeyUp("right")){
				rightPressed=false;
			}
			
			
			if(Input.GetKeyDown("z")){
				jumping=true;
					}
		
			if(Input.GetKeyUp("z")){
				jumping=false;
			}
			
			UpdateSprite();	
			
			if(Input.GetKeyDown("a")){
				gameObject.BroadcastMessage("previousType");
			}
		
			if(Input.GetKeyDown("c")){
				gameObject.BroadcastMessage("nextType");
			}
		
			if(Input.GetKeyDown("x")){
				gameObject.BroadcastMessage("Fire");
				shooting=true;
				if(playerData.type!='w')
					StartCoroutine(shootDelay());
			}
		
			if(Input.GetKeyUp("x") && playerData.type=='w'){
				gameObject.BroadcastMessage("stopFireImmediate");
				gameObject.BroadcastMessage("stopFire");
				//StartCoroutine(shootDelay());
		}
			
		
	}
	
	IEnumerator shootDelay(){
		shootingCurrentDelay=0;
		
		while(shootingCurrentDelay<=shootingDelay){
			
			shootingCurrentDelay++;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		shooting=false;
		gameObject.BroadcastMessage("stopFire");
	}
	
	void UpdateSprite(){
		
		
		//Is on the ground
		if(grounded==true){
			//Was standing, starts to run
			if(leftPressed==true && pastLeftPressed==false && rightPressed==false) gameObject.BroadcastMessage("changeState","runleft");
			if(rightPressed==true && pastRightPressed==false && leftPressed==false) gameObject.BroadcastMessage("changeState","runright");
			
			//Was running, stops
			if(leftPressed==false && pastLeftPressed==true && rightPressed==false) gameObject.BroadcastMessage("changeState","stopleft");
			if(rightPressed==false && pastRightPressed==true && leftPressed==false) gameObject.BroadcastMessage("changeState","stopright");
			
			//Turning
			if(leftPressed==true && pastRightPressed==true && rightPressed==false) gameObject.BroadcastMessage("changeState","runleft");
			if(rightPressed==true && pastLeftPressed==true && leftPressed==false) gameObject.BroadcastMessage("changeState","runright");
			
			//Just hit the ground standing
			if(currentState=="jumpleft" && leftPressed==false)gameObject.BroadcastMessage("changeState","stopleft");
			if(currentState=="jumpright" && rightPressed==false)gameObject.BroadcastMessage("changeState","stopright");
			
			//Just hit the ground running
			if(currentState=="jumpleft" && leftPressed==true)gameObject.BroadcastMessage("changeState","runleft");
			if(currentState=="jumpright" && rightPressed==true)gameObject.BroadcastMessage("changeState","runright");
		}
		//Is on the air
		if(grounded==false){
			//Just jumped
			if(currentState=="stopleft"||currentState=="runleft")gameObject.BroadcastMessage("changeState","jumpleft");
			if(currentState=="stopright"||currentState=="runright")gameObject.BroadcastMessage("changeState","jumpright");
			
			//turning in the air
			if(currentState=="jumpright" && leftPressed==true)gameObject.BroadcastMessage("changeState","jumpleft");
			if(currentState=="jumpleft" && rightPressed==true)gameObject.BroadcastMessage("changeState","jumpright");
			
		
		}
		//yield return new WaitForSeconds(Time.deltaTime);
		
	}
	
	void changeState(string newState){
		currentState=newState;
	}
	/*
	void changeType(char newType){
		
		if (newType=='f')gameObject.renderer.material.SetTexture("_MainTex",Resources.Load("Textures/playerFire") as Texture);
		if (newType=='w')gameObject.renderer.material.SetTexture("_MainTex",Resources.Load("Textures/playerWater") as Texture);
		if (newType=='g')gameObject.renderer.material.SetTexture("_MainTex",Resources.Load("Textures/playerGrass") as Texture);
		
		
	}*/
}
