using UnityEngine;
using System.Collections;

namespace LeoDeg.Conditions
{
    public abstract class Condition : ScriptableObject
    {
        public string description;

        public abstract bool CheckCondition (StateActions.StateMachine state);
    }
}