using UnityEngine;
using System.Collections;

//ctrl player lifes, player position reset, hit sound and hit particles 

public class PlayerManager : MonoBehaviour {

	public int lives = 3;
	private int score;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hit(){
		Debug.Log ("Ouch!");
		lives--;
		CheckLives ();
	}

	private void CheckLives(){
		if (lives <= 0) {
			gameObject.SetActive(false);
			//remove all helmets
			//disable player
			//display score
		} else {
			//draw nr of helmets
		}
	}
}
