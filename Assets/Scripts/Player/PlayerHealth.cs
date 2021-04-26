using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private float maxHealth = 100f;

        [Header("Shield")]
        [SerializeField] private GameObject shieldObject;
        [SerializeField] private float shieldDuration = 5f;
        [SerializeField] private float shieldHealth = 50f;
        [SerializeField] private float shieldEnergyCost = 20f;

        private PlayerController playerController;

        private float shieldTimer;
        private float currentEnergy;
        private float currentHealth;
        private float currentShieldHealth;

        private bool isShielding;
        private bool isDestroyed;

        public GameoverManager GM;
        public ShowDamagePlayer SDP;

        private void Awake()
        {
            currentEnergy = shieldEnergyCost;
            currentHealth = maxHealth;
            currentShieldHealth = shieldHealth;
            playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (isShielding)
            {
                shieldTimer -= Time.deltaTime;

                if(shieldTimer <= 0)
                {
                    shieldObject.SetActive(false);
                    isShielding = false;
                }
            }
        }

        public void InputToHealth(bool shield)
        {
            if (isShielding) return;

            if (currentEnergy >= shieldEnergyCost)
            {
                isShielding = shield;
                if (isShielding)
                {
                    FindObjectOfType<AudioManager>().Play(AudioList.playerShield);

                    shieldTimer = shieldDuration;
                    currentEnergy -= shieldEnergyCost;
                    shieldObject.SetActive(true);
                }
            }
        }

        public void RecieveDamage(float damage)
        {
            if (isShielding)
            {
                currentShieldHealth -= damage;
                if (currentShieldHealth <= 0)
                {
                    isShielding = false;
                    shieldObject.SetActive(false);
                    shieldTimer = 0;

                    currentShieldHealth = shieldHealth;
                }
            }

            else
            {
                currentHealth -= damage;
                SDP.Damage(maxHealth, currentHealth);
                if (currentHealth <= 0)
                {
                	isDestroyed = true;
                    FindObjectOfType<AudioManager>().Stop(AudioList.gameplayMusic);
                    FindObjectOfType<AudioManager>().Stop(AudioList.playerDestroyed);
                    playerController.ResetVelocity();
                    GM.StartGameOver();
            	}
                else
                {
                    FindObjectOfType<AudioManager>().Play(AudioList.playerDamaged);
                }
            }
        }

        public void IncrementCurrentHealth(float value)
        {
            currentHealth = value;
        }

        public void IncrementCurrentEnergy(float value)
        {
            currentEnergy = value;
        }

        public bool GetIsDestroyed()
        {
            return isDestroyed;
        }
    }
}