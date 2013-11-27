using UnityEngine;
using System.Collections;

public class DamageEffect : MonoBehaviour {
	
	Character character;
	
	// Use this for initialization
	void Start () {
		
		
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
	void notEffective(){
		GameObject effect=  Instantiate(Resources.Load("Effects/notEffective"))as GameObject;
		effect.transform.position=transform.position+ new Vector3(0,0,-0.01f);
	}
	
	void normalEffective(){
		GameObject effect=  Instantiate(Resources.Load("Effects/normalEffective"))as GameObject;
		effect.transform.position=transform.position+ new Vector3(0,0,-0.01f);
	}
	
	void superEffective(){
		GameObject effect=  Instantiate(Resources.Load("Effects/superEffective"))as GameObject;
		effect.transform.position=transform.position+ new Vector3(0,0,-0.01f);
	}
	
}
