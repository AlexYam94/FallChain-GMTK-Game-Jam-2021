using UnityEngine;
using GameJam.Control;

namespace GameJam.Environments{
    public class JumpPad : MonoBehaviour{
        [SerializeField] int jumpForce = 1000;

        void OnTriggerStay2D(Collider2D other){
            if(other.gameObject.tag == "Player"){
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(jumpForce*transform.up);
                // other.gameObject.GetComponent<Control.CharacterController>().Jump((float)jumpForce);
            }
        }
    }
}