using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;

namespace General
{
    public class GameManager : MonoBehaviour
    {
        [System.Serializable]
        public class EnemyPool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }

        [System.Serializable]
        public class Hordes
        {
            public string tag;
            public int quantity;
            public float timeBetweenEachEnemy;
            public float timeToNextHorde;
            public Transform spawnTransform;
        }

        [Header("Enemy Pool")]
        [SerializeField] private List<EnemyPool> enemyPools;
        [SerializeField] private Transform enemyObjectParent;

        [Header("Hordes")]
        [SerializeField] private List<Hordes> hordesList;
        [SerializeField] private float timeToFirstHorde = 3f;

        private float hordeTimer;
        private float enemyTimer = 0;
        private int enemyCounter = 0;

        private int waveIndex;
        private bool inWave = false;

        private Dictionary<string, Queue<GameObject>> enemyPoolDictionary;

        private void Awake()
        {
            hordeTimer = timeToFirstHorde;
            enemyPoolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (var pool in enemyPools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject enemy = Instantiate(pool.prefab);
                    enemy.transform.parent = enemyObjectParent.transform;
                    enemy.SetActive(false);
                    objectPool.Enqueue(enemy);
                }

                enemyPoolDictionary.Add(pool.tag, objectPool);
            }
        }

        private void Update()
        {
            if (hordeTimer <= 0 && !inWave)
            {
                inWave = true;
                SelectNextHorde();
            }
            else if (inWave) WaveHandle();
            
            hordeTimer -= Time.deltaTime;
        }

        private void SelectNextHorde()
        {
            waveIndex = UnityEngine.Random.Range(0, hordesList.Count - 1);
            enemyCounter = hordesList[waveIndex].quantity;
        }

        private void WaveHandle()
        {
            if(enemyTimer <= 0)
            {
                enemyTimer = hordesList[waveIndex].timeBetweenEachEnemy;
                GameObject enemy = enemyPoolDictionary[hordesList[waveIndex].tag].Dequeue();

                enemy.SetActive(true);
                enemy.GetComponent<EnemyController>().ActivateEnemy();

                enemy.transform.position = hordesList[waveIndex].spawnTransform.position;
                enemy.transform.eulerAngles = new Vector3(-90, 0, 0);

                enemyPoolDictionary[hordesList[waveIndex].tag].Enqueue(enemy);
                enemyCounter--;
            }
            else
            {
                enemyTimer -= Time.deltaTime;
            }

            if(enemyCounter <= 0)
            {
                inWave = false;
                hordeTimer = hordesList[waveIndex].timeToNextHorde;
            }
        }
    }
}
