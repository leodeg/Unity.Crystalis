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

        private WaveInfo currentWave;
        private int currentWaveCount = 0;
        private int remainingToSpawn = 0;
        private int remainingToAlive = 0;
        private float nextSpawnTime = 0f;

        private void Start ()
        {
            NextSpawnWave ();
        }

        private void Update ()
        {
            if (remainingToSpawn > 0 && Time.time > nextSpawnTime)
            {
                SpawnNewObject ();
            }
        }

        private void SpawnNewObject ()
        {
            remainingToSpawn--;
            Debug.Log ("SpawnManager:SpawnNewObject: new object was spawned: " + remainingToSpawn);

            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
            int randomPoint = Random.Range (0, spawnPoints.Length - 1);
            GameObject spawned = Instantiate (prefab, spawnPoints[randomPoint].position, Quaternion.identity);

            StateMachine stateMachine = spawned.GetComponent<StateMachine>();
            if (stateMachine != null)
                stateMachine.OnDeath.AddListener (OnDeath);
        }

        public void OnDeath ()
        {
            remainingToAlive--;
            Debug.Log ("SpawnManager:OnDeath: remaining to alive: " + remainingToAlive);

            if (remainingToAlive < 1)
                NextSpawnWave ();
        }

        private void NextSpawnWave ()
        {
            currentWaveCount++;
            Debug.Log ("SpawnManager:NextWave: wave count: " + currentWaveCount);

            if (currentWaveCount - 1 < waves.Length)
            {
                currentWave = waves[currentWaveCount - 1];
                remainingToSpawn = currentWave.spawnCount;
                remainingToAlive = remainingToSpawn;
            }
            else
            {
                // End of waves
            }
        }
    }
}