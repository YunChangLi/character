using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    public class QuestController : MonoBehaviour
    {
        public QuestFlowCanvasType QuestFlowCanvas;
        public string QuestFlowID;  //核對玩家是否已接受此任務串
        private List<Node> nodeList = new List<Node>();

        private void Awake()
        {
            InitTheQuest();
        }

        public QuestBaseNode getFirstQuest()
        {
            
            StartQuestNode startNode = nodeList.Find((node) => node.GetID == "startQuest") as StartQuestNode;
            QuestBaseNode questNode = (QuestBaseNode)startNode.StartFlowPort.connections[0].body;

            return questNode;
        }
        public void InitTheQuest()
        {
            nodeList = QuestFlowCanvas.nodes;
            QuestFlowID = Guid.NewGuid().ToString();
            foreach (Node node in nodeList)
            {
                //Init the outKnob value set all false (isFinish == false)
                //setTheQuestID
                node.Calculate();

            }
        }
    }
}

