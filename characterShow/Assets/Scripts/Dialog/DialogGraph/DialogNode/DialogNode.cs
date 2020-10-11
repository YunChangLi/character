using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "DialogEventNode/Dialog Node")]
    public class DialogNode : Node
    {

        [ValueConnectionKnob("Input", Direction.In, "System.Boolean", ConnectionCount.Multi, NodeSide.Left)]
        public ValueConnectionKnob InputKnob;
        [ValueConnectionKnob("Output", Direction.Out, "System.Boolean", ConnectionCount.Multi, NodeSide.Right)]
        public ValueConnectionKnob OutputKnob;
        public override string GetID => "DialogContent";
        public override string Title => "Dialog";


        public override bool AutoLayout => true;

        /// <summary>
        /// Specifies the minimum size the node can have if no content is present.
        /// </summary>
        public override Vector2 MinSize { get { return new Vector2(200, 200); } }
        public string Description;  //任務詳述


        //public vo
        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            InputKnob.DisplayLayout();
            GUILayout.EndVertical();

            GUILayout.Label(Title + " content");
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal();
            Description = (string)RTEditorGUI.TextField(Description, AdjustFieldLayout(200, 100));
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal();
            OutputKnob.DisplayLayout();
            GUILayout.EndHorizontal();

        }
        protected GUILayoutOption[] AdjustFieldLayout(int width, int height)
        {
            return new GUILayoutOption[] {
                GUILayout.Height(height),
                GUILayout.Width(width),
            };

        }
        public override bool Calculate()
        {

            return true;
        }


        /*public QuestBaseNode GetTheNextNode()
        {

            if (this.OutputKnob.connections[0].body.GetID == "endQuest")
            {
                //show the UI 可說明故事劇情 in Finish event
                return null;
            }


            return (QuestBaseNode)this.OutputKnob.connections[0].body;
        }*/
        


    }

}