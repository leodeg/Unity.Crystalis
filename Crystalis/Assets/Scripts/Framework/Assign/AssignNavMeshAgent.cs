using UnityEngine;
using System.Collections;

namespace LeoDeg.Assign
{
    public class AssignNavMeshAgent : MonoBehaviour
    {
        public Scriptables.NavMeshScriptable scriptableVariable;

        private void OnEnable ()
        {
            scriptableVariable.value = GetComponent<UnityEngine.AI.NavMeshAgent> ();
            Destroy (this);
        }
    }
}