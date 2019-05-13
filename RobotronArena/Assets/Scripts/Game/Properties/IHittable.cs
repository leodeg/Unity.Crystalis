using System;
using UnityEngine;

namespace LeoDeg.Properties
{
    interface IHittable
    {
        void TakeHit (float damage, Vector3 hitPoint, Vector3 hitDirection);
        void TakeDamage (float damage);
    }
}
