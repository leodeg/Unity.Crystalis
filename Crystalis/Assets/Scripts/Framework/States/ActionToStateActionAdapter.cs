using UnityEngine;
using System.Collections;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/ActionToStateActionAdapter")]
    public class ActionToStateActionAdapter : StateAction
    {
        public Actions.Action action;

        public override void Execute (StateMachine state)
        {
            action.Execute ();
        }
    }
}