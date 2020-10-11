using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "QuestEventNode/End Quest")]
    public class EndQuestNode : Node
    {


        public override string GetID => "endQuest";
        public override string Title => "End Quest";

        public override bool AutoLayout => true;

        public override Vector2 MinSize { get { return new Vector2(200, 40); } }


        [ValueConnectionKnob("End Flow", Direction.In, "System.Boolean", ConnectionCount.Single, NodeSide.Left, NodeSidePos = 20)]
        public ValueConnectionKnob EndFlowPort;

        //判斷任務條完成時是否有額外的活動
        public bool hasFinishEvent = false;
        public string Description;

        protected override void OnCreate()
        {
            backgroundColor = Color.red;
        }
        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            EndFlowPort.DisplayLayout();
            GUILayout.EndVertical();
            GUILayout.BeginHorizontal();
            hasFinishEvent = RTEditorGUI.Toggle(hasFinishEvent, new GUIContent("Has Finish Event"));

            GUILayout.EndHorizontal();
            if (hasFinishEvent) 
            {
                GUILayout.Label("description");
                GUILayout.BeginHorizontal();
                Description = (string)RTEditorGUI.TextField(Description, AdjustFieldLayout(200, 100));
                GUILayout.EndHorizontal();
            }
        }
        private GUILayoutOption[] AdjustFieldLayout(int width, int height)
        {
            return new GUILayoutOption[] {
                GUILayout.Height(height),
                GUILayout.Width(width),
            };

        }

    }

}