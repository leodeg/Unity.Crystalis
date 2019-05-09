using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeoDeg.Actions
{
    [CreateAssetMenu (menuName = "LeoDeg/Actions/Game/GetCursorPosition")]
    public class GetCursorPosition : Action
    {
        [Header ("Properties")]
        public Scriptables.Vector3Scriptable mousePosition;
        public float cameraRayLength;
        public LayerMask hitMask;

        [Header ("Use another camera")]
        [Tooltip ("If false then will be used main camera")]
        public bool useCustomCamera;
        public Camera customCamera;

        private RaycastHit hit;

        public override void Execute ()
        {
            Ray cameraRay;

            if (!useCustomCamera)
                cameraRay = Camera.main.ScreenPointToRay (Input.mousePosition);
            else cameraRay = customCamera.ScreenPointToRay (Input.mousePosition);

            if (Physics.Raycast (cameraRay, out hit, cameraRayLength, hitMask))
            {
                mousePosition.value = hit.point;
            }
        }
    }
}