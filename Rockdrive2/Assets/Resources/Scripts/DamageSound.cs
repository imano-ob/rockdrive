using UnityEngine;
using System.Collections;

public class DamageSound : MonoBehaviour {
	
	Character character;
	public AudioClip notSound,normalSound,superSound;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		
		audio= gameObject.GetComponent("AudioSource") as AudioSource;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void notEffective(){
		//audio.clip= notSound;
		audio.PlayOneShot(notSound);
	}
	
	void normalEffective(){
		//audio.clip= normalSound;
		audio.PlayOneShot(normalSound);
	}
	
	void superEffective(){
		//audio.clip= superSound;
		audio.PlayOneShot(superSound);
	}
	
}
