using Kajujam.Concrates.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kajujam.Concrates.Controller
{
    public class SpawnerController : MonoBehaviour
    {
        objectPool objPool;
        GameObject enemyGameObject;

        float timeLeft = 10;
        float bossTimeLeft = 20;


        private void Awake()
        {
            objPool = GetComponent<objectPool>();
        }
        private void Update()
        {
            timeLeft -= Time.deltaTime;
            bossTimeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 5;
                EnemySpawn();
            }
            if (bossTimeLeft < 0)
            {
                bossTimeLeft = 10;
                BossEnemySpawn();

            }
        }
        void EnemySpawn()
        {
            enemyGameObject = objPool.GetPooledObject();
            if (enemyGameObject != null && !enemyGameObject.CompareTag("Boss"))
            {
                enemyGameObject.transform.position = transform.position;
                enemyGameObject.GetComponent<Health>().currentHealth = enemyGameObject.GetComponent<Health>().maxHealth;
                enemyGameObject.SetActive(true);
            }
            
        }
        void BossEnemySpawn()
        {
            enemyGameObject = objPool.GetPooledObject();
            if (enemyGameObject != null && enemyGameObject.CompareTag("Boss"))
            {
                enemyGameObject.transform.position = transform.position;
                enemyGameObject.GetComponent<Health>().currentHealth = enemyGameObject.GetComponent<Health>().maxHealth;
                enemyGameObject.SetActive(true);
            }
        }
    }
}
