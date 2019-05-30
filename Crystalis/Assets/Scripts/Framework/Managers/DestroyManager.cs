using UnityEngine;
using System.Collections;
using LeoDeg.StateActions;

namespace LeoDeg.Managers
{
    public class DestroyManager : MonoBehaviour
    {
        public string playerTag = "Player";
        public string enemyTag = "Enemy";

        private void OnTriggerEnter (Collider other)
        {
            if (other.tag == playerTag || other.tag == enemyTag)
            {
                GameObject.FindGameObjectWithTag (playerTag).GetComponent<StateMachine> ().TakeHit (float.MaxValue, Vector3.zero, Vector3.zero);
            }
        }
    }
}