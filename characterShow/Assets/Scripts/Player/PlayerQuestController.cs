using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Standard;
using System;
using UnityEngine.Assertions.Must;

namespace NodeEditorFramework.Standard
{
    public class PlayerQuestController : MonoBehaviour
    {
        // store the quest(支線(內含多個任務))
        public List<QuestBaseNode> PlayerQuestSetList = new List<QuestBaseNode>();
        public QuestController NPCQuest1;
        public QuestController NPCQuest2;
        private void Start()
        {
            acceptTheQuests(NPCQuest1);
            acceptTheQuests(NPCQuest2);
            FinishQuestAndGetNext(PlayerQuestSetList[0]);
            FinishQuestAndGetNext(PlayerQuestSetList[0]);

            foreach (QuestBaseNode node in PlayerQuestSetList)
            {
                Debug.Log(node.TitleName + " "+node.QuestId+" "+node.PlayerListID);
            }
            

        }

        /// <summary>
        /// check the side quest when gathering or killing
        /// </summary>
        /// <returns></returns>
        public QuestBaseNode searchingFinishSideQuest() 
        {
            foreach (QuestBaseNode node in PlayerQuestSetList) 
            {
                if (node.goalSetting.CheckTaskFinished())
                    return node;
            }
            return null;
        }
        public bool searchingEqualQuestSet(QuestController questSet)
        {
            foreach (QuestBaseNode node in PlayerQuestSetList)
            {
                if (node.ParentID == questSet.QuestFlowID)
                    return true;
            }
            return false;
        }
        public void acceptTheQuests(QuestController NpcQuest)
        {
            QuestBaseNode node = NpcQuest.getFirstQuest();
            initQuestNode(PlayerQuestSetList.Count, NpcQuest.QuestFlowID, node);
            PlayerQuestSetList.Add(node);

        }
        private void initQuestNode(int ListID , string parentID , QuestBaseNode node) 
        {
            node.SetPlayerListID(ListID);
            node.setParentID(parentID);
            node.CreateQuestInstance();
        }
        /// <summary>
        /// when a quest set finish, System will remove the quest set in playerQuestList,
        /// and reset the playerListID in each questBaseNode
        /// </summary>
        private void removeTheQuestSetInList(int index) 
        {
            PlayerQuestSetList.RemoveAt(index);
            for (int i = 0; i < PlayerQuestSetList.Count; i++)
            {
                PlayerQuestSetList[i].SetPlayerListID(i);
            }
        }
        /// <summary>
        /// give the accept quest ID and instantiate
        /// </summary>
        /// <param name="questNode"></param>
        public void FinishQuestAndGetNext(QuestBaseNode questNode)
        {
            QuestBaseNode node = questNode.GetTheNextNode();
            if (node == null) 
            {
                //支線已經完成 顯示 支線完成UI
                showSideQuestFinishUI();
                removeTheQuestSetInList(questNode.PlayerListID);
            }
            else 
            {
                initQuestNode(questNode.PlayerListID, questNode.ParentID, node);
                PlayerQuestSetList[questNode.PlayerListID] = node;
            }
                


        }
        public void showSideQuestFinishUI()
        {
            Debug.Log("Finish");
        }

    }
}
