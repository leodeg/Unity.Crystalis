using UnityEngine;
using System.Collections;

namespace LeoDeg.Inventories
{
    [System.Serializable]
    public class Inventory
    {
        public Weapon leftWeapon;
        public Weapon rightWeapon;

        public void ReloadLeftWeapon ()
        {
            leftWeapon.Reload ();
        }

        public void ReloadRightWeapon ()
        {
            rightWeapon.Reload ();
        }
    }
}