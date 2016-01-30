using UnityEngine;
using System.Collections;

public class WeaponFire : MonoBehaviour {

	public Rigidbody2D proj;
	public Transform spawnPosition;

	private bool btnPressed;
	private bool fired;


	// Update is called once per frame
	void Update () {
		btnPressed = Input.GetButton ("Jump"); //gets the space key
	}

	void FixedUpdate(){
		if (!btnPressed) {
			fired = false;
		}
		if (btnPressed && !fired) {
			Fire ();
		}
	}

	void Fire(){
		fired = true;
		Rigidbody2D projectileInstance = Instantiate (proj, spawnPosition.position, spawnPosition.rotation) as Rigidbody2D;

	}

}
