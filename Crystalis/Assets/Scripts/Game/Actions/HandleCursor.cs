using UnityEngine;
using System.Collections;

namespace LeoDeg.Actions
{
    [CreateAssetMenu (menuName = "LeoDeg/Actions/Game/HandleCursor")]
    public class HandleCursor : Action
    {
        public CursorLockMode lockMode;
        public bool isVisible;

        public override void Execute ()
        {
            Cursor.lockState = lockMode;
            Cursor.visible = isVisible;
        }
    }
}