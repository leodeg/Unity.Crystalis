using UnityEngine;
using System.Collections;

namespace LeoDeg.Inventories
{
    public class Weapon : MonoBehaviour
    {
        public Transform muzzle;
        public Bullet bullet;
        public float timeBetweenShots = 100;
        public float muzzleVelocity = 35;

        private float nextShotTime;

        public void Shoot ()
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + timeBetweenShots / 1000;
                Bullet newBullet = Instantiate (bullet, muzzle.position, muzzle.rotation);
                newBullet.SetSpeed (muzzleVelocity);
            }
        }
    }
}