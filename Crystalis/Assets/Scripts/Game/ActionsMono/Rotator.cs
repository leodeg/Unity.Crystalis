using UnityEngine;
using System.Collections;

namespace LeoDeg.MonoActions
{
    public class Rotator : ActionsMono
    {
        public Vector3 direction;
        public float speed;

        protected override void ExecuteUpdate ()
        {
            transform.Rotate (direction, speed * Time.deltaTime);
        }
    }
}
