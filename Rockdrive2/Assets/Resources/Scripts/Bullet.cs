/*Define um tiro qualquer
 * vai servir tanto para tiros do jogador quanto de inimigos
 */

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public int damage;
	public char type;
	public string types="f";
	
	public Bullet(int dam,char typ){
		damage=dam;
		type=typ;
	}
	// Use this for initialization
	void Start () {
		type=types[0];
	}
	
	void OnTriggerEnter(Collider target){
		DamageParams damp= new DamageParams(damage,type);
		Debug.Log("Criar DP "+damage+" "+type);
		target.BroadcastMessage("Damage",damp);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
