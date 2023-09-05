using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CreateFolders : EditorWindow
    {
        //private static string projectName = "PROJECT_NAME";

        [MenuItem("Assets/Create Default Folders")]
        private static void SetUpFolders()
        {
            CreateFolders window = ScriptableObject.CreateInstance<CreateFolders> ();
            window.position = new Rect(Screen.width/2, Screen.height/2, 400, 150);
            window.ShowPopup();
        }

        private static void CreateAllFolders()
        {
            List<string> folders = new List<string>
            {
                "Animations",
                "Audio",
                "Editor",
                "Materials",
                "Meshes",
                "Prefabs",
                "Scripts",
                "Scenes",
                "Shaders",
                "Textures",
                "UI",
                "Third Party"
            };
            foreach (string folder in folders)
            {
                if (!Directory.Exists("Assets/" + folder))
                {
                    Directory.CreateDirectory("Assets/" + folder);
                }

                List<string> uiFolders = new List<string>
                {
                    "Assets",
                    "Fonts",
                    "Icon"
                };
                foreach (string subfolder in uiFolders)
                {
                    if (!Directory.Exists("Assets/"+ "UI/" + subfolder))
                    {
                        Directory.CreateDirectory("Assets/" + "UI/" + subfolder);
                    }
                }
                AssetDatabase.Refresh();
            }
        }

        void OnGUI()
        {
            // EditorGUILayout. LabelField("Insert the Project name used as the root folder");
            // projectName = EditorGUILayout. TextField("Project Name: ",projectName);
            // this. Repaint ();
            //GUILayout. Space (70);
            if (GUILayout.Button("Generate!"))
            {
                CreateAllFolders();
                this.Close();
            }
        }
    }
}