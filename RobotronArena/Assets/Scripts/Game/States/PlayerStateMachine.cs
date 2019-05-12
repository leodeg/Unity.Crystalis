using UnityEngine;
using System.Collections;
using LeoDeg.Properties;
using LeoDeg.Inventories;

namespace LeoDeg.StateActions
{
    public sealed class PlayerStateMachine : StateMachine
    {
        public Stats playerStats;
        public Inventory inventory;
        public StateProperties stateProperties;
        public MovementProperties movementProperties;
        public string hitEffectsName;

    }
}