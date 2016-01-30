using UnityEngine;
using System.Collections;

public class BossBehaviour : MonoBehaviour {

	GameObject penguin;
	public int startPositionX;
	public int startPositionY;
	public float roofPos;
	public float floorPos;
	public float moveSpeed;
	float speed = 0;
	float enemyPosition;
	float move = 0;
	public string tag;
	Animation anim;
	//Animation spawn;
	float spin = 0;
	float spinForce = 0;

	bool spawn = false;
	bool activate = false;
	bool moveUp = true;
	bool moveDown = false;
	bool spinCounter = false;
	public int spinCount = 0;
	Random rand;
	//Vector2 enemyAngle;
	// Use this for initialization
	void Start () {
		spawn = true;
		rand = new Random();
		penguin = gameObject;
		anim = penguin.GetComponent<Animation> ();
		enemyPosition = penguin.transform.position.y + speed;
	}



	// Update is called once per frame
	void Update () {
		if(spawn == true){
		anim.Play("spawn");
		}
		spawn = false;
		print (enemyPosition);
		if(spawn == false){
		Move();
		}
	}




	void Move(){
		penguin.transform.position = new Vector2 (startPositionX,startPositionY + speed);
		penguin.transform.Rotate (0, 0, spin);
		//enemyAngle = penguin.transform.rotation;

		if(speed > roofPos){
			moveUp = false;
			moveDown = true;
			spinCounter = true;
		} else if(speed < floorPos){
			spinCounter = true;
			moveDown = false;
			moveUp = true;
		}

		if(moveUp == true && moveDown == false){
			speed = speed + moveSpeed;
		} else if(moveUp == false && moveDown == true){
			speed = speed - moveSpeed;
		}
			
		if (spinCounter == true){
			spinCount = spinCount + 1;
			spinCounter = false;
		}

		if(spinCount > 2){
			anim.Play("spin");
				spinCount = 0 - Random.Range(1,3);
	}
	}
}
