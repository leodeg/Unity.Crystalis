using UnityEditor;
using UnityEngine;

namespace LeoDeg.Editor
{
    public class GroupObjectsEditorWindow : EditorWindow
    {
        private static GroupObjectsEditorWindow groupObjectsWindow;
        private string groupName = "Enter Name";
        private GameObject[] selectedObjects = new GameObject[0];

        public static void OpenWindow ()
        {
            groupObjectsWindow = GetWindow<GroupObjectsEditorWindow> ();
            groupObjectsWindow.Show ();
        }

        private void OnGUI ()
        {
            // Find selection objects
            selectedObjects = Selection.gameObjects;

            EditorGUILayout.BeginHorizontal ();
            EditorGUILayout.Space ();
            EditorGUILayout.BeginVertical ();
            EditorGUILayout.Space ();

            EditorGUILayout.LabelField ("Selection Count: " + selectedObjects.Length.ToString ());
            GUILayout.Space (5);

            EditorGUILayout.LabelField ("Group Name", EditorStyles.boldLabel);
            groupName = EditorGUILayout.TextField (groupName);
            GUILayout.Space (2);

            if (GUILayout.Button ("Group Selected", GUILayout.ExpandWidth (true), GUILayout.Height (45)))
                GroupSelectedObjects ();

            EditorGUILayout.Space ();
            EditorGUILayout.EndVertical ();
            EditorGUILayout.Space ();
            EditorGUILayout.EndHorizontal ();

            Repaint ();
        }

        private void GroupSelectedObjects ()
        {
            if (selectedObjects.Length > 0)
            {
                if (groupName == "Enter Name")
                {
                    EditorUtility.DisplayDialog ("Group Objects Editor Window", "You must provide a name for your group!", "OK");
                }
                else
                {
                    GameObject groupObject = new GameObject (groupName + "_Group");
                    foreach (GameObject selectedObject in selectedObjects)
                        selectedObject.transform.SetParent (groupObject.transform);
                }
            }
            else EditorUtility.DisplayDialog ("Group Objects Editor Window", "You must select at least one object on the scene", "OK");
        }

        private void CloseWindow ()
        {
            if (groupObjectsWindow != null)
                groupObjectsWindow.Close ();
        }
    }
}