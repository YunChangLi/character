using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework.Standard;

[CustomEditor(typeof(ActionController))]
public class ActionControllerInspector : Editor
{
    ActionController controller;
    public void OnEnable()
    {
        controller = (ActionController)target;
        controller.StateMachineCanvas.Validate();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Open"))
        {
            string NodeCanvasPath = AssetDatabase.GetAssetPath(controller.StateMachineCanvas);
            NodeEditorWindow.OpenNodeEditor().canvasCache.LoadNodeCanvas(NodeCanvasPath);
        }
    }
}
