using UnityEngine;
using System.Collections;
using LeoDeg.Properties;

namespace LeoDeg.Assign
{
    public class AssignIHittable : MonoBehaviour
    {
        public Scriptables.IHittableScriptable scriptableVariable;

        private void OnEnable ()
        {
            scriptableVariable.value = gameObject.GetComponent<IHittable>();
            Destroy (this);
        }
    }
}