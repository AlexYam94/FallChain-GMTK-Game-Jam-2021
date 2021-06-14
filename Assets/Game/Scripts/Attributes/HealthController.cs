using System.Collections;
using System.Collections.Generic;
using GameJam.System;
using UnityEngine;

namespace GameJam.Attributes
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] float healthPoints = 10;

        float maxHealth;

        // Start is called before the first frame update
        private void Awake() {
        }

        private void Start() {
            maxHealth = healthPoints;
        }

        // Update is called once per frame
        void Update()
        {
            if(healthPoints <= 0){
                UIController.GetInstance().DisableHealthBar();
                SceneLoader.GetInstance().LoadGameOverMenu();
            }else{
                UIController.GetInstance().EnableHealthBar();
            }
        }

        public void Heal(float healAmount){
            healthPoints+=healAmount;
        }

        public float GetHealth(){
            return healthPoints;
        }

        public float GetPercentage(){
            return healthPoints/maxHealth * 100;
        }

        public float GetFraction(){
            return healthPoints/maxHealth;
        }

        public void ApplyDamage(float damage){
            healthPoints = Mathf.Clamp(healthPoints - damage, 0, 999);
        }
    }
}
