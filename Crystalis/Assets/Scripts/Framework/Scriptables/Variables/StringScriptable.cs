using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Scriptables
{
    [CreateAssetMenu(menuName = "LeoDeg/Variables/StringScriptable")]
    public class StringScriptable : ScriptableObject
    {
        public string value;

        public void Set(string v)
        {
            value = v;
        }

        public void Set(StringScriptable v)
        {
            value = v.value;
        }

        public bool IsEmptyOrNull()
        {
            return string.IsNullOrEmpty(value);
        }

        public void Clear()
        {
            value = string.Empty;
        }
    }
}
