using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInputs))]
    [RequireComponent(typeof(PlayerCombat))]
    [RequireComponent(typeof(PlayerHealth))]
    [RequireComponent(typeof(PlayerMovements))]
    [RequireComponent(typeof(PlayerCollision))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputs playerInputs;
        private PlayerCombat playerCombat;
        private PlayerHealth playerHealth;
        private PlayerMovements playerMovements;
        private PlayerCollision playerCollision;

        private void Awake()
        {
            playerInputs = GetComponent<PlayerInputs>();
            playerCombat = GetComponent<PlayerCombat>();
            playerHealth = GetComponent<PlayerHealth>();
            playerMovements = GetComponent<PlayerMovements>();
            playerCollision = GetComponent<PlayerCollision>();
        }

        private void Update()
        {
            if (playerMovements.GetNoFuel() || playerHealth.GetIsDestroyed())
            {
                playerInputs.enabled = false;
                playerCombat.enabled = false;
                playerHealth.enabled = false;
                playerMovements.enabled = false;
                this.enabled = false;
            }
            else
            {
                playerCombat.InputToCombat(playerInputs.GetShootButtonPressed());
                playerHealth.InputToHealth(playerInputs.GetShieldButtonPressed());
            }
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            playerMovements.InputToMovement(playerInputs.GetMovementDirection());
        }

        public void RegisterDamage(float value)
        {
            playerHealth.RecieveDamage(value);
        }

        public void AddHealth(float value)
        {
            playerHealth.IncrementCurrentHealth(value);
        }

        public void AddEnergy(float value)
        {
            playerHealth.IncrementCurrentEnergy(value);
        }

        public void AddFuel(float value)
        {
            playerMovements.AddFuelToTank(value);
        }
    }
}