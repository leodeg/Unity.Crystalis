using UnityEngine;
using System.Collections;

namespace LeoDeg.Actions
{
    [CreateAssetMenu (menuName = "LeoDeg/Actions/Game/RotateToPosition")]
    public class RotateToPosition : Action
    {
        public Scriptables.Vector3Scriptable position;
        public Scriptables.TransformScriptable target;
        public Scriptables.FloatScriptable deltaTime;
        public float rotationSpeed;

        public override void Execute ()
        {
            Vector3 direction = position.value - target.value.position;
            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation (direction);
            target.value.rotation = Quaternion.Slerp (target.value.rotation, targetRotation, rotationSpeed * deltaTime.value);
        }
    }
}
