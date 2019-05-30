using UnityEngine;
using System.Collections;

namespace LeoDeg.Inventories
{
    [CreateAssetMenu (menuName = "LeoDeg/Items/Ammo")]
    public class Ammo : ScriptableObject
    {
        public int carryingAmount;
        public int damageValue = 20;

        public virtual void OnHit ()
        {

        }
    }
}