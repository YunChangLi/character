using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework.Standard;

[CustomEditor(typeof(QuestController))]
public class QuestControllerInspector : Editor
{

    QuestController controller;
    private void OnEnable()
    {
        controller = (QuestController)target;

    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Open Quest Flow Canvas"))
        {
            openCanvas();
        }
    }
    private void openCanvas()
    {
        if (controller.QuestFlowCanvas != null)
        {
            string CanvasPath = AssetDatabase.GetAssetPath(controller.QuestFlowCanvas);
            NodeEditorWindow.OpenNodeEditor().canvasCache.LoadNodeCanvas(CanvasPath);
        }

    }
}
