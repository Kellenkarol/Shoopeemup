using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Enums;

namespace Player
{
    public class PlayerCollision : MonoBehaviour, IHitable
    {
        private PlayerController playerController;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
        }

        public void DeliverDamage(float damageValue)
        {
            playerController.RegisterDamage(damageValue);
        }

        public void DeliverBonus(ColectableType colectableType, float value)
        {
            if (colectableType == ColectableType.energy) playerController.AddEnergy(value);
            else if (colectableType == ColectableType.health) playerController.AddHealth(value);
            else if (colectableType == ColectableType.money) playerController.AddMoney(value);
        }
    }
}
