using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

public class deathScreen : MonoBehaviour {
	bool blinking = false;
	bool delayed;

	GameObject text;
	// Use this for initialization
	void Start () {
		text = gameObject;
		StartCoroutine (Blink());
		StartCoroutine (Delayer ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown && delayed == true){
			Debug.Log ("starting!");
			#if UNITY_EDITOR
			EditorSceneManager.LoadScene ("StartScene");
			#endif
			Application.LoadLevel ("StartScene");
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
	public IEnumerator Delayer(){
		yield return new WaitForSeconds (2);
		delayed = true;
	}
}
