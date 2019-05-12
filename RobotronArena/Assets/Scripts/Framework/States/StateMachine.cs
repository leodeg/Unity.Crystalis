using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.StateActions
{
    public class StateMachine : MonoBehaviour
    {
        public State currentState;
        public Scriptables.FloatScriptable deltaTime;
        public Scriptables.FloatScriptable fixedDeltaTime;

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
    }
}