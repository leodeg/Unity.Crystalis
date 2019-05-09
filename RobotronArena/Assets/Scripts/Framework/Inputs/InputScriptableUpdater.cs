using UnityEngine;
using System.Collections;

namespace LeoDeg.Inputs
{
    [CreateAssetMenu (menuName = "LeoDeg/Inputs/InputUpdater")]
    public class InputScriptableUpdater : Actions.Action
    {
        public Actions.Action[] inputs;

        public override void Execute ()
        {
            if (inputs == null) return;

            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i].Execute ();
            }
        }
    }
}