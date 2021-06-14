using System;
using GameJam.System;
using UnityEngine;

namespace GameJam.Pickups
{
    public class CoinPickup : Pickup
    {
        [SerializeField] int _coinAmount = 1;
        
        override protected void Collect(GameObject other){
            SoundController.GetInstance().PlayCoinSound();
            if(other.gameObject.name.Equals("Player 1"))
                PickupManager.GetInstance().AddPlayer1Coin(_coinAmount);
            if(other.gameObject.name.Equals("Player 2"))
                PickupManager.GetInstance().AddPlayer2Coin(_coinAmount);
        }
    }
}