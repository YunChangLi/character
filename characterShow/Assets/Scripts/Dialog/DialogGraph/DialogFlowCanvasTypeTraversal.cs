using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    public class DialogFlowCanvasTraversal : NodeCanvasTraversal
    {
        private DialogFlowCanvasType dialogCanvas;

        public DialogFlowCanvasTraversal(DialogFlowCanvasType canvas) : base(canvas)
        {
            dialogCanvas = canvas;
        }
        public override void TraverseAll()
        {

        }

    }

}
