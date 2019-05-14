﻿using System.Collections;
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
        public float damage = 2f;

        [Header ("Colors")]
        public Color originalColor;
        public Color attackColor;

        private float nextAttackTime = 0;

        public override void Execute (StateMachine state)
        {
            Debug.Log ("EnemyHandAttack:Execute");
            nextAttackTime = 0;
            if (Time.time > nextAttackTime)
            {
                float squaredDistanceToTarget = (target.value.position - state.transformInstance.position).sqrMagnitude;
                if (squaredDistanceToTarget < Mathf.Pow (attackDistanceThreashold + skinWidth + state.boxColliderInstance.size.x, 2))
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
                    targetHittable.value.TakeDamage (damage);
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