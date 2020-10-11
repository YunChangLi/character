using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
	[NodeCanvasType("DialogFlowCanvas")]
	public class DialogFlowCanvasType : NodeCanvas
	{

		public override string canvasName
		{
			get { return "DialogFlow Canvas"; }
		}
		public StartDialogNode StartState;
		public EndDialogNode EndState;
		private string startDialogID { get { return "startDialog"; } }
		private string endDialogID { get { return "endDialog"; } }

		protected override void OnCreate()
		{
			Traversal = new DialogFlowCanvasTraversal(this);
			StartState = Node.Create(startDialogID, Vector2.zero, this, null, true) as StartDialogNode;
			EndState = Node.Create(endDialogID, Vector2.zero + new Vector2(100, 100), this, null, true) as EndDialogNode;
		}

		public void OnEnable()
		{
			if (Traversal == null)
				Traversal = new DialogFlowCanvasTraversal(this);

		}
		public override bool CanAddNode(string nodeID)
		{
			// 只允許有一個FirstStateNode
			if (nodeID == startDialogID)
				return !nodes.Exists((Node n) => n.GetID == startDialogID);
			else if (nodeID == endDialogID)
				return !nodes.Exists((Node n) => n.GetID == endDialogID);
			return true;
		}
		protected override void ValidateSelf()  //以防有null的參考
		{
			if (Traversal == null)
				Traversal = new DialogFlowCanvasTraversal(this);

		}


	}

}

