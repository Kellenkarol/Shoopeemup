using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using General;
using Shoot;

namespace Player {

    public class PlayerCombat : MonoBehaviour
    {
        [Header("Game Object")]
        [SerializeField] private GameObject shootPrefab;
        [SerializeField] private Transform shootObjectParent;
        [SerializeField] private int shootPoolSize = 50;

        [Header("Attack")]
        [SerializeField] private float zSpawnDistanceToPlayer = .5f;
        [SerializeField] private float timeBetweenEachShoot = .1f;
        [SerializeField] private float weaponDamage = 4f;
        [SerializeField] private int weaponLevel = 1;

        [Header("Heat")]
        [SerializeField] private float heatLimit = 1f;
        [SerializeField] private float heatPerShoot = .2f;
        [SerializeField] private float coolingPerSecond = 1f;

        Queue<GameObject> shootPool;

        private float shootTimer = Mathf.Infinity;
        private float heatMeter = 0;
        private bool shooting;
        private bool heated;

        private void Awake()
        {
            shootPool = new Queue<GameObject>();

            for (int i = 0; i < shootPoolSize; i++)
            {
                GameObject objShoot = Instantiate(shootPrefab);
                objShoot.transform.parent = shootObjectParent;

                objShoot.SetActive(false);
                shootPool.Enqueue(objShoot);
            }

            FindObjectOfType<Overcharge>().OverchargeRecovery = 1/heatLimit;
        }

        private void Update()
        {
            if (heatMeter >= 0) heatMeter -= Time.deltaTime * coolingPerSecond;
            else heated = false;

            FindObjectOfType<Overcharge>().Shoots = (int)(heatMeter * 100 / heatLimit);
            if (CanShoot())
            {
                ActivateShoots();
                shootTimer = 0;
            }
            else shootTimer += Time.deltaTime;
        }

        private bool CanShoot()
        {
            return shooting && shootTimer > timeBetweenEachShoot && !heated;
        }

        private void ActivateShoots()
        {
            FindObjectOfType<AudioManager>().Play(AudioList.playerShoot);
            GameObject spawnedShoot = shootPool.Dequeue();

            spawnedShoot.SetActive(true);
            spawnedShoot.GetComponent<ShootBehavior>().SetDamage(weaponDamage);

            spawnedShoot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zSpawnDistanceToPlayer);
            spawnedShoot.transform.eulerAngles = Vector3.zero;

            shootPool.Enqueue(spawnedShoot);

            heatMeter += heatPerShoot;

            if (heatMeter >= heatLimit) heated = true;
        }

        public void InputToCombat(bool isShooting)
        {
            shooting = isShooting;
        }
    }
}
