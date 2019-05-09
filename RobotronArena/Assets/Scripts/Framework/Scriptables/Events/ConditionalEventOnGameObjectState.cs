using UnityEngine;
using UnityEngine.Events;

namespace LeoDeg.Events
{
    public class ConditionalEventOnGameObjectState : EventExecutionOnMonoBehaviour
    {
        public GameObject target;
        public UnityEvent onActiveInHierarchy;
        public UnityEvent onInactiveInHierarchy;

        /// <summary>
        /// Invoke the true or false event stack based on a state of a gameObject. 
        /// Super useful when doing categories with UI elements.
        /// </summary>
        public override void Raise()
        {
            if(target == null)
            {
                Debug.Log("Conditional Event from GameObject state doesn't have a GameObject assigned! [" + this.gameObject.name + "]");
                return;
            }

            if (target.activeInHierarchy)
            {
                onActiveInHierarchy.Invoke ();
            }
            else
            {
                onInactiveInHierarchy.Invoke ();
            }
        }
    }
}
