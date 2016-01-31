using UnityEngine;
using System.Collections;

public class WeaponFire : MonoBehaviour {

	public Rigidbody2D proj;
	public Transform spawnPosition;
	public AudioSource fireSound;

	private bool btnPressed1;
	private bool btnPressed2;
	private bool btnPressed3;
	private bool btnPressed4;

	private bool fired;


	// Update is called once per frame
	void Update () {
		btnPressed1 = Input.GetButton ("Jump"); //gets the space key
		btnPressed2 = Input.GetButton ("Fire1"); 
		btnPressed3 = Input.GetButton ("Fire2"); 
		btnPressed4 = Input.GetButton ("Fire3"); 
	}

	void FixedUpdate(){
		if (!btnPressed1 ) {
			fired = false;
		}

		if (btnPressed1 && !fired) {
			Fire ();
			fireSound.Play ();
		} 
	}

	void Fire(){
		fired = true;
		Rigidbody2D projectileInstance = Instantiate (proj, spawnPosition.position, spawnPosition.rotation) as Rigidbody2D;

	}

}
