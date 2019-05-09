using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Scriptables
{
    [CreateAssetMenu(menuName = "LeoDeg/Variables/BoolScriptable")]
    public class BoolScriptable : ScriptableObject
    {
        public bool value;

        private void OnEnable ()
        {
            value = false;
        }

        public void Set(bool v)
        {
            value = v;
        }

        public void Set(BoolScriptable v)
        {
            value = v.value;
        }

        public void Reverse()
        {
            value = !value;
        }

        public bool Compare(bool v)
        {
            return v == value;
        }

        public bool Compare(BoolScriptable v)
        {
            return value == v.value;
        }

    }
}
