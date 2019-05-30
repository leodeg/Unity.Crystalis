using UnityEngine;

namespace LeoDeg.Events
{
    public class EventExecutionOnMonoBehaviour : MonoBehaviour
    {
        /// <summary>
        ///Raise the event or comparison as soon as this gameObject is enabled
        /// </summary>
        [Tooltip (" Raise the event or comparison as soon as this gameObject is enabled")]
        public bool raiseOnEnable;

        /// <summary>
        /// Raise the event or comparison as soon as this gameObject is disabled
        /// </summary>
        [Tooltip ("Raise the event or comparison as soon as this gameObject is disabled")]
        public bool raiseOnDisable;

        void OnEnable()
        {
            if(raiseOnEnable)
            {
                Raise();
            }
        }

        void OnDisable()
        {
            if(raiseOnDisable)
            {
                Raise();
            }
        }

        public virtual void Raise()
        {

        }
    }
}
