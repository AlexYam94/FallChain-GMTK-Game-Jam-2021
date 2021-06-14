using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collector : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D target){
        Collect(target);
	}

    protected abstract void Collect(Collider2D target);

}
