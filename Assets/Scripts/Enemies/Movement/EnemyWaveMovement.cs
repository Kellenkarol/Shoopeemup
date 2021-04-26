using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Enemies
{
    public class EnemyWaveMovement : MonoBehaviour, IEnemyMovement
    {
        [SerializeField] private bool movingRight = true;
        [SerializeField] private float horizontalSpeed = 5f;
        [SerializeField] private float verticalSpeed = 4f;
        [SerializeField] private bool isDebugging = false;
        
        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            if(isDebugging) CheckPosition();
        }

        private void FixedUpdate()
        {
            if (movingRight)
            {
                rb.AddForce(horizontalSpeed, 0, 0);
                if (transform.position.x > 0) movingRight = false;
            }

            else
            {
                rb.AddForce(-horizontalSpeed, 0, 0);
                if (transform.position.x < 0) movingRight = true;
            }

            rb.velocity = new Vector3(rb.velocity.x, 0, -verticalSpeed);
        }

        public void ResetEnemyMovement()
        {
            rb.velocity = Vector3.zero;
        }

        public void CheckPosition()
        {
            if (transform.position.z < 0)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180 - transform.eulerAngles.y, transform.eulerAngles.z);
                verticalSpeed *= -1;
            }
        }
    }
}
