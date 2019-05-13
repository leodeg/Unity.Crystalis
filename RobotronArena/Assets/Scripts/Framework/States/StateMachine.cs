using LeoDeg.Inventories;
using LeoDeg.Properties;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace LeoDeg.StateActions
{
    public class StateMachine : MonoBehaviour, IHittable
    {
        [Header ("Base")]
        public State currentState;
        public Scriptables.FloatScriptable deltaTime;
        public Scriptables.FloatScriptable fixedDeltaTime;

        [Header ("Properties")]
        public Stats statsProperties;
        public StateProperties stateProperties;

        [Header ("Weapon")]
        public WeaponController weaponController;

        [Header ("Effects")]
        public string hitEffectsName;

        [Header ("References")]
        public bool useNavMeshAgent = false;
        public NavMeshAgent meshAgentInstance;

        [HideInInspector]
        public Rigidbody rigidbodyInstance;
        [HideInInspector]
        public Animator animatorInstance;
        [HideInInspector]
        public Transform transformInstance;

        #region State Machine Methods

        public void SetCurrentState (State state)
        {
            currentState = state;
        }

        public State GetCurrentState ()
        {
            return currentState;
        }

        private void Initialize ()
        {
            rigidbodyInstance = GetComponent<Rigidbody> ();
            transformInstance = GetComponent<Transform> ();
            animatorInstance = GetComponent<Animator> ();
            if (useNavMeshAgent)
            {
                meshAgentInstance = GetComponent<NavMeshAgent> ();
            }
        }

        #endregion

        #region Unity Methods

        private void OnEnable ()
        {
            currentState.OnEnter (this);
        }

        private void OnDisable ()
        {
            currentState.OnExit (this);
        }

        private void Awake ()
        {
            Initialize ();
            currentState.OnAwake (this);
        }

        private void Start ()
        {
            currentState.OnStart (this);
        }

        private void FixedUpdate ()
        {
            currentState.OnFixed (this);
        }

        private void Update ()
        {
            currentState.OnUpdate (this);
        }

        private void LateUpdate ()
        {
            currentState.OnLateUpdate (this);
        }

        #endregion

        #region IHittable

        public void TakeHit (float damage, Vector3 hitPoint, Vector3 hitDirection)
        {
            TakeDamage (damage);
        }

        public void TakeDamage (float damage)
        {
            statsProperties.health -= damage;

            if (statsProperties.health < 0)
            {
                statsProperties.health = 0;
                stateProperties.isDead = true;
            }
        }

        #endregion
    }
}