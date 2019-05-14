using UnityEngine;
using System.Collections;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/Game/EnemyHandAttack")]
    public class EnemyHandAttack : StateAction
    {
        public Scriptables.TransformScriptable target;
        public float attackDistanceThreashold = 1.5f;
        public float skinWidth = 0.2f;
        public float timeBetweenAttacks = 1f;
        public float damage = 2f;
        public float attackSpeed = 5f;

        private float nextAttackTime;

        public override void Execute (StateMachine state)
        {
            if (Time.time > nextAttackTime)
            {
                float squaredDistanceToTarget = (target.value.position - state.transformInstance.position).magnitude;
                if (squaredDistanceToTarget < Mathf.Pow (attackDistanceThreashold + skinWidth, 2))
                {
                    nextAttackTime = Time.time + nextAttackTime;

                    state.stateProperties.isAttacking = true;
                    state.meshAgentInstance.enabled = false;

                    Vector3 originalPos = state.transformInstance.position;
                    Vector3 attackPos = target.value.position;

                    float percent = 0;
                    while (percent <= 1)
                    {
                        percent += state.deltaTime.value * attackSpeed;
                        float interpolation = (-Mathf.Pow (percent, 2) + percent) * 4;
                        state.transformInstance.position = Vector3.Lerp (originalPos, attackPos, interpolation);
                    }

                    state.stateProperties.isAttacking = false;
                    state.meshAgentInstance.enabled = true;
                }
            }

        }
    }
}