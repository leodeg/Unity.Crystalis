using UnityEngine;
using UnityEditor;

namespace LeoDeg.Editor
{
    public class GroupObjectsMenu : MonoBehaviour
    {
        [MenuItem ("LeoDeg/Group Objects %#&d")]
        public static void OpenGroupObjectsEditorWindow ()
        {
            GroupObjectsEditorWindow.OpenWindow ();
        }
    }
}