using UnityEngine;
using System.Collections;
using UnityEngine.AI;

namespace LeoDeg.Actions
{
    [CreateAssetMenu (menuName = "LeoDeg/Actions/Game/NavMeshAgentMovement")]
    public class NavMeshAgentMovement : Action
    {
        public Scriptables.NavMeshScriptable navMeshAgent;
        public Scriptables.TransformScriptable target;

        public NavMeshAgent meshAgent;

        public override void Execute ()
        {
            navMeshAgent.value.SetDestination (target.value.position);
        }
    }
}
