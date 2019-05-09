using UnityEditor;
using UnityEngine;

namespace LeoDeg.Editor
{
    public class RenamerEditorWindow : EditorWindow
    {
        private static RenamerEditorWindow renamerWindow;
        private GameObject[] selectedObjects = new GameObject[0];

        private string newName = "Enter Name";
        private string labelName;

        public static void OpenWindow ()
        {
            renamerWindow = GetWindow<RenamerEditorWindow> ();
            renamerWindow.Show ();
        }

        private void OnGUI ()
        {
            selectedObjects = Selection.gameObjects;

            EditorGUILayout.BeginHorizontal ();
            EditorGUILayout.Space ();
            EditorGUILayout.BeginVertical ();
            EditorGUILayout.Space ();

            // Draw selection objects count
            EditorGUILayout.LabelField ("Selection Count: " + selectedObjects.Length.ToString ());
            GUILayout.Space (5);

            // Draw name of a new objects
            labelName = selectedObjects.Length < 2 ? "Object Name" : "Objects Name";
            EditorGUILayout.LabelField (labelName, EditorStyles.boldLabel);
            newName = EditorGUILayout.TextField (newName);
            GUILayout.Space (2);

            // Draw button to create the new object
            if (GUILayout.Button ("Rename", GUILayout.ExpandWidth (true), GUILayout.Height (45)))
                RenameObjects ();

            EditorGUILayout.Space ();
            EditorGUILayout.EndVertical ();
            EditorGUILayout.Space ();
            EditorGUILayout.EndHorizontal ();

            Repaint ();
        }

        private void RenameObjects ()
        {
            if (selectedObjects.Length > 0)
            {
                if (newName != "Enter Name")
                    foreach (GameObject obj in selectedObjects)
                        obj.name = newName;
                else EditorUtility.DisplayDialog ("Renamer Editor Window", "You must provide a name for your objects!", "OK");
            }
            else EditorUtility.DisplayDialog ("Renamer Editor Window", "You must select at least one object on the scene", "OK");
        }
    }
}