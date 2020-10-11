using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "DialogEventNode/Start Dialog")]
    public class StartDialogNode : Node
    {
        public override string GetID => "startDialog";
        public override string Title => "Start Dialog";

        public override bool AutoLayout => true;

        public override Vector2 MinSize { get { return new Vector2(200, 40); } }

        [ValueConnectionKnob("Start Flow", Direction.Out, "System.Boolean", ConnectionCount.Single, NodeSide.Right, NodeSidePos = 20)]
        public ValueConnectionKnob StartFlowPort;

        protected override void OnCreate()
        {
            backgroundColor = Color.yellow;
        }
        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            StartFlowPort.DisplayLayout();
            GUILayout.EndVertical();
        }
        public override bool Calculate()
        {
            StartFlowPort.SetValue<bool>(false);
            return true;
        }
    }

}