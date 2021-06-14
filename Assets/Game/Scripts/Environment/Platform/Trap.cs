using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJam.Control;
using GameJam.Attributes;

namespace GameJam.Environments
{



    public class Trap : MonoBehaviour
    {
        [SerializeField] int damageValue = 2;
        [SerializeField] AudioSource damageSound;
        [SerializeField] AudioSource electricalSound;
        [SerializeField] float damageInterval = 1f;
        [SerializeField] Transform damagePosition;

        HealthController healthController;
        GameObject[] players;
        float timeSinceLastDamage;

        private void Awake() {
            healthController = GameObject.FindObjectOfType<HealthController>();
            players = GameObject.FindGameObjectsWithTag("Player");
            timeSinceLastDamage = damageInterval;
        }

        private void Update() {
            if(!electricalSound.isPlaying){
                electricalSound.Play();
            }
            timeSinceLastDamage += Time.deltaTime;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && timeSinceLastDamage > damageInterval)
            {
                timeSinceLastDamage = 0;
                if(!damageSound.isPlaying){
                    damageSound.Play();
                }
                healthController.ApplyDamage(damageValue);
                foreach (var player in players)
                {
                    player.GetComponent<Control.CharacterController>().ApplyDamage(0,damagePosition.position, 60f);
                }
                // other.gameObject.GetComponent<Control.CharacterController>().ApplyDamage(0,transform.position+Vector3.up*5);
            }
        }
    }
}