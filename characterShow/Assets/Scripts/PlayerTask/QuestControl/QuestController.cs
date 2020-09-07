using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    public class QuestController : MonoBehaviour
    {
        public QuestFlowCanvasType QuestFlowCanvas;
        private List<Node> nodeList = new List<Node>();

        private void Awake()
        {
            InitTheQuest();
        }

        public QuestBaseNode getFirstQuest()
        {
            nodeList = QuestFlowCanvas.nodes;
            StartQuestNode startNode = nodeList.Find((node) => node.GetID == "startQuest") as StartQuestNode;
            QuestBaseNode questNode = (QuestBaseNode)startNode.StartFlowPort.connections[0].body; 
            
            return questNode;
        }
        public void InitTheQuest()
        {
            
            foreach (Node node in nodeList)
            {
                node.Calculate();   //Init the outKnob value set all false
            }
        }
    }
}

