using UnityEngine;
using System.Collections;

public class startScript : MonoBehaviour {

	public GameObject rend;
	bool blinking = true;
	// Use this for initialization
	void Start () {
		rend = gameObject;
		StartCoroutine (BlinkText ());
	}
	
	// Update is called once per frame
	void Update () {
		if(blinking == false){
			rend.GetComponent<Renderer> ().enabled = true;
		} else if(blinking == true){
			rend.GetComponent<Renderer> ().enabled = false;
		}
	}

	private IEnumerator BlinkText(){
		yield return new WaitForSeconds (1);
		blinking = !blinking;
		StartCoroutine(BlinkText());
	}
}
