using UnityEngine;
using System.Collections;

namespace LeoDeg.Actions
{
    [CreateAssetMenu (menuName = "LeoDeg/Actions/ActionBooleanSwitcher")]
    public class ActionBooleanSwitcher : Action
    {
        public Scriptables.BoolScriptable boolScriptable;
        public Action onTrue;
        public Action onFalse;

        public override void Execute ()
        {
            if (boolScriptable)
            {
                if (onTrue != null)
                    onTrue.Execute ();
                else Debug.LogWarning ("ActionBooleanSwitcher::Warning::OnTrue action is not assign!");
            }
            else
            {
                if (onFalse != null)
                    onFalse.Execute ();
                else Debug.LogWarning ("ActionBooleanSwitcher::Warning::OnFalse action is not assign!");
            }
        }
    }
}