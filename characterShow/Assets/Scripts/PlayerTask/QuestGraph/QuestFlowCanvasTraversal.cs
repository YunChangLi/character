using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    public class QuestFlowCanvasTraversal : NodeCanvasTraversal
    {
        private QuestFlowCanvasType questCanvas;

        public QuestFlowCanvasTraversal(QuestFlowCanvasType canvas) : base(canvas) 
        {
            questCanvas = canvas;
        }
        public override void TraverseAll()
        {
          
        }

    }

}
