using System.Collections;
using UnityEngine;

namespace LeoDeg.Actions
{
    [CreateAssetMenu (menuName = "LeoDeg/Actions/Game/RotateToPosition")]
    public class RotateToPosition : Action
    {
        [Header ("Scriptable References")]
        public Scriptables.Vector3Scriptable position;
        public Scriptables.TransformScriptable target;
        public Scriptables.FloatScriptable deltaTime;

        [Header ("Properties")]
        public float rotationSpeed = 7f;
        public float slowRotationSpeed = 2f;
        public float minDistance = 1f;
        public bool freezeYRotation = true;

        private float currentSpeed = 0f;

        public override void Execute ()
        {
            Vector3 direction = position.value - target.value.position;

            if (freezeYRotation)
                direction.y = 0;

            if (minDistance < direction.sqrMagnitude)
                currentSpeed = rotationSpeed;
            else currentSpeed = slowRotationSpeed;

            Quaternion targetRotation = Quaternion.LookRotation (direction);
            target.value.rotation = Quaternion.Slerp (target.value.rotation, targetRotation, currentSpeed * deltaTime.value);
        }
    }
}
