using UnityEngine;
using UnityEngine.Events;

namespace LeoDeg.Events
{
    public class ConditionalEventOnBoolVariable : EventExecutionOnMonoBehaviour
    {
        public Scriptables.BoolScriptable target;
        public UnityEvent onTrue;
        public UnityEvent onFalse;
        
        /// <summary>
        /// Use this to raise either a true or false event stack based on a bool variable
        /// </summary>
        public override void Raise()
        {
            if(target == null)
            {
                Debug.Log("Bool Scriptable Variable is not assign on Conditional Event [" + this.gameObject.name + "]");
                return;
            }

            if (target.value)
            {
                onTrue.Invoke ();
            }
            else
            {
                onFalse.Invoke ();
            }
        }
    }
}
