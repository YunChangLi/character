using UnityEngine;
using UnityEditor;
using System.Collections;
    
[CustomEditor(typeof(preview))]
public class previewWindow : EditorWindow
{
    GameObject gameObject;
    Editor gameObjectEditor;
    public Rect windowRect = new Rect(20, 20, 120, 50);

    [MenuItem("Window/Player Editor")]
    static void ShowWindow()
    {
        //初始化視窗大小
        GetWindowWithRect<previewWindow>(new Rect(0, 0, 400, 400));
        
    }
    
    void OnGUI()
    {
        BeginWindows();
        windowRect = GUI.Window(0, windowRect, DoMyWindow, "My Window");
        EndWindows() ;
        gameObject = (GameObject)EditorGUILayout.ObjectField(gameObject, typeof(GameObject), true);
        


        if (gameObject != null)
        {
            if (gameObjectEditor == null) 
                gameObjectEditor = new Editor();


            gameObjectEditor.OnPreviewGUI(GUILayoutUtility.GetRect(500, 400), GUIStyle.none);
        }
        
        
    }
    void DoMyWindow(int windowID)
    {
        
        if (GUI.Button(new Rect(10, 20, 100, 20), "Hello World"))
        {
            
        }
        GUI.DragWindow(new Rect(0, 0, 100, 20));
    }
}
