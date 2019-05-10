using UnityEngine;
using System.Collections;

namespace LeoDeg.Actions
{
    [CreateAssetMenu (menuName = "LeoDeg/Actions/Game/CameraFollow")]
    public class CameraFollow : Action
    {
        [Header ("Scriptable References")]
        public bool useCustomCamera;
        public Camera customCamera;
        public Scriptables.TransformScriptable target;
        public Scriptables.FloatScriptable deltaTime;

        [Header ("Properties")]
        public float speed = 5f;
        public Vector3 offset;

        public override void Execute ()
        {
            Vector3 targetPosition = target.value.position + offset;
         
            if (!useCustomCamera)
            {
                Transform cameraTransform = Camera.main.transform;
                cameraTransform.position = Vector3.Lerp (cameraTransform.position, targetPosition, speed * deltaTime.value);
            }
            else
            {
                customCamera.transform.position = Vector3.Lerp (customCamera.transform.position, targetPosition, speed * deltaTime.value);
            }
        }
    }
}