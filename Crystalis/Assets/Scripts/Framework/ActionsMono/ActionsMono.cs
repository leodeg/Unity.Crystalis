using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.MonoActions
{
    public class ActionsMono : MonoBehaviour
    {
        private void Start ()
        {
            ExecuteStart ();
        }

        private void Update ()
        {
            ExecuteUpdate ();
        }

        private void FixedUpdate ()
        {
            ExecuteFixedUpdate ();
        }

        protected virtual void ExecuteStart () { }
        protected virtual void ExecuteUpdate () { }
        protected virtual void ExecuteFixedUpdate () { }
    }
}