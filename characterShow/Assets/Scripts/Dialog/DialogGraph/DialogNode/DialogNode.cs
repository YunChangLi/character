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
        public override string GetID => "DialogContent";
        public override string Title => "Dialog";
        public override bool AutoLayout => true;
        public List<string> OuputLabels = new List<string>();

        /// <summary>
        /// Specifies the minimum size the node can have if no content is present.
        /// </summary>
        public override Vector2 MinSize { get { return new Vector2(200, 50); } }
        public string Description;  //任務詳述
        private ValueConnectionKnobAttribute dynamicKnobAttribute = new ValueConnectionKnobAttribute("Choose", Direction.Out, "System.Boolean");
        private string newChoice = "";

        //public vo
        public override void NodeGUI()
        {
            
            if (dynamicConnectionPorts.Count != OuputLabels.Count)
            { // Make sure labels and ports are synchronised
                while (dynamicConnectionPorts.Count > OuputLabels.Count)
                    DeleteConnectionPort(dynamicConnectionPorts.Count - 1);
                while (dynamicConnectionPorts.Count < OuputLabels.Count)
                    CreateValueConnectionKnob(dynamicKnobAttribute);
            }

            GUILayout.BeginVertical();
            InputKnob.DisplayLayout();
            GUILayout.EndVertical();

            GUILayout.Label(Title + " content");
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal();
            //Description = (string)RTEditorGUI.TextField(Description, AdjustFieldLayout(193, 100));
            Description = GUILayout.TextArea(Description, 500);
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal();
            newChoice = RTEditorGUI.TextField(GUIContent.none, newChoice);
            if (GUILayout.Button("AddChoice", GUILayout.ExpandWidth(false)))
            {
                OuputLabels.Add(newChoice);
                CreateValueConnectionKnob(dynamicKnobAttribute);
                Debug.Log(dynamicConnectionPorts[dynamicConnectionPorts.Count-1].name);
            }
            GUILayout.EndHorizontal();

            for (int i = 0; i < OuputLabels.Count; i++)
            { // Display label and delete button
                GUILayout.BeginHorizontal();
                GUILayout.Label(OuputLabels[i]);
                ((ValueConnectionKnob)dynamicConnectionPorts[i]).SetPosition();
                if (GUILayout.Button("x", GUILayout.ExpandWidth(false)))
                { // Remove current label
                    Debug.Log("Want Delete " + dynamicConnectionPorts[i].name);
                    OuputLabels.RemoveAt(i);
                    DeleteConnectionPort(i);
                    i--;
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();

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