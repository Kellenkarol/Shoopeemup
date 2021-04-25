using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shoot;

namespace Enemies
{
    public class EnemyCombat : MonoBehaviour
    {
        [Header("Shooting Pool")]
        [SerializeField] private GameObject enemyShootPrefab;
        [SerializeField] private int enemyShootPoolSize = 3;

        [Header("Shoot")]
        [SerializeField] private float shootSpeed;
        [SerializeField] private float weaponDamage = 10f;
        [SerializeField] private float timeBetweenShoots = 4;
        [SerializeField] private float shootTimeVariance = 2;
        [SerializeField] private float zSpawnDistanceToEnemy = 1.5f;

        private float currentShootTimeVariance;
        private float shootTimer = 0;

        private Queue<GameObject> shootPool;

        private void Awake()
        {
            shootPool = new Queue<GameObject>();
            Transform shootObjectParent = GameObject.Find("ShootObjects").transform;

            for (int i = 0; i < enemyShootPoolSize; i++)
            {
                GameObject objShoot = Instantiate(enemyShootPrefab);
                objShoot.transform.parent = shootObjectParent;

                objShoot.SetActive(false);
                shootPool.Enqueue(objShoot);
            }

            currentShootTimeVariance = GetNewShootTimeVariance();
        }

        private void Update()
        {
            shootTimer += Time.deltaTime;

            if(shootTimer >= timeBetweenShoots + currentShootTimeVariance)
            {
                ActivateShoot();
                shootTimer = 0;
            }
        }

        private void ActivateShoot()
        {
            currentShootTimeVariance = GetNewShootTimeVariance();

            GameObject spawnedShoot = shootPool.Dequeue();

            spawnedShoot.SetActive(true);
            spawnedShoot.GetComponent<ShootBehavior>().SetDamage(weaponDamage);

            spawnedShoot.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - zSpawnDistanceToEnemy);
            spawnedShoot.transform.eulerAngles = new Vector3(90, transform.rotation.y, 0);

            shootPool.Enqueue(spawnedShoot);
        }

        private float GetNewShootTimeVariance()
        {
            return UnityEngine.Random.Range(timeBetweenShoots - shootTimeVariance, timeBetweenShoots + shootTimeVariance);
        }
    }
}