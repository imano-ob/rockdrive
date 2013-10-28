using UnityEngine;
using System.Collections;

public class PlayerAnimControl : MonoBehaviour {
	public bool facingRight;
	public bool rightPressed=false;
	public bool leftPressed=false;
	public bool jumping;
	public bool shooting;
	public bool grounded=false;
	bool pastFacingRight=false,pastRightPressed=false,pastLeftPressed=false,pastJumping=false,pastGrounded=false;
	CharacterController player;
	// Use this for initialization
	void Start () {
		facingRight=true;
		player= gameObject.GetComponent("CharacterController")as CharacterController;
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
			
				
				
				
			/*	
			
			if(player.isGrounded==true&&grounded==false && leftPressed==false && rightPressed==false){
					grounded=true;
				if(facingRight==true)this.gameObject.BroadcastMessage("changeState","stopRight");
					else this.gameObject.BroadcastMessage("changeState","stopLeft");
			}
			
			if(player.isGrounded==false && grounded==true)grounded=false;
				
			if(Input.GetKeyDown("left")){
				if(leftPressed==false && rightPressed==false){
					if(grounded==true) this.gameObject.BroadcastMessage("changeState","left");
						else this.gameObject.BroadcastMessage("changeState","jumpleft");
					facingRight=false;
						}
					leftPressed=true;
					}
		
			if(Input.GetKeyUp("left")){
				leftPressed=false;
				if(rightPressed==false)this.gameObject.BroadcastMessage("changeState","stopLeft");
			}
			
			if(Input.GetKeyDown("right")){
				if(leftPressed==false && rightPressed==false){
					if(grounded==true) this.gameObject.BroadcastMessage("changeState","right");
						else this.gameObject.BroadcastMessage("changeState","jumpright");
					facingRight=true;
					}
					rightPressed=true;
				}
		
			if(Input.GetKeyUp("right")){
				rightPressed=false;
				if(leftPressed==false)this.gameObject.BroadcastMessage("changeState","stopRight");
			}
			
			if(Input.GetKeyDown("up")){
				this.gameObject.BroadcastMessage("changeState","up");
				
					}
		
			if(Input.GetKeyUp("up")){
				
			}
			
			if(Input.GetKeyDown("down")){
				this.gameObject.BroadcastMessage("changeState","down");
				
					}
		
			if(Input.GetKeyUp("down")){
				
			}
			
			if(Input.GetKeyDown("z")){
				if(facingRight) this.gameObject.BroadcastMessage("changeState","jumpright");
				else this.gameObject.BroadcastMessage("changeState","jumpleft");
					}
		
			if(Input.GetKeyUp("z")){
				
			}*/
			
			//yield return new WaitForSeconds(Time.deltaTime);
		
	}
	
	void changeType(char newType){
		
		if (newType=='f')gameObject.renderer.material.SetTexture("_MainTex",Resources.Load("Textures/playerFire") as Texture);
		if (newType=='w')gameObject.renderer.material.SetTexture("_MainTex",Resources.Load("Textures/playerWater") as Texture);
		if (newType=='g')gameObject.renderer.material.SetTexture("_MainTex",Resources.Load("Textures/playerGrass") as Texture);
		
		
	}
}
