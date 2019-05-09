using UnityEngine;

namespace LeoDeg.Actions
{
    public class ActionsUpdater : MonoBehaviour
    {
        public Action[] onAwake;
        public Action[] onStart;
        public Action[] onFixed;
        public Action[] onUpdate;
        public Action[] onEnable;
        public Action[] onDisable;

        private void OnEnable ()
        {
            if (onEnable == null) return;
            ExecuteActions (onEnable);
        }

        private void OnDisable ()
        {
            if (onDisable == null) return;
            ExecuteActions (onDisable);
        }

        private void Awake ()
        {
            if (onAwake == null) return;
            ExecuteActions (onAwake);
        }

        private void Start ()
        {
            if (onStart == null) return;
            ExecuteActions (onStart);
        }

        private void FixedUpdate ()
        {
            if (onFixed == null) return;
            ExecuteActions (onFixed);
        }

        private void Update ()
        {
            if (onUpdate == null) return;
            ExecuteActions (onUpdate);
        }

        public void ExecuteActions (Action[] actions)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Execute ();
            }
        }
    }
}
