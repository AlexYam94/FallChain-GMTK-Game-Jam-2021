using UnityEngine;

namespace GameJam.Pickups
{
    public class HealthPickup : Pickup
    {
        [SerializeField] int _healAmount = 1;

        protected override void Collect(GameObject other)
        {
            PickupManager.GetInstance().AddHealth(_healAmount);
        }

        protected override bool CanCollect(GameObject other){
            return !PickupManager.GetInstance().IsHealthFull(other);
        }

    }
}