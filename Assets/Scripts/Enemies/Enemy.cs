using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
	public float life = 150f;

	private float maxLifeTime = 22000f;
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
		Vector2 movement = new Vector2 (-speed * Time.deltaTime, 0);
		rb.MovePosition(rb.position + movement);
	}
}
