using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam.System
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.gameObject.CompareTag("Player")){
                SceneLoader.GetInstance().LoadGameOverMenu();
            }
        }   
    }
}
