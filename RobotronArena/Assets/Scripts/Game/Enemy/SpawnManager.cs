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

        private WaveInfo currentWave;
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
                stateMachine.OnDeath.AddListener (OnObjectDestroy);
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
                currentWave = waves[waveCounter - 1];
                remainingToSpawn = currentWave.spawnCount;
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