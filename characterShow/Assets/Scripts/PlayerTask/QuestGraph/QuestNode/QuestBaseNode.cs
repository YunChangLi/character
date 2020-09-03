using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    public abstract class QuestBaseNode : Node
    {

        [ValueConnectionKnob("Input", Direction.In, "System.Boolean", ConnectionCount.Single, NodeSide.Left)]
        public ValueConnectionKnob InputKnob;
        [ValueConnectionKnob("Output", Direction.Out, "System.Boolean", ConnectionCount.Single, NodeSide.Right)]
        public ValueConnectionKnob OutputKnob;

        public string TitleName;
        public string Description;
        public string QuestId;



        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            InputKnob.DisplayLayout();
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUILayout.Label("QuestTitleName : ");
            TitleName = (string)RTEditorGUI.TextField(TitleName);
            GUILayout.Label("QuestID : ");
            GUILayout.Label(QuestId);
            GUILayout.EndVertical();

            GUILayout.Label("description");
            GUILayout.BeginHorizontal();
            Description = (string)RTEditorGUI.TextField(Description, AdjustFieldLayout(200, 100));
            GUILayout.EndHorizontal();

            UniqueContent();

            GUILayout.BeginVertical();
            OutputKnob.DisplayLayout();
            GUILayout.EndVertical();


        }
        protected GUILayoutOption[] AdjustFieldLayout(int width, int height)
        {
            return new GUILayoutOption[] {
                GUILayout.Height(height),
                GUILayout.Width(width),
            };

        }
        protected virtual void UniqueContent()
        { 

        }


    }

}