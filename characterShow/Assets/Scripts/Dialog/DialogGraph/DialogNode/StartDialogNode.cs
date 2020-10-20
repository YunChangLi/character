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

        private ValueConnectionKnobAttribute dynamicKnobAttribute = new ValueConnectionKnobAttribute("Choose", Direction.Out, "System.Boolean");
        public List<string> StartOuputLabels = new List<string>(); //建立連線接點
        public int selected; //DropDown選中的數字
        private string[] options = new string[] { "None", "UnFinishQuest", "FinishQuest" };
        
        protected override void OnCreate()
        {
            backgroundColor = Color.yellow;

        }
        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal();
            selected = EditorGUILayout.Popup(selected, options);
            if (GUILayout.Button("Add", GUILayout.ExpandWidth(false))) 
            {
                StartOuputLabels.Add(options[selected]);
                CreateValueConnectionKnob(dynamicKnobAttribute);
            }
            GUILayout.EndHorizontal();
            for (int i = 0; i < StartOuputLabels.Count; i++)
            { // Display label and delete button
                GUILayout.BeginHorizontal();
                GUILayout.Label(StartOuputLabels[i]);
                ((ValueConnectionKnob)dynamicConnectionPorts[i]).SetPosition();
                if (GUILayout.Button("x", GUILayout.ExpandWidth(false)))
                { // Remove current label
                    Debug.Log("Want Delete " + dynamicConnectionPorts[i].name);
                    StartOuputLabels.RemoveAt(i);
                    DeleteConnectionPort(i);
                    i--;
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
            GUILayout.EndVertical();
        }
        public override bool Calculate()
        {
            for (int i = 0; i < dynamicConnectionPorts.Count; i++)
            {
                ((ValueConnectionKnob)dynamicConnectionPorts[i]).SetValue<bool>(false);
            }
            return true;
        }
    }

}