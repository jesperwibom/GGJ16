using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

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
			#if UNITY_EDITOR
			EditorSceneManager.LoadScene ("StartScene");
			#endif
			Application.LoadLevel ("StartScene");
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
