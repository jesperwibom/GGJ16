using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject life1;
	public GameObject life2;
	public GameObject life3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DrawHelmets(int no){
		life1.SetActive (false);
		life2.SetActive (false);
		life3.SetActive (false);
		if (no >= 1) {
			life1.SetActive (true);
		}
		if (no >= 2) {
			life2.SetActive (true);
		}
		if (no >= 3) {
			life3.SetActive (true);
		}
	}
}
