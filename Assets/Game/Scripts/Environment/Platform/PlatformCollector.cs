using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollector : Collector
{
    protected override void Collect(Collider2D target)
    {
        if(target.CompareTag("Platform") || target.CompareTag("Coin") || target.CompareTag("Trap")){
            target.gameObject.SetActive(false);
        }
    }

}
