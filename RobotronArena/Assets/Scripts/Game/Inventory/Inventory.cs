using UnityEngine;
using System.Collections;
using System;

namespace LeoDeg.Inventories
{
    [CreateAssetMenu (menuName = "LeoDeg/Items/Inventory")]
    public class Inventory : ScriptableObject
    {
        public Scriptables.TransformScriptable leftWeaponHolder;
        public Scriptables.TransformScriptable rightWeaponHolder;

        public Weapon startingWeapon;
        public Weapon leftEquipedWeapon;
        public Weapon rightEquipedWeapon;

        private void OnDisable ()
        {
            leftEquipedWeapon = null;
            rightEquipedWeapon = null;
        }

        public void Initialize ()
        {
            if (startingWeapon != null)
            {
                EquipRightGun (startingWeapon);
                EquipLeftGun (startingWeapon);
            }
        }

        public void EquipLeftGun (Weapon weapon)
        {
            if (leftEquipedWeapon != null)
            {
                Destroy (leftEquipedWeapon.modelPrefab);
                leftEquipedWeapon.properties = null;
            }

            leftEquipedWeapon = Instantiate(weapon);
            leftEquipedWeapon.Initialize ();
            leftEquipedWeapon.properties.modelInstance.transform.parent = leftWeaponHolder.value;
            leftEquipedWeapon.properties.modelInstance.transform.localPosition = leftWeaponHolder.value.localPosition;
            leftEquipedWeapon.properties.modelInstance.transform.localEulerAngles = leftWeaponHolder.value.localEulerAngles;
        }

        public void EquipRightGun (Weapon weapon)
        {
            if (rightEquipedWeapon != null)
            {
                Destroy (rightEquipedWeapon.modelPrefab);
                rightEquipedWeapon.properties = null;
            }

            rightEquipedWeapon = Instantiate(weapon);
            rightEquipedWeapon.Initialize ();
            rightEquipedWeapon.properties.modelInstance.transform.parent = rightWeaponHolder.value;
            rightEquipedWeapon.properties.modelInstance.transform.localPosition = rightWeaponHolder.value.localPosition;
            rightEquipedWeapon.properties.modelInstance.transform.localEulerAngles = rightWeaponHolder.value.localEulerAngles;
        }

        public void ShootRight ()
        {
            if (rightEquipedWeapon != null)
            {
                rightEquipedWeapon.properties.weaponController.Shoot ();
            }
        }

        public void ShootLeft ()
        {
            if (leftEquipedWeapon != null)
            {
                leftEquipedWeapon.properties.weaponController.Shoot ();
            }
        }

        public float GetLeftWeaponDamage ()
        {
            return leftEquipedWeapon.properties.weaponController.GetDamage ();
        }

        public float GetRightWeaponDamage ()
        {
            return rightEquipedWeapon.properties.weaponController.GetDamage ();
        }

        public void SetRightWeaponDamage (float damage)
        {
            if (rightEquipedWeapon != null)
            {
                rightEquipedWeapon.properties.weaponController.damage = damage;
            }
        }

        public void SetLeftWeaponDamage (float damage)
        {
            if (leftEquipedWeapon != null)
            {
                leftEquipedWeapon.properties.weaponController.damage = damage;
            }
        }

        public void ResetLeftWeaponPos ()
        {
            if (leftEquipedWeapon != null)
            {
                leftEquipedWeapon.properties.weaponController.ResetPosition ();
            }
        }

        public void ResetRighttWeaponPos ()
        {
            if (rightEquipedWeapon != null)
            {
                rightEquipedWeapon.properties.weaponController.ResetPosition ();
            }
        }
    }
}
