using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Enums;
using System;

namespace Enemies
{
    public class AsteroidBehavior : MonoBehaviour, IHitable
    {
        public enum Xspeed
        {
            positive,
            negative
        }

        [Header("Properties")]
        [SerializeField] private float damage = 30f;
        [SerializeField] private float Health = 20f;

        [Header("Movement")]
        [SerializeField] private Xspeed horizontalDirection;
        [SerializeField] private float horizontalSpeed = 2f;
        [SerializeField] private float horizontalVariance = 1f;
        [SerializeField] private float verticalAcceleration = 7f;
        [SerializeField] private float verticalVariance = 1f;

        [Header("Hitables")]
        [SerializeField] private string edgeWallTag = "EdgeWall";
        [SerializeField] private string playerTag = "Player";
        
        private Rigidbody rb;
        private float currentHealth;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            horizontalVariance = horizontalSpeed - UnityEngine.Random.Range(horizontalSpeed - horizontalVariance, horizontalSpeed + horizontalVariance);
            verticalVariance = verticalAcceleration - UnityEngine.Random.Range(verticalAcceleration - verticalVariance, verticalAcceleration + verticalVariance);

            if (horizontalDirection == Xspeed.negative) horizontalSpeed *= -1;

            currentHealth = Health;
        }

        private void FixedUpdate()
        {
            rb.AddForce(-transform.forward * (verticalAcceleration + verticalVariance));
            rb.velocity = new Vector3(horizontalSpeed + horizontalVariance, 0, rb.velocity.z);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(edgeWallTag))
            {
                gameObject.SetActive(false);
            }
            else if (other.CompareTag(playerTag))
            {
                if (other.GetComponent<IHitable>() != null) other.GetComponent<IHitable>().DeliverDamage(damage);
                gameObject.SetActive(false);
            }
        }

        public void DeliverDamage(float damageValue)
        {
            currentHealth -= damageValue;

            if (currentHealth <= 0) Destroyed();
        }

        public float GetDamage()
        {
            return damage;
        }

        private void Destroyed()
        {
            gameObject.SetActive(false);
        }

        public void DeliverBonus(ColectableType colectableType, float value)
        {
            throw new System.NotImplementedException();
        }
    }
}
