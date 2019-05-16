using UnityEngine;
using System.Collections;

namespace LeoDeg.Inventories
{
    public class Weapon : MonoBehaviour
    {
        public ParticleSystem shootingEffect;
        public Transform muzzle;
        public Bullet bullet;
        public float timeBetweenShots = 100;
        public float muzzleVelocity = 35;
        public float damage;

        private float nextShotTime;

        public void Shoot ()
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + timeBetweenShots / 1000;
                Bullet newBullet = Instantiate (bullet, muzzle.position, muzzle.rotation);
                newBullet.SetSpeed (muzzleVelocity);

                Destroy (Instantiate (shootingEffect.gameObject, muzzle.position, Quaternion.FromToRotation (Vector3.forward, muzzle.forward)), shootingEffect.startLifetime);

            }
        }

        public float GetDamage ()
        {
            return bullet == null ? damage : bullet.damageAmount;
        }
    }
}