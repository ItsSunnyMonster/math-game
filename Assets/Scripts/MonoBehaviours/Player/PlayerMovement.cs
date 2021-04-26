//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using Classes;
using UnityEngine;

namespace MonoBehaviours.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
        public Transform groundCheck;
        public LayerMask groundMask;

        private Vector3 _yVelocity;

        public float speed = 12f;
        public float groundDistance = 0.4f;
        public float gravity = -19.62f;
        public float jumpHeight = 3f;

        private bool _isGrounded;

        #region WORLD_BORDER

        public float maxX = 170f;
        public float minX = -110f;
        public float maxZ = 140f;
        public float minZ = -130f;
        public float lineHeight = 88f;

        #endregion

        private void Update()
        {
            //do ground check
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (_isGrounded && _yVelocity.y < 0)
            {
                _yVelocity.y = -2f;
            }

            //get input
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");

            //move the player based on input
            var move = transform.right * x + transform.forward * z;
            controller.Move(move * (speed * Time.deltaTime));

            //check for jumping input and jump if button down
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _yVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            //move the player based on gravity
            _yVelocity.y += gravity * Time.deltaTime;
            controller.Move(_yVelocity * Time.deltaTime);
        }

        private void LateUpdate()
        {
            //move the player back if out of bounds
            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }
            if (transform.position.z > maxZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
            }
            if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }
            if (transform.position.z < minZ)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
            }

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            
            //draw world border
            HelperFunctions.DrawBoundaryAsGizmos(maxX, minX, maxZ, minZ, lineHeight);
        }
    }
}
