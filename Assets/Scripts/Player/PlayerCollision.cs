using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Colectable;
using Enemies;
using General;
using Enums;
using Shoot;

namespace Player
{
    public class PlayerCollision : MonoBehaviour, IHitable
    {
        private PlayerController playerController;
        [SerializeField] private string enemyTag = "Enemy";
        [SerializeField] private string collectableTag = "Collectable";

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
            else if (colectableType == ColectableType.fuel) playerController.AddFuel(value);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(enemyTag))
            {
                if(other.GetComponent<EnemyCollision>() != null)
                {
                    other.GetComponent<EnemyCollision>().DeliverDamage(1000);
                    DeliverDamage(other.GetComponent<EnemyCollision>().GetDamage());
                }
                else if (other.GetComponent<ShootBehavior>() != null)
                {
                    DeliverDamage(other.GetComponent<ShootBehavior>().GetDamage());
                    other.gameObject.SetActive(false);
                }
            }

            else if (other.CompareTag(collectableTag))
            {
                if(other.GetComponent<ColectableBonus>().GetColectableType() == ColectableType.energy)
                {
                    FindObjectOfType<AudioManager>().Play(AudioList.energyCollected);
                    playerController.AddEnergy(other.GetComponent<ColectableBonus>().GetValue());
                }
                else if (other.GetComponent<ColectableBonus>().GetColectableType() == ColectableType.fuel)
                {
                    FindObjectOfType<AudioManager>().Play(AudioList.fuelCollected);
                    playerController.AddFuel(other.GetComponent<ColectableBonus>().GetValue());
                }
                else if (other.GetComponent<ColectableBonus>().GetColectableType() == ColectableType.health)
                {
                    FindObjectOfType<AudioManager>().Play(AudioList.healthCollected);
                    playerController.AddHealth(other.GetComponent<ColectableBonus>().GetValue());
                }
            }
        }
    }
}
