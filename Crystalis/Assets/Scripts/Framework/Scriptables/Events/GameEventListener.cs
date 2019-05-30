using UnityEngine;
using UnityEngine.Events;

namespace LeoDeg.Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;
        public UnityEvent response;

        void OnEnable ()
        {
            OnEnableLogic ();
        }

        void OnDisable ()
        {
            OnDisableLogic ();
        }

        public virtual void Response ()
        {
            response.Invoke ();
        }

        /// <summary>
        /// Override this to override the OnEnableLogic()
        /// </summary>
        public virtual void OnEnableLogic ()
        {
            if (gameEvent != null)
                gameEvent.Register (this);
        }

        /// <summary>
        /// Override this to override the OnDisableLogic()
        /// </summary>
        public virtual void OnDisableLogic ()
        {
            if (gameEvent != null)
                gameEvent.UnRegister (this);
        }
    }
}
