using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {
	public float speed = 0;
	private  bool running = true;
	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		if (running) {
			gameObject.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (Time.time * speed, 0f);
		}
	}
	public void stopScroll(){
		running = false;
	}
}
