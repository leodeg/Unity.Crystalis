using UnityEngine;
using System.Collections;

namespace LeoDeg.StateActions
{
    [CreateAssetMenu (menuName = "LeoDeg/States/Game/WeaponShootStateAction")]
    public class WeaponShootStateAction : StateAction
    {
        public Inputs.InputButton leftMouse;
        public Inputs.InputButton rightMouse;

        public override void Execute (StateMachine state)
        {
            if (leftMouse.isPressed)
            {
                state.inventory.ShootLeft ();
            }

            if (rightMouse.isPressed)
            {
                state.inventory.ShootRight ();
            }

            state.inventory.ResetLeftWeaponPos ();
            state.inventory.ResetRighttWeaponPos ();
        }
    }
}