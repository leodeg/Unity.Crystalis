using UnityEngine;
using System.Collections;

namespace LeoDeg.Managers
{
    public static class GameManagers
    {
        private static GameObjectPoolManager poolManager;

        public static GameObjectPoolManager GetPoolManager ()
        {
            if (poolManager == null)
            {
                poolManager = Resources.Load ("GameObjectPoolManager") as GameObjectPoolManager;
                poolManager.Initialize ();
            }

            return poolManager;
        }
    }
}