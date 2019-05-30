using UnityEngine;
using System.Collections;

namespace LeoDeg.Inputs
{
    [CreateAssetMenu (menuName = "LeoDeg/Inputs/InputAxis")]
    public class InputAxis : Actions.Action
    {
        [Header ("Properties")]
        public string axisName;
        public float value;

        [Header ("Debug")]
        public bool debugValueToConsole;

        public override void Execute ()
        {
            value = Input.GetAxis (axisName);

            if (debugValueToConsole)
            {
                Debug.Log ("AxisName: [" + axisName + "], Value: " + value + "]");
            }
        }
    }
}