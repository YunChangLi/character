using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
	[NodeCanvasType("QuestFlowCanvas")]
    public class QuestFlowCanvasType : NodeCanvas
    {
		public QuestEvent QEvent;
        public override string canvasName 
        { 
            get 
            { 
                return "QuestFlow Canvas"; 
            } 
        }
		protected override void OnCreate()
		{
			Traversal = new QuestFlowCanvasTraversal(this);
			
		}

		public void OnEnable()
		{
			// Register to other callbacks, f.E.:
			//NodeEditorCallbacks.OnDeleteNode += OnDeleteNode;
		}

		protected override void ValidateSelf()
		{
			if (Traversal == null)
				Traversal = new QuestFlowCanvasTraversal(this);
		}

	}
	
}

