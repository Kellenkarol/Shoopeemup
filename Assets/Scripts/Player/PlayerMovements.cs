using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public enum movementMode
    {
        SpaceShooterType,
        AsteroidsType
    }

    public class PlayerMovements : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private float SpaceshipVelocity = 10f;
        [SerializeField] private movementMode movement;

        [Header("Fuel")]
        [SerializeField] private float fuelTank = 60f;
        [SerializeField] private float fuelCostPerSecond = 1f;

        [Header("Asteroids Type")]
        [SerializeField] private float decelerationFactor = .04f;
        [SerializeField] private float angularVelocity = 180f;

        [SerializeField] private float currentFuel;
        private bool noFuel = false;

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            currentFuel = fuelTank;
        }

        public void InputToMovement(Vector2 direction)
        {
            Move(direction);
        }

        private void Update()
        {
            currentFuel -= Time.deltaTime * fuelCostPerSecond;

            if (currentFuel <= 0) noFuel = true;
        }

        private void Move(Vector2 direction)
        {
            if (noFuel) return;

            Vector3 speed = new Vector3(direction.x, 0, direction.y) * SpaceshipVelocity;

            if (movement == movementMode.SpaceShooterType) rb.velocity = speed;
            else
            {
                if (direction.x != 0) rb.angularVelocity = new Vector3(0, -direction.x, 0) * angularVelocity;
                else rb.angularVelocity -= rb.angularVelocity * decelerationFactor;

                if (direction.y != 0) rb.AddForce(transform.up * SpaceshipVelocity * direction.y);
                else rb.velocity -= rb.velocity * decelerationFactor;

                if (rb.velocity.magnitude > SpaceshipVelocity) rb.velocity = rb.velocity.normalized * SpaceshipVelocity;
            }
        }

        public bool GetNoFuel()
        {
            return noFuel;
        }

        public void AddFuelToTank(float fuel)
        {
            currentFuel += fuel;
        }
    }
}
