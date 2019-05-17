using UnityEngine;
using System.Collections;

namespace LeoDeg.Actions
{
    [CreateAssetMenu (menuName = "LeoDeg/Actions/Game/MoveToPosition")]
    public class MoveToPosition : Action
    {
        [Header ("References")]
        public Scriptables.TransformScriptable target;
        public Scriptables.Vector3Scriptable targetPosition;
        public bool freezeYPos;
        public float yPos = 0f;

        [Header ("Linear Interpolation")]
        public bool useLerp;
        public Scriptables.FloatScriptable deltaTime;
        public float speed;

        public override void Execute ()
        {
            Vector3 position = targetPosition.value;
            if (freezeYPos)
                position.y = yPos;

            if (useLerp)
                target.value.position = Vector3.Lerp (target.value.position, position, speed * deltaTime.value);
            else target.value.position = position;
        }
    }
}