using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {

	public float aimSpeed = 0.5f;
	public Transform spawnPosition;
	private Transform targetPosition;

	// Use this for initialization
	void Start () {
		targetPosition = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () {
		Vector3 dir = spawnPosition.transform.position - targetPosition.transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, aimSpeed * Time.deltaTime);
		/*
		Vector2 target = new Vector2(targetPosition.position.x, targetPosition.position.y);
		spawnPosition.LookAt(target);
		*/
	}
}
