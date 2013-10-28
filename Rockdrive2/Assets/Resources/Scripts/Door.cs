using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public GameObject door,dungeonController,lockA,lockB;
	public int key=0;
	int nextKey;
	bool lockOnNext=false;
	GameObject player;
	float distance;
	bool playerCloseEnough = false;
	//public bool locked=false;
	bool startOpen,startClose=false;
	int open= 0;
	public AudioClip openSound,closeSound;
	Vector3 stPos,endPos;
	// Use this for initialization
	void Start () {
		player= GameObject.Find("Player");
		//dungeonController= GameObject.Find("DungeonController");
		stPos= door.transform.position;
		endPos= door.transform.position- new Vector3(0,1f,0);
		if(key==0){
			//lockA.SetActive(false);
			//lockB.SetActive(false);
		}
	}
	
	void OnTriggerEnter(Collider player){
		Debug.Log("colisao detectada");
		if(player.gameObject.name=="Player"){
		//	Debug.Log("colisao correta");
			if(key==0)startOpen = true;
			//else dungeonController.BroadcastMessage("GiveKeys",gameObject);
		}
		
	}
	
	
	void CheckKeys(int[] keys){
		for(int i=0;i<14;i++){
			if(keys[i]==key){
				key=0;
				startOpen = true;
				
				break;
			}
		}
	}
	
	void UnlockDoor(){
		key=0;
		
	}
	
	void LockDoor(int newkey=999){
		nextKey=newkey;
		lockOnNext=true;
		
	}
	
	void OnTriggerExit(Collider player){
		Debug.Log("saida detectada");
		if(player.gameObject.name=="Player" && key==0){
			//Debug.Log("colisao correta");
			//startOpen = false;
			startClose = true;
			if(lockOnNext==true){
				key=nextKey;
				lockA.SetActive(true);
				lockB.SetActive(true);
				player.gameObject.BroadcastMessage("SetLookTargetOnce",gameObject);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if(startOpen == true){
			audio.PlayOneShot(openSound,1);
			open=1;
			startOpen = false;
			Debug.Log("ABRINDOPORTA");
		}
		
		if(startClose == true){
			audio.PlayOneShot(closeSound,1);
			open=2;
			startClose = false;
			Debug.Log("FechandoPORTA");
		}
		
		if(open==1){
			door.transform.position = Vector3.Lerp(door.transform.position,endPos,Time.deltaTime*10);
		}
		if(open==2){
			door.transform.position = Vector3.Lerp(door.transform.position,stPos,Time.deltaTime*10);
			
		}
	
	}
}