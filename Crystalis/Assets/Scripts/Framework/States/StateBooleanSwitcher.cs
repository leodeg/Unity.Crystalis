using UnityEngine;
using System.Collections;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/StateBooleanSwitcher")]
    public class StateBooleanSwitcher : StateAction
    {
        public Scriptables.BoolScriptable boolScriptable;
        public State onTrue;
        public State onFalse;

        public override void Execute (StateMachine state)
        {
            if (boolScriptable)
            {
                if (onTrue != null && state.GetCurrentState () != onTrue)
                    state.SetCurrentState (onTrue);
                else Debug.LogWarning ("StateBooleanSwitcher::Warning::OnTrue state is not assign!");
            }
            else
            {
                if (onFalse != null && state.GetCurrentState () != onFalse)
                    state.SetCurrentState (onFalse);
                else Debug.LogWarning ("StateBooleanSwitcher::Warning::OnTrue state is not assign!");
            }
        }
    }
}