using UnityEngine;
using System.Collections;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/Game/MoveViaInput")]
    public class MoveViaInput : StateAction
    {
        public Inputs.InputAxis horizontal;
        public Inputs.InputAxis vertical;
        public Space translateSpace;
        public float speed = 10f;

        Vector3 velocity;

        public override void Execute (StateMachine state)
        {
            velocity.Set (horizontal.value, 0f, vertical.value);
            velocity = velocity.normalized * speed * state.deltaTime.value;
            state.transformInstance.Translate (velocity, translateSpace);
        }
    }
}