using UnityEngine;
using System.Collections;

public class RenderPriority : MonoBehaviour {
	public int renderPriority;
	
	// Use this for initialization
	void Start () {
		this.gameObject.renderer.material.renderQueue= renderPriority;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
