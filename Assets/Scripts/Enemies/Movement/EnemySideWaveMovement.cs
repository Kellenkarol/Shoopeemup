using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Enemies
{
    public class EnemySideWaveMovement : MonoBehaviour, IEnemyMovement
    {
        [SerializeField] private bool movingUp = true;
        [SerializeField] private float horizontalSpeed = 2f;
        [SerializeField] private float verticalSpeed = 4f;
        [SerializeField] private bool isDebugging = false;

        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            if (isDebugging) CheckPosition();
        }

        private void FixedUpdate()
        {
            if (movingUp)
            {
                rb.AddForce(0, 0, verticalSpeed);
                if (transform.position.z > 0) movingUp = false;
            }

            else
            {
                rb.AddForce(0, 0, -verticalSpeed);
                if (transform.position.z < 0) movingUp = true;
            }

            rb.velocity = new Vector3(horizontalSpeed, 0, rb.velocity.z);
        }

        public void ResetEnemyMovement()
        {
            rb.velocity = Vector3.zero;
        }

        public void CheckPosition()
        {
            if (transform.position.x < 0) transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180 - transform.eulerAngles.y, transform.eulerAngles.z);
            else horizontalSpeed *= -1;
        }
    }
}
