using System.Collections;
using System.Collections.Generic;
using GameJam.Manager;
using GameJam.System;
using UnityEngine;
using UnityEngine.Events;

namespace GameJam.Control
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] PlayerType playerType;
        [SerializeField] Transform otherPlayerTransform;
        [SerializeField] float maxXDistanceToOtherPlayer = 10f;
        [SerializeField] AudioSource chainStretchSound;

        public CharacterController controller;
        public Animator animator;[Header("Feedbacks")]

        public float runSpeed = 40f;

        float horizontalMove = 0f;
        float verticalMove = 0f;
        bool jump = false;
        bool dash = false;
        bool crouch = false;
        // CableProceduralMultipoint chain;
        bool isChainStetched = false;

        //bool dashAxis = false;

        private void Awake()
        {
            GameManager.GetInstance().RestScore();
            // chain = GameObject.FindObjectOfType<CableProceduralMultipoint>();
        }

        // Update is called once per frame
        void Update()
        {

            // chain.SetSag(2);
            float xDistance = 0f;
            xDistance = Mathf.Abs(otherPlayerTransform.position.x - transform.position.x);
            // horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            if (playerType == PlayerType.one)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
                if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W))
                {
                    jump = true;
                }

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    dash = true;
                }
            }
            else
            {
                horizontalMove = Input.GetAxisRaw("P2_Horizontal") * runSpeed;
                if (Input.GetKeyDown(KeyCode.Keypad0)||Input.GetKeyDown(KeyCode.UpArrow))
                {
                    jump = true;
                }

                if (Input.GetKeyDown(KeyCode.Keypad1))
                {
                    dash = true;
                }
            }

            if (horizontalMove != 0)
            {
                SoundController.GetInstance().PlayChainSound();
                isChainStetched = false;
            }

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));



            /*if (Input.GetAxisRaw("Dash") == 1 || Input.GetAxisRaw("Dash") == -1) //RT in Unity 2017 = -1, RT in Unity 2019 = 1
            {
                if (dashAxis == false)
                {
                    dashAxis = true;
                    dash = true;
                }
            }
            else
            {
                dashAxis = false;
            }
            */

        }

        public void OnFall()
        {
            animator.SetBool("IsJumping", true);
        }

        public void OnLanding()
        {
            animator.SetBool("IsJumping", false);
        }

        public void OnExitCrouching()
        {
            animator.SetBool("IsCrouching", false);
            crouch = false;
        }

        void FixedUpdate()
        {
            // if (Input.GetKey(KeyCode.LeftControl))
            // {
            //     crouch = true;
            // }
            // Move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, jump, dash, crouch);
            jump = false;
            crouch = false;
            dash = false;
        }
    }

    public enum PlayerType
    {
        one,
        two
    }
}