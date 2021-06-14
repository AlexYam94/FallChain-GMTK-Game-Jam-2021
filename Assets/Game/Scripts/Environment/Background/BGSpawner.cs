using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : Spawner {
	private GameObject[] backgrounds;
	// private float lastY;
	private GameObject lastBackground;
	// Use this for initialization

	protected override void GetBackgroundsAndSetLastObj(){
		backgrounds = GameObject.FindGameObjectsWithTag("Background");
		float lastY = backgrounds [0].transform.position.y;

		for (int i = 1; i < backgrounds.Length; i++) {
			if (lastY > backgrounds [i].transform.position.y) {
				lastY = backgrounds [i].transform.position.y;
				lastBackground = backgrounds[i];
			}
		}
	}

	protected override void Spawn(Collider2D target){
		if(target.CompareTag("Background")){
			// if(target.transform.position.y == lastY){
			// 	Vector3 temp = target.transform.position;
			// 	float height = ((BoxCollider2D)target).size.y;

			// 	for(int i =0;i<backgrounds.Length;i++){
			// 		if(!backgrounds[i].activeInHierarchy){
			// 			temp.y -= height;

			// 			lastY = temp.y;

			// 			backgrounds[i].transform.position=temp;
			// 			backgrounds[i].SetActive(true);
			// 		}
			// 	}
			// }
			
			Vector3 temp = target.transform.position;
			float height = ((BoxCollider2D)target).size.x;
			float lastY = lastBackground.transform.position.y;
			for(int i =0;i<backgrounds.Length;i++){
				if(!backgrounds[i].activeInHierarchy){
					temp.y = lastY - height;
					lastY = temp.y;
					lastBackground = backgrounds[i];
					backgrounds[i].transform.position=temp;
					backgrounds[i].SetActive(true);
				}
			}
		}
	}
}
