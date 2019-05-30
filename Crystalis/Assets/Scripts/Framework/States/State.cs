using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/State")]
    public class State : ScriptableObject
    {
        public StateAction[] onAwake;
        public StateAction[] onStart;
        public StateAction[] onFixedUpdate;
        public StateAction[] onLateUpdate;
        public StateAction[] onUpdate;
        public StateAction[] onEnable;
        public StateAction[] onDisable;


        public void OnEnter (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onEnable);
        }

        public void OnExit (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onDisable);
        }

        public void OnAwake (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onAwake);
        }

        public void OnStart (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onStart);
        }

        public void OnFixed (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onFixedUpdate);
        }

        public void OnUpdate (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onUpdate);
        }

        public void OnLateUpdate (StateMachine stateMachine)
        {
            ExecuteActions (stateMachine, onLateUpdate);
        }


        public void ExecuteActions (StateMachine state, StateAction[] actions)
        {
            if (actions.Equals (null)) return;

            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].Execute (state);
            }
        }
    }
}