using LeoDeg.Inventories;
using LeoDeg.Properties;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace LeoDeg.StateActions
{
    public class StateMachine : MonoBehaviour, IHittable
    {
        [Header ("Base")]
        public State currentState;
        public Scriptables.FloatScriptable deltaTime;
        public Scriptables.FloatScriptable fixedDeltaTime;

        [Header ("Weapon")]
        public WeaponController weaponController;

        [Header ("Effects")]
        public string hitEffectsName;

        [Header ("Assign at Start")]
        public bool useNavMeshAgent = false;
        public bool useRigidbody = false;
        public bool useAnimator = false;

        [Header ("References")]
        public NavMeshAgent meshAgentInstance;
        public Rigidbody rigidbodyInstance;
        public Animator animatorInstance;

        [Header ("Properties")]
        public Stats statsProperties;
        public StateProperties stateProperties;

        [Header ("Events")]
        public UnityEvent OnDeath;

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
            transformInstance = GetComponent<Transform> ();

            if (useRigidbody)
                rigidbodyInstance = GetComponent<Rigidbody> ();

            if (useAnimator)
                animatorInstance = GetComponent<Animator> ();

            if (useNavMeshAgent)
                meshAgentInstance = GetComponent<NavMeshAgent> ();
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

            if (statsProperties.health <= 0)
            {
                Debug.Log ("StateMachine:TakeDamage: health: " + statsProperties.health);
                Die ();
            }
        }

        private void Die ()
        {
            statsProperties.health = 0;
            stateProperties.isDead = true;

            Debug.Log ("StateMachine:Die");
            if (OnDeath != null)
            {
                Debug.Log ("StateMachine:OnDeath");
                OnDeath.Invoke ();
            }


            Destroy (this.gameObject);
        }

        #endregion
    }
}