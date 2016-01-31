using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

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
			#if UNITY_EDITOR
			EditorSceneManager.LoadScene ("Deathscreen");
			#endif
			Application.LoadLevel ("Deathscreen");

		} else {
			ui.DrawHelmets (lives);
		}
	}
}
