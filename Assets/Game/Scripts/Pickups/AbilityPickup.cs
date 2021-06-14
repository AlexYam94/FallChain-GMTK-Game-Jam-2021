using GameJam.Manager;
using UnityEngine;

namespace GameJam.Pickups{
    public class AbilityPickup: Pickup{
        [SerializeField] PlayerAbility abilityType;

        protected override void Collect(GameObject other){
            if(other.gameObject.tag == "Player"){
                PickupManager.GetInstance().ActivateAbility(abilityType);
            }
        }
    }
}