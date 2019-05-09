using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Managers
{
    [CreateAssetMenu (menuName = "LeoDeg/Managers/GameObjectPoolManager")]
    public class GameObjectPoolManager : ScriptableObject
    {
        /// <summary>
        /// String - is a name of a pool object, integer - is an id of the pool object.
        /// </summary>
        private Dictionary<string, int> objectsPoolDictionary = new Dictionary<string, int> ();
        public List<ObjectPool> objectPools = new List<ObjectPool> ();
        private GameObject poolParent;

        public void Initialize ()
        {
            if (poolParent != null)
                Destroy (poolParent);

            poolParent = new GameObject ();
            poolParent.name = "GameObjectsPoolManager";
            objectsPoolDictionary.Clear ();

            for (int i = 0; i < objectPools.Count; i++)
            {
                if (objectPools[i].maxAmount < 1)
                    objectPools[i].maxAmount = 1;

                objectPools[i].currentIndex = 0;
                objectPools[i].createdObjects.Clear();

                if (objectsPoolDictionary.ContainsKey(objectPools[i].prefab.name))
                {
                    Debug.LogWarning ("GameObjectPoolManager::Warning:: Entry with id [" + objectPools[i].prefab.name + "] is a duplicate.");
                    continue;
                }
                else
                {
                    objectsPoolDictionary.Add (objectPools[i].prefab.name, i);
                }
            }
        }

        public GameObject GetPoolObject (string name)
        {
            GameObject poolObject = null;
            int index;

            if (objectsPoolDictionary.TryGetValue(name, out index))
            {
                ObjectPool currentPool = objectPools[index];
                if (currentPool.createdObjects.Count - 1 < currentPool.maxAmount)
                {
                    poolObject = Instantiate (currentPool.prefab);
                    poolObject.transform.parent = poolParent.transform;
                    currentPool.createdObjects.Add (poolObject);
                }
                else
                {
                    currentPool.currentIndex = (currentPool.currentIndex < currentPool.createdObjects.Count) ? currentPool.currentIndex + 1 : 0;
                    poolObject = currentPool.GetCreatedObject (currentPool.currentIndex);
                    poolObject.SetActive (false);
                    poolObject.SetActive (true);
                }
            }

            return poolObject;
        }
    }
}