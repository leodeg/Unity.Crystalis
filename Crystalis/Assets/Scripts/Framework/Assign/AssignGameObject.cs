using UnityEngine;
using System.Collections;

namespace LeoDeg.Assign
{
    public class AssignGameObject : MonoBehaviour
    {
        public Scriptables.GameObjectScriptable scriptableVariable;

        private void OnEnable ()
        {
            scriptableVariable.value = this.gameObject;
            Destroy (this);
        }
    }
}