using UnityEngine;
using System.Collections;

namespace LeoDeg.Properties
{
    [System.Serializable]
    public class StateProperties
    {
        public bool isAiming;
        public bool isShooting;
        public bool isReloading;
        public bool isInteracting;
        public bool isGround;
        public bool isDead;

        public bool shootingFlag;
        public bool reloadingFlag;
        public bool vaultingFlag;

        public bool healthChangeFlag;

        public void SetReloading ()
        {
            isReloading = true;
        }
    }
}