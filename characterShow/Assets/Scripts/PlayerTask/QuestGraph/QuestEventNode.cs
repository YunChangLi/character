using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "QuestEventNode/prototype")]
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
        }

        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            GUILayout.Label("QuestTitleName : ");
            TitleName = (string)RTEditorGUI.TextField(TitleName);
            GUILayout.Label("QuestID : ");
            GUILayout.Label(QuestId);
            GUILayout.EndVertical();

            GUILayout.Label("description");
            GUILayout.BeginHorizontal();
            Description = (string)RTEditorGUI.TextField(Description, GetTextFieldLayout(100));
            GUILayout.EndHorizontal();

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
