using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float moveSpeed = 12f;
	/*
	public AudioSource moveAudio; 
	public AudioClip playerNotMoving;
	public AudioClip playerIsMoving;
	*/

	private Rigidbody2D rb;
	private float movementInput;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnEnable(){
		movementInput = 0f;
	}

	void OnDisable(){
	}
	
	// Update is called once per frame
	void Update () {
		movementInput = Input.GetAxis ("Vertical");
	}

	void FixedUpdate(){
		Move ();
	}

	void Move(){
		Vector2 movement = new Vector2 (0,movementInput * moveSpeed * Time.deltaTime);
		rb.MovePosition(rb.position + movement);
	}
}
