using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Scriptables
{
    [CreateAssetMenu(menuName = "LeoDeg/Variables/TransformScriptable")]
    public class TransformScriptable : ScriptableObject
    {
        public Transform value;

        public void Set(Transform v)
        {
            value = v;
        }

        public void Set(TransformScriptable v)
        {
            value = v.value;
        }

        public void Clear()
        {
            value = null;
        }
    }
}
