using UnityEngine;
using System.Collections;

namespace LeoDeg.Inventories
{
    [CreateAssetMenu (menuName = "LeoDeg/Inventory/Ammo")]
    public class Ammo : Item
    {
        public GameObject prefab;
        public int maxCarryingAmount = 500;
        public float damage = 10f;

        public virtual void OnHit () { }
    }
}