using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperatorSpawner : Spawner
{
	[SerializeField] GameObject[] seperators;
	// private float lastY;
	private GameObject lastSeperator;


	protected override void GetBackgroundsAndSetLastObj(){
		// seperators = GameObject.FindGameObjectsWithTag("Seperator");
		float lastY = seperators [0].transform.position.y;

		for (int i = 1; i < seperators.Length; i++) {
			if (lastY > seperators [i].transform.position.y) {
				lastY = seperators [i].transform.position.y;
				lastSeperator = seperators[i];
			}
		}
	}

    protected override void Spawn(Collider2D target){
		if(target.CompareTag("Seperator")){
			
			Vector3 temp = target.transform.position;
			float height = ((BoxCollider2D)target).size.x;
			float lastY = lastSeperator.transform.position.y;
			for(int i =0;i<seperators.Length;i++){
				if(!seperators[i].activeInHierarchy){
					temp.y = lastY - height;
					lastY = temp.y;
					lastSeperator = seperators[i];
					seperators[i].transform.position=temp;
					seperators[i].SetActive(true);
				}
			}
		}
	}
}
