using UnityEngine;
using System.Collections;

namespace LeoDeg.Actions
{
    [CreateAssetMenu (menuName = "LeoDeg/Actions/Game/MoveObjectViaInput")]
    public class MoveObjectViaInput : Action
    {
        public Inputs.InputAxis horizontal;
        public Inputs.InputAxis vertical;
        public Scriptables.TransformScriptable target;
        public Scriptables.FloatScriptable deltaTime;
        public float speed;

        public bool useCamera;
        [Tooltip ("If it's null will be used main camera")]
        public Camera customCamera;

        private Vector3 translation;

        public override void Execute ()
        {
            if (customCamera == null)
            {
                translation = vertical.value * Camera.main.transform.forward;
                translation += horizontal.value * Camera.main.transform.right;
            }
            else
            {
                translation = horizontal.value * customCamera.transform.right;
                translation += vertical.value * customCamera.transform.forward;
            }

            translation.y = 0;
            translation = translation.normalized * speed * deltaTime.value;
            target.value.Translate (translation);
        }
    }
}