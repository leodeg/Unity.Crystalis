using UnityEngine;
using System.Collections;
using LeoDeg.Managers;

namespace LeoDeg.Inventories
{
    [CreateAssetMenu (menuName = "LeoDeg/Items/Weapon")]
    public class Weapon : Item
    {
        public class WeaponProperties
        {
            public GameObject modelInstance;
            public WeaponController weaponController;
        }

        [Header ("Prefabs")]
        public GameObject modelPrefab;
        public WeaponProperties properties;

        public void Initialize ()
        {
            properties = new WeaponProperties ();
            properties.modelInstance = Instantiate (modelPrefab);
            properties.weaponController = properties.modelInstance.GetComponent<WeaponController> ();
        }

        public void Reload ()
        {
            properties.weaponController.Reload ();
        }
    }
}