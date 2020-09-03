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

        protected override void OnCreate()
        {
            backgroundColor = Color.red;
        }
        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            EndFlowPort.DisplayLayout();
            GUILayout.EndVertical();
        }




    }

}