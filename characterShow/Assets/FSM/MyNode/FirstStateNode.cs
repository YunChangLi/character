using NodeEditorFramework.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/First State Node")]
    public class FirstStateNode : StateNodeBase
    {
        public const string ID = "firstStateNode";

        public override string GetID { get { return ID; } }

        public override string Title { get { return "Entry State"; } }

        public override Vector2 MinSize { get { return new Vector2(200, 10); } }

        public override bool AutoLayout { get { return true; } } // IMPORTANT -> Automatically resize to fit list

        // 允許只有一個輸出狀態
        [ValueConnectionKnob("Output", Direction.Out, "Float", MaxConnectionCount = ConnectionCount.Single)]
        public ValueConnectionKnob outputKnob;

        public Node FirstActionNode;

        public override void DoBeforeRunFSM()
        {
            if(outputKnob.connected())
                FirstActionNode = outputKnob.connections[0].body;
            else
                Debug.LogError("FSM: No first action connected!");
        }

        public override void NodeGUI()
        {
            IsFold = RTEditorGUI.Foldout(IsFold, FoldStatus);
            if (IsFold)
            {
                outputKnob.DisplayLayout();
                if (outputKnob.connected())
                {
                    GUILayout.Label("First State: " + outputKnob.connections[0].body.Title);
                }
                FoldStatus = "Fold";
            }
            else
            {
                outputKnob.SetPosition(30);
                FoldStatus = "Expand";
            }
        }

        protected override void OnCreate()
        {
            // 改變這個Node的背景顏色
            backgroundColor = Color.cyan;
            ((StateMachineCanvasType)NodeEditor.curNodeCanvas).HasStartNode = true;
        }

        protected override void OnDelete()
        {
            ((StateMachineCanvasType)NodeEditor.curNodeCanvas).HasStartNode = false;
        }

    }
}
