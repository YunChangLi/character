using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
	[NodeCanvasType("QuestFlowCanvas")]
    public class QuestFlowCanvasType : NodeCanvas
    {

        public override string canvasName 
        { 
            get { return "QuestFlow Canvas"; } 
        }
		public StartQuestNode StartState;
		public EndQuestNode EndState;
		private string startQuestID { get { return "startQuest"; } }
		private string endQuestID { get { return "endQuest"; } }
		
		protected override void OnCreate()
		{
			Traversal = new QuestFlowCanvasTraversal(this);
			StartState = Node.Create(startQuestID, Vector2.zero, this, null, true) as StartQuestNode;
			EndState = Node.Create(endQuestID, Vector2.zero + new Vector2(100,100), this, null, true) as EndQuestNode;
		}

		public void OnEnable()
		{
			if (Traversal == null)
				Traversal = new QuestFlowCanvasTraversal(this);

		}
		public override bool CanAddNode(string nodeID)
		{
			// 只允許有一個FirstStateNode
			if (nodeID == startQuestID)
				return !nodes.Exists((Node n) => n.GetID == startQuestID);
			else if (nodeID == endQuestID)
				return !nodes.Exists((Node n) => n.GetID == endQuestID);
			return true;
		}
		protected override void ValidateSelf()	//以防有null的參考
		{
			if (Traversal == null)
				Traversal = new QuestFlowCanvasTraversal(this);

		}


	}
	
}

