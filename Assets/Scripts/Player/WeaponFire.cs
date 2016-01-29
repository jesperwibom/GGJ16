using UnityEngine;
using System.Collections;

public class WeaponFire : MonoBehaviour {

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
		Debug.Log ("Instanciate bullet here");

	}
}
