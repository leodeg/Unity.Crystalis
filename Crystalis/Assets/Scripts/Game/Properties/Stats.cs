using UnityEngine;
using System.Collections;

namespace LeoDeg.Properties
{
    [System.Serializable]
    public class Stats
    {
        [SerializeField]
        private float startHealth;
        [SerializeField]
        private float currentHealth;

        [SerializeField]
        private float score;

        public float GetHealth ()
        {
            return currentHealth;
        }

        public float GetStartHealth ()
        {
            return startHealth;
        }

        public float GetScore ()
        {
            return score;
        }

        public void SetScore (float score)
        {
            this.score = score;
        }

        public void SetHealth (float health)
        {
            this.currentHealth = health;
        }

        public void AddHealth (float healthAmount)
        {
            currentHealth += healthAmount;
        }

        public void AddScore (float scoreAmount)
        {
            score += scoreAmount;
        }
    }
}