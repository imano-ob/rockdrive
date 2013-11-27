using UnityEngine;
using System.Collections;

public class LifeUnit : MonoBehaviour {
	int number;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void changeType(char newType){
		switch(newType){
		case'f':
			guiTexture.texture= Resources.Load("Textures/lifeUnitFire")as Texture2D;	
		break;		
			
		case'w':
			guiTexture.texture= Resources.Load("Textures/lifeUnitWater")as Texture2D;	
		break;	
			
		case'g':
			guiTexture.texture= Resources.Load("Textures/lifeUnitGrass")as Texture2D;	
		break;	
		}
			
	}
	
	void SetNumber(int i){
		number=i;	
	}
	
	void UpdateLifeBar(int i){
		if(i<=number)guiTexture.enabled=false;
		else guiTexture.enabled=true;
	}
}
