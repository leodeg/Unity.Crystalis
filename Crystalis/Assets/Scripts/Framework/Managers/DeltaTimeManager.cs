using UnityEngine;
using System.Collections;

namespace LeoDeg.Managers
{
    [CreateAssetMenu (menuName = "LeoDeg/Managers/DeltaTimeManager")]
    public class DeltaTimeManager : Actions.Action
    {
        public Scriptables.FloatScriptable deltaTimeVariable;
        public Scriptables.FloatScriptable fixedDeltaTimeVariable;

        public override void Execute ()
        {
            deltaTimeVariable.value = Time.deltaTime;
            fixedDeltaTimeVariable.value = Time.fixedDeltaTime;
        }
    }
}