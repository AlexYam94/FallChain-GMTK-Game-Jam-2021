using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	[SerializeField] private float easySpeed = 3.2f;
	[SerializeField] private float MediumSpeed = 3.7f;
	[SerializeField] private float HardSpeed = 4.2f;
	[SerializeField] public float accelration = 0.2f;	

	private float speed = 1f;				
	private float maxSpeed = 3.2f;


	//[HideInInspector]
	private bool moveCamera=true;

	public void StopCamera(){
		moveCamera = false;
	}

	// Use this for initialization
	void Start () {
		if (GamePreferences.GetEasyDifficultyState () == 1)
			maxSpeed = easySpeed;

		moveCamera = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (moveCamera) {
			MoveCamera ();
		}

	}

	void MoveCamera(){
		Vector3 temp = transform.position;

		float oldY = temp.y;
		float newwY = temp.y - (speed * Time.deltaTime);
		temp.y = Mathf.Clamp (temp.y, oldY, newwY);
		transform.position = temp;
		speed +=accelration*Time.deltaTime;
		if(speed > maxSpeed)
			speed = maxSpeed;

	}
}
