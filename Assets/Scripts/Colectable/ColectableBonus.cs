using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Enums;

namespace Colectable
{
    public class ColectableBonus : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] private ColectableType colectableType;
        [SerializeField] private float value;
        [SerializeField] private float speed = 2f;

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
            rb.velocity = -transform.forward * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(edgeWallTag))
            {
                gameObject.SetActive(false);
            }
            else if (other.CompareTag(playerTag))
            {
                if (other.GetComponent<IHitable>() != null) other.GetComponent<IHitable>().DeliverBonus(colectableType, value);
                gameObject.SetActive(false);
            }
        }
    }
}