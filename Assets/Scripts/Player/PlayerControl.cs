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
	private float movementVerInput;
	private float movementHorInput;

	public float minX = -7f;
	public float maxX = 7f;
	public float minY = -5f;
	public float maxY = 5f;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnEnable(){
		movementVerInput = 0f;
		movementHorInput = 0f;
	}

	void OnDisable(){
	}
	
	// Update is called once per frame
	void Update () {
		movementVerInput = Input.GetAxis ("Vertical");
		movementHorInput = Input.GetAxis ("Horizontal");
	}

	void FixedUpdate(){
		Move ();
	}

	void Move(){
		//Debug.Log (rb.position.y);
		Debug.Log (rb.position.x);
		if (rb.position.y > maxY && movementVerInput > 0) {
			movementVerInput = 0;
		}
		if (rb.position.y < minY && movementVerInput < 0) {
			movementVerInput = 0;
		}
		if (rb.position.x > maxX && movementHorInput > 0) {
			movementHorInput = 0;
		}
		if (rb.position.x < minX && movementHorInput < 0) {
			movementHorInput = 0;
		}
			
		Vector2 movement = new Vector2 (movementHorInput * moveSpeed * Time.deltaTime, movementVerInput * moveSpeed * Time.deltaTime);

		rb.MovePosition(rb.position + movement);
	}
}
