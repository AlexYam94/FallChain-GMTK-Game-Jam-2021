using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeperatorCollector : Collector
{
    protected override void Collect(Collider2D target)
    {
		if(target.CompareTag("Seperator")){
			target.gameObject.SetActive(false);
		}
    }
}
