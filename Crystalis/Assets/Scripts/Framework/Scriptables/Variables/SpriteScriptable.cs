using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Scriptables
{
    [CreateAssetMenu(menuName = "LeoDeg/Variables/SpriteScriptable")]
    public class SpriteScriptable : ScriptableObject
    {
        public Sprite value;

        public void Set(Sprite v)
        {
            value = v;
        }

        public void Set(SpriteScriptable v)
        {
            value = v.value;
        }
    }
}
