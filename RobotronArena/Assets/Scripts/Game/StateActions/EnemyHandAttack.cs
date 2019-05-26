using System.Collections;
using UnityEngine;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/Game/EnemyHandAttack")]
    public class EnemyHandAttack : StateAction
    {
        [Header ("References")]
        public Scriptables.TransformScriptable target;
        public Scriptables.IHittableScriptable targetHittable;

        [Header ("Properties")]
        public float attackDistanceThreashold = 2f;
        public float timeBetweenAttacks = 1.5f;
        public float attackSpeed = 5f;
        public float skinWidth = 0.2f;

        [Header ("Colors")]
        public Color originalColor;
        public Color attackColor;

        private float nextAttackTime = 0;
        private bool resetAttackTime = false;

        private void OnEnable ()
        {
            nextAttackTime = 0;
            resetAttackTime = false;
        }

        public override void Execute (StateMachine state)
        {
            if (target.value == null) return;

            if (!resetAttackTime)
            {
                nextAttackTime = Time.time;
                resetAttackTime = true;
            }

            float distanceToTarget = (target.value.position - state.transformInstance.position).magnitude;
            if (distanceToTarget < attackDistanceThreashold + skinWidth + state.boxColliderInstance.size.x)
            {
                Debug.Log ("EnemyHandAttack:Execute");
                //Debug.Log ("Time: " + Time.time);
                Debug.Log ("Next Attack Time: " + nextAttackTime);
                if (Time.time > nextAttackTime)
                {
                    Debug.Log ("EnemyHandAttack:Start attack");
                    nextAttackTime = Time.time + timeBetweenAttacks;
                    Attack (state);
                }
            }

        }

        private void Attack (StateMachine state)
        {
            Debug.Log ("EnemyHandAttack:Attack method");
            state.stateProperties.isAttacking = true;
            state.meshAgentInstance.enabled = false;

            //state.materialInstance.color = attackColor;
            Vector3 originalPos = state.transformInstance.position;
            Vector3 attackPos = target.value.position;

            bool hasAppliedDamage = false;
            float percent = 0;
            while (percent <= 1)
            {
                if (percent >= 0.5f && !hasAppliedDamage)
                {
                    hasAppliedDamage = true;
                    targetHittable.value.TakeDamage (state.weaponController.GetRightWeaponDamage ());
                }
                Debug.Log ("EnemyHandAttack:Start animation");
                percent += state.deltaTime.value * attackSpeed;
                //float interpolation = (-Mathf.Pow (percent, 2) + percent) * 4;
                //state.transformInstance.position = Vector3.Lerp (originalPos, attackPos, interpolation);
            }

            //state.materialInstance.color = originalColor;
            state.stateProperties.isAttacking = false;
            state.meshAgentInstance.enabled = true;
        }
    }
}