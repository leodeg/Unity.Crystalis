using UnityEngine;
using System.Collections;

namespace LeoDeg.Inventories
{
    [CreateAssetMenu (menuName = "LeoDeg/Inventory/Weapon")]
    public class Weapon : Item
    {
        public GameObject prefab;
        public Ammo ammoType;
        public int currentBullets;
        public int maxBullets;
        public float fireRate = 0.3f;

        public Scriptables.TransformScriptable leftHandPosition;
        public Scriptables.TransformScriptable rightHandPosition;
        

        public void Reload ()
        {
            int targetBulletsAmount = maxBullets;

            if (targetBulletsAmount > ammoType.maxCarryingAmount)
                targetBulletsAmount = maxBullets - ammoType.maxCarryingAmount;

            ammoType.maxCarryingAmount -= targetBulletsAmount;
            currentBullets = targetBulletsAmount;
        }
    }
}