using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour {

	public float dmg = 100f;
	public float speed = 12f;
	public LayerMask enemyMask;
	public AudioSource hitSound;
	public ParticleSystem explosionParticles;

	private float maxLifeTime = 2f;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, maxLifeTime);
	}

	void OnTriggerEnter2D (Collider2D col){	
		//Debug.Log ("Hit!!!");

		if (col.IsTouching(gameObject.GetComponent<Collider2D>())) {
			
			Rigidbody2D targetRigidbody = col.GetComponent<Rigidbody2D> ();
			Enemy targetHealth = targetRigidbody.GetComponent<Enemy> ();
			if (targetHealth != null) {
				targetHealth.TakeDamage (dmg);

				ParticleSystem particles = Instantiate (explosionParticles, transform.position, transform.rotation) as ParticleSystem;
				particles.Play ();

				hitSound.Play();

				Destroy (gameObject, 0.5f);
			}
		}

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
