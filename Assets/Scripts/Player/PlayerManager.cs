using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

//ctrl player lifes, player position reset, hit sound and hit particles 

public class PlayerManager : MonoBehaviour {

	public int lives = 3;
	private int score;
	public bool godMode = false;

	public UIManager ui;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Hit(){
		if (!godMode) {
			lives--;
			Debug.Log (lives);
			CheckLives ();
		}
	}

	private void CheckLives(){
		if (lives <= 0) {
			ui.DrawHelmets(0);
			gameObject.SetActive(false);
			EditorSceneManager.LoadScene ("Deathscreen");

		} else {
			ui.DrawHelmets (lives);
		}
	}
}
