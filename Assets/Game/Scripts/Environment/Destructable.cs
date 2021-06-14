using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Projectile"){
            Destroy(gameObject);
        }
    }
}
