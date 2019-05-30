﻿using UnityEngine;

namespace LeoDeg.Properties
{
    [System.Serializable]
    public class MovementProperties
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public Vector3 moveDirection;
        public Vector3 cameraForward;
    }
}