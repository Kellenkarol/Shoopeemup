using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Enemies
{
    public class EnemySideSlowMovement : MonoBehaviour, IEnemyMovement
    {
        [SerializeField] private float horizontalSpeed = 1.5f;
        [SerializeField] private bool isDebugging = false;

        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            if (isDebugging) CheckPosition();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector3(horizontalSpeed, 0, 0);
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
