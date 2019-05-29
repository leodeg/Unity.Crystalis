using LeoDeg.Properties;
using LeoDeg.StateActions;
using System.Collections;
using UnityEngine;

namespace LeoDeg.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        public WaveInfo[] waves;
        public Transform[] spawnPoints;
        public GameObject prefab;
        public bool isDisabled;

        public event System.Action<int> OnNewWave;

        private WaveInfo currentWaveInfo;
        private static int waveCounter = 0;
        private static int remainingToSpawn = 0;
        private static int remainingToAlive = 0;
        private float nextSpawnTime = 0f;

        private void Start ()
        {
            SpawnNextWave ();
        }

        private void Update ()
        {
            if ((remainingToSpawn > 0 || currentWaveInfo.infiniteWaves) && Time.time > nextSpawnTime)
            {
                SpawnNewObject ();
            }
        }

        #region Getters

        public int GetWaveCount ()
        {
            return waveCounter;
        }

        public int GetTotalWaveCount ()
        {
            return waves.Length;
        }

        public int GetAliveEnemyCount ()
        {
            return remainingToAlive;
        }

        public int GetTotalEnemiesCount ()
        {
            return currentWaveInfo.spawnCount;
        }

        #endregion

        #region Spawn Methods

        private void SpawnNewObject ()
        {
            remainingToSpawn--;
            //Debug.Log ("SpawnManager:SpawnNewObject: new object was spawned: " + remainingToSpawn);

            nextSpawnTime = Time.time + currentWaveInfo.timeBetweenSpawns;
            SetWaveDifficulty (currentWaveInfo.enemySpeed, currentWaveInfo.enemyDamage, currentWaveInfo.enemyHealth, currentWaveInfo.skinColor);
        }

        public void SetWaveDifficulty (float moveSpeed, int enemyDamage, float enemyHealth, Color skinColor)
        {
            int randomPoint = Random.Range (0, spawnPoints.Length);
            GameObject enemyClone = Instantiate (prefab, spawnPoints[randomPoint].position, Quaternion.identity);
            StateMachine currentEnemy = enemyClone.GetComponent<StateMachine> ();

            if (currentEnemy != null)
            {
                currentEnemy.OnDeath.AddListener (OnEnemyDestroy);
                currentEnemy.meshAgentInstance.speed = moveSpeed;
                currentEnemy.inventory.SetRightWeaponDamage (enemyDamage);
                currentEnemy.materialInstance.color = skinColor;
            }
        }

        private void SpawnNextWave ()
        {
            waveCounter++;
            //Debug.Log ("SpawnManager:NextWave: wave count: " + waveCounter);

            if (waveCounter - 1 < waves.Length)
            {
                currentWaveInfo = waves[waveCounter - 1];
                remainingToSpawn = currentWaveInfo.spawnCount;
                remainingToAlive = remainingToSpawn;

                if (OnNewWave != null)
                    OnNewWave.Invoke (waveCounter);
            }
            else
            {
                // End of waves
            }
        }

        #endregion

        #region Events

        public void OnPlayerDeath ()
        {
            isDisabled = true;
        }

        public void OnEnemyDestroy ()
        {
            --remainingToAlive;
            //Debug.Log ("SpawnManager:OnDeath: remaining to alive: " + remainingToAlive);

            if (remainingToAlive < 1)
                SpawnNextWave ();
        }

        #endregion
    }
}