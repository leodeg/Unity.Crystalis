using UnityEngine;
using System.Collections;

namespace LeoDeg.Inputs
{
    public class InputUpdater : MonoBehaviour
    {
        public Actions.Action[] inputs;

        private void Update ()
        {
            if (inputs == null) return;

            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i].Execute ();
            }
        }
    }
}