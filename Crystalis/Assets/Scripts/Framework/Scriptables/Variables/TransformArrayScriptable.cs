﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Scriptables
{
    [CreateAssetMenu(menuName = "LeoDeg/Variables/TransformArrayScriptable")]
    public class TransformArrayScriptable : ScriptableObject
    {
        public Transform[] value;

        public int Length()
        {
            return value.Length;
        }

        public void Clear()
        {
            value = null;
        }

        public void Init(int v)
        {
            value = new Transform[v];
        }

        public void ReplaceAt(Transform targetTransform, int pos)
        {
            if(pos < value.Length)
            {
                value[pos] = targetTransform;
            }
        }
    }
}
