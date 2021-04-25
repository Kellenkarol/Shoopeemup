using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

namespace Enemies
{
    [RequireComponent(typeof(EnemyCollision))]
    [RequireComponent(typeof(EnemyCombat))]
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyController : MonoBehaviour
    {
        private EnemyCollision enemyCollision;
        private EnemyCombat enemyCombat;
        private EnemyHealth enemyHealth;
        private IEnemyMovement enemyMovement;

        private void Awake()
        {
            enemyHealth = GetComponent<EnemyHealth>();
            enemyCombat = GetComponent<EnemyCombat>();
            enemyCollision = GetComponent<EnemyCollision>();
            enemyMovement = GetComponent<IEnemyMovement>();
        }

        private void Update()
        {
            if (!enemyHealth.GetIsAlive()) gameObject.SetActive(false);
        }

        public void ActivateEnemy()
        {
            enemyHealth.fillHearth();
            enemyMovement.ResetEnemyMovement();
        }

        public void RegisterDamage(float value)
        {
            enemyHealth.RecieveDamage(value);
        }
    }
}
