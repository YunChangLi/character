using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "QuestEventNode")]
    public class QuestEventNode : Node
    {
        public const string ID = "questEventNode";
        public override string GetID 
        {
            get { return ID; }
        }
        public override string Title { get { return "Quest Event"; } }
        public override Vector2 MinSize { get { return new Vector2(150, 300); } }

        public QuestEvent QEvent;
        public string TitleName;
        public string Description;
        public string QuestId;


        /*protected override void OnCreate()
        {
            QEvent = new QuestEvent();
        }*/
        public QuestEventNode()
        {
            QEvent = new QuestEvent();
        }

        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            TitleName = (string)RTEditorGUI.TextField(new GUIContent("title Name", "The name of the mission"), TitleName);
            QuestId = (string)RTEditorGUI.TextField(new GUIContent("id", "The name of the mission"), QEvent.GetID());
            GUILayout.EndVertical();

            GUILayout.Label("description");
            GUILayout.BeginHorizontal();
            Description = (string)RTEditorGUI.TextField(Description, GetTextFieldLayout(100));
            GUILayout.EndHorizontal();

           /* QEvent.SetMissionTitle(TitleName);
            QEvent.SetMissionDescription(Description);*/

        }
        private GUILayoutOption[] GetTextFieldLayout(int height)
        {
            return new GUILayoutOption[] {
                GUILayout.Height(height),

            };

        }
        public override bool AutoLayout => true;


    }

}
