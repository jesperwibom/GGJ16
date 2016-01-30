using UnityEngine;
using System.Collections;

public class SimpleEnemyFire : MonoBehaviour {

	public float interval = 2f;
	public Rigidbody2D proj;
	public Transform spawnPosition;

	// Use this for initialization
	void Start () {
		StartCoroutine (Fire ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

	}

	private IEnumerator Fire(){
		yield return new WaitForSeconds(interval);
		Rigidbody2D projectileInstance = Instantiate (proj, spawnPosition.position, spawnPosition.rotation) as Rigidbody2D;
		StartCoroutine (Fire ());
	}
}
