using UnityEngine;
using System.Collections;

namespace LeoDeg.Actions
{
    [CreateAssetMenu (menuName = "LeoDeg/Actions/Game/RotateAction")]
    public class RotateAction : Action
    {
        public Scriptables.TransformScriptable target;
        public Scriptables.FloatScriptable deltaTime;
        public Vector3 rotationAxis;
        public float speed;

        public override void Execute ()
        {
            target.value.Rotate (rotationAxis * speed * deltaTime.value);
        }
    }
}