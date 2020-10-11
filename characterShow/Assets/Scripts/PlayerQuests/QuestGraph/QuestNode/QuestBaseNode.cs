using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;
using UnityEngine.UI;

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
        public string QuestId;      //任務id
        public string ParentID;     //QuestSetID
        public int PlayerListID;    //玩家任務列表裡的排序
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
            GUILayout.Label(QuestId) ;
            GUILayout.EndVertical();

            GUILayout.Label("description");
            GUILayout.BeginHorizontal();
            Description = (string)RTEditorGUI.TextField(Description, AdjustFieldLayout(200, 100));
            GUILayout.EndHorizontal();

            UniqueContent();

            GUILayout.BeginVertical();
            if (GUILayout.Button("Open Dialog")) 
            {
                Debug.Log("Open");
            }
            GUILayout.EndVertical();
            
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
            SetQuestId(System.Guid.NewGuid().ToString());
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
            {
                //show the UI 可說明故事劇情 in Finish event
                return null;
            }
                

            return (QuestBaseNode)this.OutputKnob.connections[0].body;
        }
        /// <summary>
        /// 記錄此任務節點是存在玩家任務列表裡的哪一項
        /// </summary>
        /// <param name="ListID"></param>
        public void SetPlayerListID(int ListID)
        {
            this.PlayerListID = ListID;
        }
        public void SetQuestId(string questId)
        {
            this.QuestId = questId;
        }
        /// <summary>
        /// 獲取QuestFlowID
        /// </summary>
        /// <param name="parentID"></param>
        public void setParentID(string parentID)
        {
            this.ParentID = parentID;
        }
        /// <summary>
        /// 實例化任務目標
        /// </summary>
        public abstract void CreateQuestInstance();


    }

}