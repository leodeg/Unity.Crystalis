using UnityEngine;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/Game/NavMeshAgentMovement")]
    public class NavMeshAgentMovement : StateAction
    {
        public Scriptables.TransformScriptable target;

        public override void Execute (StateMachine state)
        {
            if (state.meshAgentInstance == null)
            {
                Debug.Log ("StateMachine:NavMeshAgentMovement: Navigation mesh agent is not assign.");
                return;
            }

            if (!state.stateProperties.isDead && !state.stateProperties.isAttacking)
            {
                state.meshAgentInstance.SetDestination (target.value.position);
            }
        }
    }
}