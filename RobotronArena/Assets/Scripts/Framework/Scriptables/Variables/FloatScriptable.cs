using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Scriptables
{
    [CreateAssetMenu(menuName = "LeoDeg/Variables/FloatScriptable")]
    public class FloatScriptable : NumberScriptable
    {
        public float value;

        public void Set(float v)
        {
            value = v;
        }

        public void Set(NumberScriptable v)
        {
            if (v is FloatScriptable)
            {
                FloatScriptable f = (FloatScriptable)v;
                value = f.value;
            }

            if (v is IntScriptable)
            {
                IntScriptable i = (IntScriptable)v;
                value = i.value;
            }
        }

        public void Add(float v)
        {
            value += v;
        }

        public void Add(NumberScriptable v)
        {
            if (v is FloatScriptable)
            {
                FloatScriptable f = (FloatScriptable)v;
                value += f.value;
            }

            if (v is IntScriptable)
            {
                IntScriptable i = (IntScriptable)v;
                value += i.value;
            }
        }
    }
}
