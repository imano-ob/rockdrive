using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	
	
	public int damage=1;
	public char type='f';
	public string bullet="GenericBullet";
	public bool hold=false;
	public bool charge=false;
	public int chargetime=1;
	public bool facingRight=true;
	public int centerDiff=0;
	public float fireDelay=5;
	public bool multiFire;
	public bool friendly=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Fire(){
		
		//GameObject bullet= Resources.Load("Bullets/FireBullet1")as GameObject;
		//bullet.transform.position=gameObject.transform.position;
		GameObject bullet= Instantiate(Resources.Load("Bullets/FireBullet1")as GameObject,transform.position,Quaternion.Euler(new Vector3(90,180,0) ))as GameObject;
		bullet.BroadcastMessage("setFriendly",true);
	}
}
