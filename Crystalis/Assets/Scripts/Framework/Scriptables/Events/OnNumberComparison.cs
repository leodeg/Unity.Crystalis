using UnityEngine;
using UnityEngine.Events;
using LeoDeg.Scriptables;

namespace LeoDeg.Events
{
    public class OnNumberComparison : EventExecutionOnMonoBehaviour
    {
        [Tooltip ("Fixed number for comparing with targetValue")]
        public float fixedNumber;

        [Tooltip ("Value that need to compare with the fixed number")]
        public NumberScriptable targetValue;

        public UnityEvent onVariableIsLower;
        public UnityEvent onVariableIsHigher;

        /// <summary>
        /// Invoke the true or false event stack based on a comparison of your targetVariable and a fixed number
        /// The comparison only runs when the Raise() is called, it's not monitored in Update or etc.
        /// </summary>
        public override void Raise()
        {
            if(targetValue == null)
            {
                Debug.Log("No number variable assigned in a fixed number to numberVariable comparison! " + this.gameObject.name);
                return;
            }

            if(targetValue is FloatScriptable)
            {
                FloatScriptable floatScriptable = (FloatScriptable)targetValue;

                if (floatScriptable.value < fixedNumber)
                {
                    onVariableIsLower.Invoke ();
                }
                else
                {
                    onVariableIsHigher.Invoke ();
                }
            }

            if(targetValue is IntScriptable)
            {
                IntScriptable intScriptable = (IntScriptable)targetValue;

                if (intScriptable.value < Mathf.RoundToInt (fixedNumber))
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
}
