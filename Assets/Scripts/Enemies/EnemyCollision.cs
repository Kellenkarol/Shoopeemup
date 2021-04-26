using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Enums;

namespace Enemies
{
    public class EnemyCollision : MonoBehaviour, IHitable
    {
        private EnemyController enemyController;

        [SerializeField] private float collisionDamage = 30f;
        [SerializeField] private string edgeWallTag = "EdgeWall";

        private void Awake()
        {
            enemyController = GetComponent<EnemyController>();
        }

        public void DeliverDamage(float damageValue)
        {
            enemyController.RegisterDamage(damageValue);
        }

        public void DeliverBonus(ColectableType colectableType, float value)
        {
            throw new System.NotImplementedException();
        }

        public float GetDamage()
        {
            return collisionDamage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(edgeWallTag))
            {
                enemyController.DeactivateEnemy();
            }
        }
    }
}
