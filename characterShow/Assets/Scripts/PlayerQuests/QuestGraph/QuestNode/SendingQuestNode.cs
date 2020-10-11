using NodeEditorFramework.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [Node(false, "QuestEventNode/Sending Quest")]
    public class SendingQuestNode : QuestBaseNode
    {
        public override string GetID => "SendingQuest";
        public override string Title => "Sending";

        public NPCData NeedNPC; 
        public Item NeedItem;

        public override bool AutoLayout => true;

        /// <summary>
        /// Specifies the minimum size the node can have if no content is present.
        /// </summary>
        public override Vector2 MinSize { get { return new Vector2(200, 200); } }



        protected override void UniqueContent()
        {
            GUILayout.Label(Title + " content");
            GUILayout.BeginVertical("box");

            GUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 70;
            NeedNPC = RTEditorGUI.ObjectField<NPCData>(new GUIContent("Need NPC"), NeedNPC, false, AdjustFieldLayout(10, 10));

            GUILayout.EndHorizontal();
            EditorGUIUtility.labelWidth = 70;
            NeedItem = RTEditorGUI.ObjectField<Item>(new GUIContent("Need Item"), NeedItem, false, AdjustFieldLayout(10, 10));

            GUILayout.EndVertical();
        }

        public override void CreateQuestInstance()
        {
            goalSetting = new SendingGoal(NeedNPC, NeedItem);

        }
    }
}
