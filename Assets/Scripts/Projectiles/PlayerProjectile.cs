using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour {

	public float dmg = 100f;
	public float speed = 12f;

	private float maxLifeTime = 2000f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, maxLifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Travel ();
	}

	void Travel(){
		Vector2 movement = new Vector2 (speed * Time.deltaTime, 0);
		rb.MovePosition(rb.position + movement);
	}
}
