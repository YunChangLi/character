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

        public string TitleName;    //任務名稱
        public string Description;  //任務詳述
        public int QuestId;      //任務id
        public QuestGoal goalSetting; //實際任務運作

        public bool isFinished = false;


        //public vo
        public override void NodeGUI()
        {
            GUILayout.BeginVertical();
            InputKnob.DisplayLayout();
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            GUILayout.Label("QuestTitleName : ");
            TitleName = (string)RTEditorGUI.TextField(TitleName);
            GUILayout.Label("QuestID : ");
            GUILayout.Label(QuestId.ToString()) ;
            GUILayout.EndVertical();

            GUILayout.Label("description");
            GUILayout.BeginHorizontal();
            Description = (string)RTEditorGUI.TextField(Description, AdjustFieldLayout(200, 100));
            GUILayout.EndHorizontal();

            UniqueContent();

            GUILayout.BeginHorizontal();
            isFinished = RTEditorGUI.Toggle(isFinished, new GUIContent("isFinished"));
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
        protected virtual void UniqueContent()
        { 

        }
        public override bool Calculate()
        {
            OutputKnob.SetValue<bool>(isFinished);
            return true;
        }
        public void SetIsFinish(bool isFinished)
        {
            this.isFinished = isFinished;
        }
        public QuestBaseNode GetTheNextNode()
        {
            SetIsFinish(true);
            if (this.OutputKnob.connections[0].body.GetID == "endQuest")
                return null;

            return (QuestBaseNode)this.OutputKnob.connections[0].body;
        }
        public void SetQuestId(int questId)
        {
            this.QuestId = questId;
        }
        public abstract void CreateQuestInstance();
    }

}