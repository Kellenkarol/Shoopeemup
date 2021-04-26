using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Shoot
{
    public class ShootBehavior : MonoBehaviour
    {
        [SerializeField] private float shootSpeed = 20f;
        [SerializeField] private string edgeWallTag = "EdgeWall";
        [SerializeField] private string enemyTag = "Enemy";
        private Rigidbody rb;

        private float damage;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rb.velocity = transform.forward * shootSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(edgeWallTag))
            {
                gameObject.SetActive(false);
            }
            else if (other.CompareTag(enemyTag))
            {
                if (other.GetComponent<IHitable>() != null) other.GetComponent<IHitable>().DeliverDamage(damage);
                gameObject.SetActive(false);
            }
        }

        public void SetBulletSpeed(float speed)
        {
            shootSpeed = speed;
        }

        public void SetDamage(float value)
        {
            damage = value;
        }

        public float GetDamage()
        {
            return damage;
        }
    }
}
