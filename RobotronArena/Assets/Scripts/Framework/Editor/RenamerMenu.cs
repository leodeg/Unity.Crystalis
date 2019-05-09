using UnityEditor;
using UnityEngine;

namespace LeoDeg.Editor
{
    public class RenamerMenu : MonoBehaviour
    {
        [MenuItem ("LeoDeg/Renamer Menu %#&r")]
        public static void OpenRenamerEditorWindow ()
        {
            RenamerEditorWindow.OpenWindow ();
        }
    }
}