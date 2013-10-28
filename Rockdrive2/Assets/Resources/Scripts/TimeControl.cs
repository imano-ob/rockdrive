using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

	float startTime;
	public GUIText Gtext;
	// Use this for initialization
	void Awake () {
		startTime= Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
		Gtext.text= (10.0f-Time.time-startTime).ToString();
		
	}
}
