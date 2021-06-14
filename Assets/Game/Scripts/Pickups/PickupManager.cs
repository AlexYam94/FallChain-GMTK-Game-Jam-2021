using GameJam.Attributes;
using GameJam.Manager;
using UnityEngine;

namespace GameJam.Pickups{
    public class PickupManager: Singleton<PickupManager>{
        GameObject _player = null;

        protected override void Init()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        public void AddHealth(int healAmount){
            HealthController health = _player.GetComponent<HealthController>();
            health.Heal(healAmount);
        }

        public void AddPlayer1Coin(int coinAmount){
            GameManager.GetInstance().AddPlayer1Score(coinAmount);
        } 
        
        public void AddPlayer2Coin(int coinAmount){
            GameManager.GetInstance().AddPlayer2Score(coinAmount);
        } 

        public void ActivateAbility(PlayerAbility ability){
            GameManager.GetInstance().ActivateAbility(ability);
        }

        public bool IsHealthFull(GameObject other){
            if(other.gameObject.tag == "Player"){
                return other.GetComponent<HealthController>().GetFraction() == 1;
            }
            return false;
        }
    }
}