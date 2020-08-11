using UnityEngine;
using UnityEditor;

// Create an editor window which can display a chosen GameObject.
// Use OnInteractivePreviewGUI to display the GameObject and
// allow it to be interactive.

[CustomEditor(typeof(preview))]
public class test : EditorWindow
{
    GameObject gameObject;
    Editor gameObjectEditor;

    [MenuItem("Window/Player Editor")]
    static void ShowWindow()
    {
        //初始化視窗大小
        GetWindowWithRect<test>(new Rect(0, 0, 400, 400));
    }

    void OnGUI()
    {
        gameObject = (GameObject)EditorGUILayout.ObjectField(gameObject, typeof(GameObject), true);

        //GUIStyle bgColor = GUIStyle.none;
        //bgColor.normal.background = EditorGUIUtility.whiteTexture;

        if (gameObject != null)
        {
            if (gameObjectEditor == null)
                gameObjectEditor = Editor.CreateEditor(gameObject);

            gameObjectEditor.OnInteractivePreviewGUI(GUILayoutUtility.GetRect(500,400), GUIStyle.none);
        }
    }
}