using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes.Debug.Sample
{
    public class MovPersonaje1 : MonoBehaviour
    {
        public CharacterController controller;
        public float speed = 8f;
        public float bonus = 0.5f;
        
        public float gravity = -9.81f;
        public float jumpForce = 3f;

        private Vector3 _velocity;


        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            float magnitude = Mathf.Sqrt(x * x + z * z);
            if (magnitude > controller.minMoveDistance)
            {
                float totalSpeed = speed;
                _velocity.x = (x / magnitude) * totalSpeed;
                _velocity.z = (z / magnitude) * totalSpeed;
            }
            else
            {
                _velocity.x = _velocity.z = 0;
            }

            float minGravMove = controller.minMoveDistance * 1.1f / Time.deltaTime;
            if (controller.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _velocity.y = jumpForce;
                    
                }
                else
                    _velocity.y = -minGravMove;
            }
            else
            {
                var verticalVel = Mathf.Abs(_velocity.y);
                if (verticalVel < minGravMove)
                    _velocity.y = minGravMove * (_velocity.y <= 0 ? -1 : 1);

                _velocity.y += gravity * Time.deltaTime;
            }

            var collisionFlag = controller.Move(_velocity * Time.deltaTime);
        }
    }
}