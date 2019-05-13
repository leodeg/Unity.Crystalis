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
                state.weaponController.leftEquipedWeapon.Shoot ();
            }

            if (rightMouse.isPressed)
            {
                state.weaponController.rightEquipedWeapon.Shoot ();
            }
        }
    }
}