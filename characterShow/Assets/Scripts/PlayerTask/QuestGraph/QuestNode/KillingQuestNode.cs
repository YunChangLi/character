using NodeEditorFramework.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [Node(false, "QuestEventNode/Killing Quest")]
    public class KillingQuestNode : QuestBaseNode
    {
        public override string GetID => "KillingQuset";
        public override string Title => "Killing";

        public MonsterData Monster;
        public int RequiredAmount;

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
            Monster = RTEditorGUI.ObjectField<MonsterData>(new GUIContent("Monster"), Monster, false, AdjustFieldLayout(10, 10));

            GUILayout.EndHorizontal();
            EditorGUIUtility.labelWidth = 100;
            RequiredAmount = RTEditorGUI.IntField(new GUIContent("Required Amount"), RequiredAmount);

            GUILayout.EndVertical();
        }

        public override void CreateQuestInstance()
        {
            goalSetting = new KillingGoal(RequiredAmount, Monster);
            Debug.Log("Required : " + RequiredAmount);
            Debug.Log("Monster : " + Monster);
        }
    }
}

