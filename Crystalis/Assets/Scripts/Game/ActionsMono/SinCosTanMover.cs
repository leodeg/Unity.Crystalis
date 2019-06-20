using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.MonoActions
{
    public class SinCosTanMover : ActionsMono
    {
        [Header ("Setup")]
        [SerializeField] private Vector3 startPosition;
        [SerializeField] private Vector3 offsetPosition;
        [SerializeField] private bool useLocalPos;

        [Header ("Speed")]
        [SerializeField] private float speedX = 1f;
        [SerializeField] private float speedY = 1f;
        [SerializeField] private float speedZ = 1f;

        [Header ("Distance")]
        [SerializeField] private float distanceX = 1f;
        [SerializeField] private float distanceY = 1f;
        [SerializeField] private float distanceZ = 1f;

        [Header ("Tangent Time Seconds")]
        [SerializeField] private float timeX = 1f;
        [SerializeField] private float timeY = 1f;
        [SerializeField] private float timeZ = 1f;

        [Header ("Shift Phase")]
        [SerializeField] private float shift = 0.5f;

        [Header ("How to move platform:")]
        [SerializeField] private bool startMovePlatformByCosAndSin;
        [SerializeField] private bool startMovePlatformByTangent;

        [Header ("Where to go:")]
        [SerializeField] private bool moveX;
        [SerializeField] private bool moveY;
        [SerializeField] private bool moveZ;

        protected override void ExecuteStart ()
        {
            if (useLocalPos)
                startPosition = transform.localPosition;
            else startPosition = transform.position;
        }

        protected override void ExecuteUpdate ()
        {
            if (startMovePlatformByCosAndSin && !startMovePlatformByTangent)
            {
                MoveByCosAndSin ();
            }
            if (startMovePlatformByTangent && !startMovePlatformByCosAndSin)
            {
                MoveByTangent ();
            }
        }

        private void MoveByCosAndSin ()
        {
            float x = startPosition.x;
            float y = startPosition.y;
            float z = startPosition.z;

            if (moveX)
            {
                //x = Mathf.Sin (( Time.timeSinceLevelLoad + Mathf.PI * shift ) * speedX) * distanceX + startPosition.x;
                x = Mathf.Cos (Time.timeSinceLevelLoad * speedX + startPosition.x) * distanceX;
            }
            if (moveY)
            {
                y = Mathf.Sin (Time.timeSinceLevelLoad * speedY + startPosition.y) * distanceY;
            }
            if (moveZ)
            {
                z = Mathf.Cos (Time.timeSinceLevelLoad * speedZ + startPosition.z) * distanceZ;
            }

            Vector3 finalPos = new Vector3 (x, y, z) + offsetPosition;

            if (useLocalPos)
                transform.localPosition = finalPos;
            else transform.position = finalPos;
        }

        private void MoveByTangent ()
        {
            float x = startPosition.x;
            float y = startPosition.y;
            float z = startPosition.z;

            if (moveX)
            {
                x = Mathf.Tan (Time.timeSinceLevelLoad * speedX + startPosition.x) * timeX;
            }
            if (moveY)
            {
                y = Mathf.Tan (Time.timeSinceLevelLoad * speedY + startPosition.y) * timeY;
            }
            if (moveZ)
            {
                z = Mathf.Tan (Time.timeSinceLevelLoad * speedZ + startPosition.z) * timeZ;
            }

            Vector3 finalPos = new Vector3 (x, y, z) + offsetPosition;

            if (useLocalPos)
                transform.localPosition = finalPos;
            else transform.position = finalPos;
        }
    }
}