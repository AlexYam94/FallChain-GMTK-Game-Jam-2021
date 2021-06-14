using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : Collector
{
    protected override void Collect(Collider2D target)
    {
		if(target.CompareTag("Background")){
			target.gameObject.SetActive(false);
		}
    }
}
