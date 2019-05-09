using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using LeoDeg.Scriptables;

namespace LeoDeg.Events
{
    public class OnFloatComparisonEvent : EventExecutionOnMonoBehaviour
    {
        [Tooltip ("Fixed number for comparing with targetValue")]
        public float fixedNumber;

        [Tooltip ("Value that need to compare with the fixed number")]
        public FloatScriptable targetScriptable;

        public UnityEvent onVariableIsLower;
        public UnityEvent onVariableIsHigher;

        /// <summary>
        /// Invoke the true or false event stack based on a comparison of your targetVariable and a fixed number
        /// The comparison only runs when the Raise() is called, it's not monitored in Update or etc.
        /// </summary>
        public override void Raise ()
        {
            if (targetScriptable == null)
            {
                Debug.Log ("No number variable assigned in a fixed number to numberVariable comparison! " + this.gameObject.name);
                return;
            }

            if (targetScriptable.value < fixedNumber)
            {
                onVariableIsLower.Invoke ();
            }
            else
            {
                onVariableIsHigher.Invoke ();
            }
        }
    }
}