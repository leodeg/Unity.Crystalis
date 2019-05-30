using UnityEngine;
using System.Collections;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/StateConditionSwitcher")]
    public class StateConditionSwitcher : StateAction
    {
        public Conditions.Condition condition;
        public State onTrue;
        public State onFalse;

        public override void Execute (StateMachine state)
        {
            if (condition.CheckCondition (state))
            {
                if (onTrue != null && state.GetCurrentState () != onTrue)
                    state.SetCurrentState (onTrue);
                else Debug.LogWarning ("StateConditionSwitcher::Warning::OnTrue state is not assign!");
            }
            else
            {
                if (onFalse != null && state.GetCurrentState () != onFalse)
                    state.SetCurrentState (onFalse);
                else Debug.LogWarning ("StateConditionSwitcher::Warning::OnTrue state is not assign!");
            }
        }
    }
}