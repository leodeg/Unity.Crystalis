using UnityEngine;

namespace LeoDeg.Events
{
    /// <summary>
    /// This script works as a game event listener (since it derives from it)
    /// Assign a target event and it will execute the response when it's called.
    /// If you don't assign an event, you can manually execute the Responce
    /// </summary>
    public class InstantiateObjectOnEvent : GameEventListener
    {
        public Scriptables.GameObjectScriptable toInstantiate;
        public Transform spawnPositionAndRotation;
        
        /// <summary>
        /// Make this true if you only want one instance of the prefab,
        /// Useful for visualizing gameObject that change
        /// </summary>
        public bool keepOnlyOneInstance;
        GameObject previousInstance;

        public override void Response()
        {
            if (keepOnlyOneInstance && previousInstance != null)
            {
                Destroy (previousInstance);
            }

            previousInstance = Instantiate(toInstantiate.value, spawnPositionAndRotation.position, spawnPositionAndRotation.rotation) as GameObject;
            this.response.Invoke();
        }
    }
}
