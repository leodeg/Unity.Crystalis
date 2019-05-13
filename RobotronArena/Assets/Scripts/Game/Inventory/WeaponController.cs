using UnityEngine;
using System.Collections;

namespace LeoDeg.Inventories
{
    public class WeaponController : MonoBehaviour
    {
        public Transform leftWeaponHolder;
        public Transform rightWeaponHolder;
        public Weapon startingWeapon;

        public Weapon leftEquipedWeapon;
        public Weapon rightEquipedWeapon;

        public void Initialize ()
        {
            if (startingWeapon != null)
            {
                EquipLeftGun (startingWeapon);
                EquipRightGun (startingWeapon);
            }
        }

        public void EquipLeftGun (Weapon weapon)
        {
            if (leftEquipedWeapon != null)
                Destroy (leftEquipedWeapon.gameObject);
            leftEquipedWeapon = Instantiate (weapon, leftWeaponHolder.position, leftWeaponHolder.rotation);
            leftEquipedWeapon.transform.parent = leftWeaponHolder;
        }

        public void EquipRightGun (Weapon weapon)
        {
            if (rightEquipedWeapon != null)
                Destroy (leftEquipedWeapon.gameObject);
            rightEquipedWeapon = Instantiate (weapon, rightWeaponHolder.position, rightWeaponHolder.rotation);
            rightEquipedWeapon.transform.parent = rightWeaponHolder;
        }
    }
}
