using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "DialogEventNode/End Dialog")]
    public class EndDialogNode : Node
    {


        public override string GetID => "endDialog";
        public override string Title => "End Dialog";

        public override bool AutoLayout => true;

        public override Vector2 MinSize { get { return new Vector2(200, 40); } }


        [ValueConnectionKnob("End Flow", Direction.In, "System.Boolean", ConnectionCount.Multi, NodeSide.Left, NodeSidePos = 20)]
        public ValueConnectionKnob EndFlowPort;



        protected override void OnCreate()
        {
            backgroundColor = Color.blue;
        }
        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            EndFlowPort.DisplayLayout();
            GUILayout.EndVertical();
            
        }

    }

}