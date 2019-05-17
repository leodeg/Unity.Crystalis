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

            state.weaponController.leftEquipedWeapon.transform.localPosition = Vector3.Lerp (state.weaponController.leftEquipedWeapon.transform.localPosition, Vector3.zero, 0.1f);

            state.weaponController.rightEquipedWeapon.transform.localPosition = Vector3.Lerp (state.weaponController.rightEquipedWeapon.transform.localPosition, Vector3.zero, 0.1f);
        }
    }
}