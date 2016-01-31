using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;

public class EndScreen : MonoBehaviour {
	bool blinking = false;
	GameObject pic;
	// Use this for initialization
	void Start () {
		pic = gameObject;
		StartCoroutine (Blink());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown){
			EditorSceneManager.LoadScene ("StartScene");
		}
		if(blinking == true){
			pic.GetComponent<Renderer> ().enabled = false;
		}else if(blinking == false){
			pic.GetComponent<Renderer> ().enabled = true;
		}
	}

	private IEnumerator Blink(){
		yield return new WaitForSeconds (1);
		blinking = !blinking;
		StartCoroutine (Blink());
	}
}
