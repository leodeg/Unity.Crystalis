using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Managers
{
    /// <summary>
    /// Handler of a game objects
    /// </summary>
    [System.Serializable]
    public class ObjectPool
    {
        public GameObject prefab;
        public int maxAmount = 10;

        [HideInInspector]
        public int currentIndex = 0;

        [HideInInspector]
        public List<GameObject> createdObjects = new List<GameObject> ();

        public GameObject GetCreatedObject (int index)
        {
            return createdObjects[index];
        }

    }
}