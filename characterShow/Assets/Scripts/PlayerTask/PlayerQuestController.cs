using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Standard;

namespace NodeEditorFramework.Standard
{
    public class PlayerQuestController : MonoBehaviour
    {
        // Start is called before the first frame update
        public List<QuestBaseNode> PlayerQuestList = new List<QuestBaseNode>();
        public QuestController NPCQuest;
        private void Start()
        {
            acceptTheQuests(NPCQuest);
            FinishQuestAndGetNext(PlayerQuestList[0]);
            FinishQuestAndGetNext(PlayerQuestList[0]);

        }
        public void acceptTheQuests(QuestController NpcQuest)
        {
            QuestBaseNode node = NPCQuest.getFirstQuest();
            InitTheQuest(node);
            PlayerQuestList.Add(node);
        }
        public void InitTheQuest(QuestBaseNode questNode) 
        {
            questNode.SetQuestId(PlayerQuestList.Count);
            questNode.CreateQuestInstance();
        }
        public void FinishQuestAndGetNext(QuestBaseNode questNode)
        {
            QuestBaseNode node = questNode.GetTheNextNode();
            if (node == null)
                //支線已經完成 顯示 支線完成UI
                showSideQuestFinishUI();
            else 
            {
                InitTheQuest(node);
                PlayerQuestList[questNode.QuestId] = node;
            }
                


        }
        public void showSideQuestFinishUI()
        {
            Debug.Log("Finish");
        }
    }
}
