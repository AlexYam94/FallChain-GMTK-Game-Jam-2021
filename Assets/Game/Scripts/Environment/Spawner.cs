using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
        GetBackgroundsAndSetLastObj();
    }

    void OnTriggerEnter2D(Collider2D target){
        Spawn(target);
    }

    protected virtual void Spawn(Collider2D target){}
    protected virtual void GetBackgroundsAndSetLastObj(){}
    protected virtual void Init(){}
}
