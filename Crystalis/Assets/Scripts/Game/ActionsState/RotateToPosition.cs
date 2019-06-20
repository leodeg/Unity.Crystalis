using System.Collections;
using UnityEngine;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/Game/RotateToPosition")]
    public class RotateToPosition : StateAction
    {
        [Header ("Scriptable References")]
        public Scriptables.Vector3Scriptable position;

        [Header ("Properties")]
        public float rotationSpeed = 7f;
        public float slowRotationSpeed = 2f;
        public float minDistance = 1f;
        public bool freezeYRotation = true;

        private float currentSpeed = 0f;

        public override void Execute (StateMachine state)
        {
            Vector3 direction = position.value - state.transformInstance.position;

            if (freezeYRotation)
                direction.y = 0;

            if (minDistance > direction.magnitude)
                currentSpeed = slowRotationSpeed;
            else currentSpeed = rotationSpeed;

            state.transformInstance.rotation = Quaternion.Slerp (state.transformInstance.rotation, Quaternion.LookRotation (direction), currentSpeed * state.deltaTime.value);
        }
    }
}