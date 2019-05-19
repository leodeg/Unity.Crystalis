using UnityEngine;
using System.Collections;
using LeoDeg.StateActions;

namespace LeoDeg.Managers
{
    public class DestroyManager : MonoBehaviour
    {
        public string playerTag = "Player";

        private void OnTriggerEnter (Collider other)
        {
            if (other.tag == playerTag)
            {
                GameObject.FindGameObjectWithTag (playerTag).GetComponent<StateMachine> ().TakeHit (float.MaxValue, Vector3.zero, Vector3.zero);
            }
        }
    }
}