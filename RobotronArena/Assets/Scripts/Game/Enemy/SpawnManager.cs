using LeoDeg.Properties;
using LeoDeg.StateActions;
using System.Collections;
using UnityEngine;

namespace LeoDeg.Enemies
{
    public class SpawnManager : MonoBehaviour
    {
        public WaveInfo[] waves;
        public Transform[] spawnPoints;
        public GameObject prefab;
        public bool isDisabled;

        public event System.Action<int> OnNewWave;

        private WaveInfo currentWaveInfo;
        private int waveCounter = 0;
        private int remainingToSpawn = 0;
        private int remainingToAlive = 0;
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
            GameObject spawned = Instantiate (prefab, spawnPoints[randomPoint].position, Quaternion.identity);
            StateMachine stateMachine = spawned.GetComponent<StateMachine> ();
            
            if (stateMachine != null)
            {
                stateMachine.OnDeath.AddListener (OnObjectDestroy);
                stateMachine.meshAgentInstance.speed = moveSpeed;
                stateMachine.inventory.SetRightWeaponDamage(enemyDamage);
                stateMachine.materialInstance.color = skinColor;
            }
        }

        public void OnPlayerDeath ()
        {
            isDisabled = true;
        }

        public void OnObjectDestroy ()
        {
            remainingToAlive--;
            Debug.Log ("SpawnManager:OnDeath: remaining to alive: " + remainingToAlive);

            if (remainingToAlive < 1)
                SpawnNextWave ();
        }

        private void SpawnNextWave ()
        {
            waveCounter++;
            Debug.Log ("SpawnManager:NextWave: wave count: " + waveCounter);

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
    }
}