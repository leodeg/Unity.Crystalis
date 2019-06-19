using UnityEngine;
using System.Collections;
using LeoDeg.Managers;

namespace LeoDeg.Inventories
{
    public class WeaponController : MonoBehaviour
    {
        public ParticleSystem shootingEffect;
        public Transform muzzle;
        public Bullet bullet;
        public float timeBetweenShots = 100;
        public float muzzleVelocity = 35;
        public float damage;
        public float maxRecoilForce = 0.7f;

        public AudioClip reloadAudio;
        public AudioClip shootAudio;

        private float nextShotTime;

        public void Shoot ()
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + timeBetweenShots / 1000;
                Bullet newBullet = Instantiate (bullet, muzzle.position, muzzle.rotation);
                newBullet.SetSpeed (muzzleVelocity);

                // Destroy (Instantiate (shootingEffect.gameObject, muzzle.position, Quaternion.FromToRotation (Vector3.forward, muzzle.forward)), shootingEffect.main.startLifetimeMultiplier);

                transform.localPosition -= Vector3.forward * Random.Range (0f, maxRecoilForce);

                AudioManager.Instance.PlaySound (shootAudio, muzzle.position);
            }
        }

        public void ResetPosition ()
        {
            transform.localPosition = Vector3.Lerp (transform.localPosition, Vector3.zero, 0.1f);
        }

        public void Reload ()
        {
            AudioManager.Instance.PlaySound (reloadAudio, this.transform.position);
        }

        public float GetDamage ()
        {
            return bullet == null ? damage : bullet.damageAmount;
        }
    }
}