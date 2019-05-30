using UnityEngine;
using LeoDeg.StateActions;

namespace LeoDeg.Assign
{
    public class AssignStateMachine : MonoBehaviour
    {
        public Scriptables.StateMachineScriptable scriptableVariable;

        private void OnEnable ()
        {
            scriptableVariable.value = gameObject.GetComponent<StateMachine>();
            Destroy (this);
        }
    }
}