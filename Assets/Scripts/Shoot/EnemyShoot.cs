using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Shoot
{
    public class EnemyShoot : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private float damage = 10f;
        [SerializeField] private float shootSpeed = 4f;

        [Header("Hitables")]
        [SerializeField] private string edgeWallTag = "EdgeWall";
        [SerializeField] private string playerTag = "Player";
        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rb.velocity = -transform.up * shootSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(edgeWallTag))
            {
                gameObject.SetActive(false);
            }
            else if (other.CompareTag(playerTag))
            {
                if(other.GetComponent<IHitable>() != null) other.GetComponent<IHitable>().DeliverDamage(damage);
                gameObject.SetActive(false);
            }
        }
    }
}
