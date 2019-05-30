using UnityEngine;
using System.Collections;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/StateActionBooleanSwitcher")]
    public class StateActionBooleanSwitcher : StateAction
    {
        public Scriptables.BoolScriptable boolScriptable;
        public StateAction onTrue;
        public StateAction onFalse;

        public override void Execute (StateMachine state)
        {
            if (boolScriptable)
            {
                if (onTrue != null)
                    onTrue.Execute (state);
                else Debug.LogWarning ("StateActionSwitcher::Warning::OnTrue state action is not assign!");
            }
            else
            {
                if (onFalse != null)
                    onFalse.Execute (state);
                else Debug.LogWarning ("StateActionSwitcher::Warning::OnFalse state action is not assign!");
            }
        }
    }
}