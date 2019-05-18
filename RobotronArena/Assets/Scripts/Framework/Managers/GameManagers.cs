using UnityEngine;
using System.Collections;

namespace LeoDeg.Managers
{
    public static class GameManagers
    {
        private static GameObjectPoolManager poolManager;
        private static AudioManager audioManager = AudioManager.Instance;

        public static GameObjectPoolManager GetPoolManager ()
        {
            if (poolManager == null)
            {
                poolManager = Resources.Load ("GameObjectPoolManager") as GameObjectPoolManager;
                poolManager.Initialize ();
            }

            return poolManager;
        }

        public static AudioManager GetAudioManager ()
        {
            return audioManager;
        }

    }
}