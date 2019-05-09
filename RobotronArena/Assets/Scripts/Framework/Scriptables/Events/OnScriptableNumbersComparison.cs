using LeoDeg.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace LeoDeg.Events
{
    public class OnScriptableNumbersComparison : EventExecutionOnMonoBehaviour
    {
        public NumberScriptable firstValue;
        public NumberScriptable secondValue;

        public UnityEvent onFirstValueIsLower;
        public UnityEvent onFirstValueIsHigher;

        /// <summary>
        /// Raise true or false event stack based on the comparison of two number variables
        /// </summary>
        public override void Raise ()
        {
            if (firstValue == null || secondValue == null)
            {
                Debug.Log ("Number variable comparison doesn't have variables assigned! " + this.gameObject);
                return;
            }

            float first = 0;
            float second = 0;

            if (firstValue is FloatScriptable)
            {
                FloatScriptable floatScriptable = (FloatScriptable)firstValue;
                first = floatScriptable.value;
            }

            if (firstValue is IntScriptable)
            {
                IntScriptable intScriptable = (IntScriptable)firstValue;
                first = intScriptable.value;
            }

            if (secondValue is FloatScriptable)
            {
                FloatScriptable floatScriptable = (FloatScriptable)secondValue;
                second = floatScriptable.value;
            }

            if (secondValue is IntScriptable)
            {
                IntScriptable intScriptable = (IntScriptable)secondValue;
                second = intScriptable.value;
            }

            if (first < second)
            {
                onFirstValueIsLower.Invoke ();
            }
            else
            {
                onFirstValueIsHigher.Invoke ();
            }

        }

    }
}
