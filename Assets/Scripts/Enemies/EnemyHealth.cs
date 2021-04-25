using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float MaxHealth = 15f;

        private float currentHealth;

        private bool isAlive = true;

        private void Awake()
        {
            currentHealth = MaxHealth;
        }

        public void RecieveDamage(float damage)
        {
            currentHealth -= damage;

            if(currentHealth <= 0)
            {
                isAlive = false;
            }
        }

        public void fillHearth()
        {
            currentHealth = MaxHealth;
            isAlive = true;
        }

        public bool GetIsAlive()
        {
            return isAlive;
        }
    }
}
