using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class deathScreen : MonoBehaviour {
	bool blinking = false;
	GameObject text;
	// Use this for initialization
	void Start () {
		text = gameObject;
		StartCoroutine (Blink());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown){
			Debug.Log ("starting!");
			EditorSceneManager.LoadScene ("StartScene");
		}
		if(blinking == true){
			text.GetComponent<Renderer> ().enabled = false;
		} else if(blinking == false){
			text.GetComponent<Renderer> ().enabled = true;
		}
	}

	public IEnumerator Blink(){
		yield return new WaitForSeconds (1);
		blinking = !blinking;
		StartCoroutine (Blink());
	}
}
