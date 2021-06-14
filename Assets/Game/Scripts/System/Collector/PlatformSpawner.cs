using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : Spawner {

	[SerializeField] private GameObject[] paltforms;
	[SerializeField] Transform minPosition;
	[SerializeField] Transform maxPosition;
	private float distanceBetweenPlatform =3f;
	private float minX,maxX;
	private float lastPlatformPositionY;
	[SerializeField]
	private GameObject[] collectables;
	private float controlX;
	[SerializeField] private GameObject player;


	void Awake(){
		controlX = 0;
		SetMinAndMaxX ();
		CreatePlatform ();
		// player = GameObject.Find ("Player");

		for (int i = 0; i < collectables.Length; i++) {
			collectables[i].SetActive (false);
			}
	}

	// Use this for initialization
	protected override void Init () {
		
		// PositionThePlayer ();
		// Vector3 temp = player.transform.position;
		// temp.y = paltforms[0].transform.position.y;
		// paltforms[0].transform.position = temp;
	}

	protected override void Spawn(Collider2D target){
		if (target.CompareTag ("Platform") || target.CompareTag ("Trap")) {

				Vector3 temp = target.transform.position;

				for (int i = 0; i < paltforms.Length; i++) {
					if (!paltforms [i].activeInHierarchy) {
						temp.x = Random.Range (minX, maxX);
						temp.y = lastPlatformPositionY - distanceBetweenPlatform;

						lastPlatformPositionY = temp.y;

						paltforms [i].transform.position = temp;

						paltforms [i].SetActive (true);

						int random = Random.Range (0, collectables.Length);
						if (!paltforms [i].CompareTag ("Trap")) {
							if (!collectables [random].activeInHierarchy) {
								Vector3 temp2 = paltforms [i].transform.position;
								temp2.y += 0.7f;
								collectables[random].transform.position = temp2;
								collectables[random].SetActive(true);
							}
						}
					}
				}
		}
	}

	void SetMinAndMaxX(){
		minX = minPosition.position.x;
		maxX = maxPosition.position.x;
	}

	void Shuffle(GameObject[] arrayToShuffle){
		for (int i = 0; i < arrayToShuffle.Length; i++) {
			GameObject temp = arrayToShuffle [i];
			int random = Random.Range (i,arrayToShuffle.Length);
			arrayToShuffle [i] = arrayToShuffle [random];
			arrayToShuffle [random] = temp;

			//GameObject temp = arrayToShuffle[i]; - arrayToShuffle[i] = 3, meaning temp = 3;
			//arrayToShuffle[i] = arrayToShuffle[random];, it had a value of arrayToShuffle = 3;
			//let say arrayTosShuffle[random] = 5; arrayToShuffle[i] = 5;
			//Thats why we save it in temp
			//now we take arrrayToShuffle[random] which at the moment has the value of 5 
			//arrayToShuffle[random] = temp;

		}
	}

	void CreatePlatform(){
		Shuffle (paltforms);
		float positionY = 0;
		for (int i = 0; i < paltforms.Length; i++) {
			Vector3 temp = paltforms [i].transform.position;
			temp.y = positionY;
			temp.x = Random.Range (minX, maxX);
			if(paltforms[i].gameObject.CompareTag("Trap")){
				while(Mathf.Abs(temp.x - player.transform.position.x)<2){
					temp.x = Random.Range (minX, maxX);
				}
			}
			// if (controlX == 0) {
			// 	temp.x = Random.Range (0.0f, maxX);
			// 	controlX = 1;
			// } else if (controlX == 1) {
			// 	temp.x = Random.Range (0.0f, minX);
			// 	controlX = 2;
			// } else if (controlX == 2) {
			// 	temp.x = Random.Range (1.0f, maxX);
			// 	controlX = 3;
			// } else if (controlX == 3) {
			// 	temp.x = Random.Range (-1.0F, minX);
			// 	controlX = 0;
			// }

			lastPlatformPositionY = positionY;
			paltforms [i].transform.position = temp;
			positionY -= distanceBetweenPlatform;
		}
	}

	void PositionThePlayer(){
		GameObject[] traps = GameObject.FindGameObjectsWithTag ("Trap");
		GameObject[] platformsInGame = GameObject.FindGameObjectsWithTag ("Platform");

		for (int i = 0; i < traps.Length; i++) {
			if (traps [i].transform.position.y == 0f) {
				Vector3 temp = traps [i].transform.position;
				traps [i].transform.position = new Vector3 (platformsInGame [0].transform.position.x,
					platformsInGame [0].transform.position.y,
					platformsInGame [0].transform.position.z);
				platformsInGame [0].transform.position = temp;
			}
		}

		Vector3 ttemp = platformsInGame [0].transform.position;
		for(int i = 0; i < platformsInGame.Length;i++){
			if(ttemp.y<platformsInGame[i].transform.position.y){
				ttemp = platformsInGame [i].transform.position;
			}
		}

		ttemp.y += 5;
		player.transform.position = ttemp;

	}
}
