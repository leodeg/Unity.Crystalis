using UnityEngine;

namespace LeoDeg.Scriptables
{
    /// <summary>
    /// Similar to transform variables but this one is for keeping references to gameObjects or 
    /// better yet, prefabs. So you don't waste memory allocating the same prefab on multiple objects.
    /// </summary>
    [CreateAssetMenu(menuName = "LeoDeg/Variables/NavMeshScriptable")]
    public class NavMeshScriptable : ScriptableObject
    {
        public UnityEngine.AI.NavMeshAgent value;
    }
}
