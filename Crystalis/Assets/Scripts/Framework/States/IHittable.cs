using System;
using UnityEngine;

namespace LeoDeg.Properties
{
    public interface IHittable
    {
        void TakeHit (float damage, Vector3 hitPoint, Vector3 hitDirection, bool showHitEffect = true);
        void TakeDamage (float damage);
    }
}
