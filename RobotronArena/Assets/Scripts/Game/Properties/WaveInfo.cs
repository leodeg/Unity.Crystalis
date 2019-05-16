using UnityEngine;
using System.Collections;

namespace LeoDeg.Properties
{
    [System.Serializable]
    public class WaveInfo
    {
        public bool infiniteWaves;
        public int spawnCount;
        public float timeBetweenSpawns;
        public int enemyDamage;
        public float enemySpeed;
        public float enemyHealth;
        public Color skinColor;
    }
}