using UnityEngine;
using System.Collections;

public class HudControl : MonoBehaviour {
	GUITexture lifeHUD;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
