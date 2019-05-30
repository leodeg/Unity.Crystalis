using UnityEngine;

namespace LeoDeg.StateActions
{
    public abstract class StateAction : ScriptableObject
    {
        public abstract void Execute (StateMachine state);
    }
}