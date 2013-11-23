/*GunSound
 * Sets the correct clip and plays the sound for guns
 * 
 * */
using UnityEngine;
using System.Collections;

public class GunSound : MonoBehaviour {
	
	Character character;
	public AudioClip fireSound,waterSound,grassSound;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		character= gameObject.transform.parent.gameObject.GetComponent("Character") as Character;
		audio= gameObject.GetComponent("AudioSource") as AudioSource;
		
		if(character.type=='f') audio.clip=fireSound;
		if(character.type=='g') audio.clip=grassSound;
		if(character.type=='w') audio.clip=waterSound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Fire(){
		audio.Play();	
	}
	
	
	//Type
	void changeType(char newType){
		if(newType=='f') audio.clip=fireSound;
		if(newType=='g') audio.clip=grassSound;
		if(newType=='w') audio.clip=waterSound;
		
	}
}
