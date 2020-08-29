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
        if(controller.StateMachineCanvas != null)
            controller.StateMachineCanvas.Validate();
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Open State Machine Canvas"))
        {
            string NodeCanvasPath = AssetDatabase.GetAssetPath(controller.StateMachineCanvas);
            NodeEditorWindow.OpenNodeEditor().canvasCache.LoadNodeCanvas(NodeCanvasPath);
        }
        // 一鍵添加需要的Component
        if (GUILayout.Button("Create Components"))
        {
            if (controller.GetComponent<Animator>() == null)
                controller.gameObject.AddComponent<Animator>();
            if (controller.GetComponent<CharacterController>() == null)
                controller.gameObject.AddComponent<CharacterController>();
            if (controller.GetComponent<MonsterInfo>() == null)
                controller.gameObject.AddComponent<MonsterInfo>();
            if (controller.GetComponent<MonsterController>() == null)
                controller.gameObject.AddComponent<MonsterController>();
        }
    }
}
