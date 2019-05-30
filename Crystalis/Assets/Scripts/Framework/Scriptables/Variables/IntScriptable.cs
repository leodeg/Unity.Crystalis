using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Scriptables
{
    [CreateAssetMenu(menuName = "LeoDeg/Variables/IntegerScriptable")]
    public class IntScriptable : NumberScriptable
    {
        public int value;

        public void Set(int v)
        {
            value = v;
        }

        public void Set(NumberScriptable v)
        {
            if(v is FloatScriptable)
            {
                FloatScriptable f = (FloatScriptable)v;
                value = Mathf.RoundToInt(f.value);
            }

            if(v is IntScriptable)
            {
                IntScriptable i = (IntScriptable)v;
                value = i.value;
            }
        }

        public void Add(int v)
        {
            value += v;
        }
        
        public void Add(NumberScriptable v)
        {
            if (v is FloatScriptable)
            {
                FloatScriptable f = (FloatScriptable)v;
                value += Mathf.RoundToInt(f.value);
            }

            if (v is IntScriptable)
            {
                IntScriptable i = (IntScriptable)v;
                value += i.value;
            }
        }
    }
}
