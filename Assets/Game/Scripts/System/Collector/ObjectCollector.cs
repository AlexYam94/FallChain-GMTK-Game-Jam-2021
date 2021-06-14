using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour {
	[SerializeField] string[] tags;

	void OnTriggerEnter2D(Collider2D target){
		// if (target.CompareTag ("Cloud") || target.CompareTag ("Deadly")) {
		// 	target.gameObject.SetActive(false);
		// }
		foreach (var item in tags)
		{
			if(target.CompareTag(item)){
				target.gameObject.SetActive(false);
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
