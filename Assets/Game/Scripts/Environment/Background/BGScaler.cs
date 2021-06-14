using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		Vector3 tempScale = transform.localScale;

		float width = sr.sprite.bounds.size.x;

		// float worldHeight = Camera.main.orthographicSize * 2f;
		// float worldWidth = worldHeight / Screen.height * Screen.width;

		var topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		var worldWidth = topRightCorner.x * 2;
		var worldSpaceHeight = topRightCorner.y * 2;

		tempScale.y = worldWidth / width;
		transform.localScale = tempScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
