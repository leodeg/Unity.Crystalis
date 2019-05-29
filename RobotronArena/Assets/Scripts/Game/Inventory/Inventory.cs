using System;
using System.Collections;
using UnityEngine;

namespace LeoDeg.Inventories
{
    [CreateAssetMenu (menuName = "LeoDeg/Items/Inventory")]
    public class Inventory : ScriptableObject
    {
        public Weapon startingWeapon;
        public Weapon leftEquipedWeapon;
        public Weapon rightEquipedWeapon;

        private void OnDisable ()
        {
            leftEquipedWeapon = null;
            rightEquipedWeapon = null;
        }

        public void InitializeWeapon (Transform lefthand, Transform rightHand)
        {
            if (startingWeapon != null)
            {
                EquipRightGun (startingWeapon, rightHand);
                EquipLeftGun (startingWeapon, lefthand);
            }
        }

        #region Weapon Methods

        public void EquipLeftGun (Weapon weapon, Transform position)
        {
            if (leftEquipedWeapon != null)
            {
                leftEquipedWeapon.properties = null;
                Destroy (leftEquipedWeapon.modelPrefab.gameObject);
            }

            leftEquipedWeapon = Instantiate (weapon);
            leftEquipedWeapon.Initialize ();
            leftEquipedWeapon.properties.modelInstance.transform.parent = position;
            leftEquipedWeapon.properties.modelInstance.transform.localPosition = position.localPosition;
            leftEquipedWeapon.properties.modelInstance.transform.localEulerAngles = position.localEulerAngles;
        }

        public void EquipRightGun (Weapon weapon, Transform position)
        {
            if (rightEquipedWeapon != null)
            {
                rightEquipedWeapon.properties = null;
                Destroy (rightEquipedWeapon.modelPrefab.gameObject);
            }

            rightEquipedWeapon = Instantiate (weapon);
            rightEquipedWeapon.Initialize ();
            rightEquipedWeapon.properties.modelInstance.transform.parent = position;
            rightEquipedWeapon.properties.modelInstance.transform.localPosition = position.localPosition;
            rightEquipedWeapon.properties.modelInstance.transform.localEulerAngles = position.localEulerAngles;
        }

        public void ShootRight ()
        {
            if (rightEquipedWeapon != null)
                rightEquipedWeapon.properties.weaponController.Shoot ();
        }

        public void ShootLeft ()
        {
            if (leftEquipedWeapon != null)
                leftEquipedWeapon.properties.weaponController.Shoot ();
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
                rightEquipedWeapon.properties.weaponController.damage = damage;
        }

        public void SetLeftWeaponDamage (float damage)
        {
            if (leftEquipedWeapon != null)
                leftEquipedWeapon.properties.weaponController.damage = damage;
        }

        public void ResetLeftWeaponPos ()
        {
            if (leftEquipedWeapon != null)
                leftEquipedWeapon.properties.weaponController.ResetPosition ();
        }

        public void ResetRightWeaponPos ()
        {
            if (rightEquipedWeapon != null)
                rightEquipedWeapon.properties.weaponController.ResetPosition ();
        }

        #endregion
    }
}
