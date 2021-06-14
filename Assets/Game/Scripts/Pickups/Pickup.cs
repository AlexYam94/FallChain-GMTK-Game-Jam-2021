using UnityEngine;

namespace GameJam.Pickups{
    public abstract class Pickup : MonoBehaviour{
        // [SerializeField] protected AudioSource pickupSound;

        void OnTriggerEnter2D(Collider2D other){
            if(other.gameObject.tag == "Player"){
                // if(pickupSound != null) 
                //     pickupSound.Play();
                if(!CanCollect(other.gameObject)) return;
                Collect(other.gameObject);
                gameObject.SetActive(false);
            }
        }

        protected virtual bool CanCollect(GameObject other){ return true;} 

        protected abstract void Collect(GameObject other);
    }
}