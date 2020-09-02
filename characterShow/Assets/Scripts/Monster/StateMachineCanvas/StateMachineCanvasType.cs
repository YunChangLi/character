using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [NodeCanvasType("State Machine Canvas")]
    public class StateMachineCanvasType : NodeCanvas
    {
        public override string canvasName { get { return "StateMachine"; } }

        // 允許圖有迴圈
        public override bool allowRecursion { get { return true; } }

        // 第一個狀態
        public FirstStateNode FirstStateNode;

        private string firstStateNodeID { get { return "firstStateNode"; } }

        public bool HasStartNode = false;

        // 創建新Canvas時呼叫此函式
        protected override void OnCreate()
        {
            Traversal = new StateMachineCanvasTraversal(this);
            FirstStateNode = Node.Create(firstStateNodeID, Vector2.zero, this, null, true) as FirstStateNode;
        }

        private void OnEnable()
        {
            if (Traversal == null)
                Traversal = new StateMachineCanvasTraversal(this);
        }

        protected override void ValidateSelf()
        {
            if (Traversal == null)
                Traversal = new StateMachineCanvasTraversal(this);
            if (FirstStateNode == null && (FirstStateNode = nodes.Find((Node n) => n.GetID == firstStateNodeID) as FirstStateNode) == null)
                FirstStateNode = Node.Create(firstStateNodeID, Vector2.zero, this, null, true) as FirstStateNode;
        }

        public override bool CanAddNode(string nodeID)
        {
            // 只允許有一個FirstStateNode
            if (nodeID == firstStateNodeID)
                return !nodes.Exists((Node n) => n.GetID == firstStateNodeID);
            return true;
        }

        /// <summary>
		/// Handles creation of the group in the editor through a context menu item
		/// </summary>
		[ContextEntryAttribute(ContextType.Canvas, "Expand All")]
        private static void ExpandAllNodes(NodeEditorInputInfo info)
        {
            info.SetAsCurrentEnvironment();
            foreach(Node node in NodeEditor.curNodeCanvas.nodes)
            {
                ((StateNodeBase)node).IsFold = true;
                ((StateNodeBase)node).FoldStatus = "Fold";
            }
        }

        /// <summary>
		/// Handles creation of the group in the editor through a context menu item
		/// </summary>
		[ContextEntryAttribute(ContextType.Canvas, "Fold All")]
        private static void FoldAllNodes(NodeEditorInputInfo info)
        {
            info.SetAsCurrentEnvironment();
            foreach (Node node in NodeEditor.curNodeCanvas.nodes)
            {
                ((StateNodeBase)node).IsFold = false;
                ((StateNodeBase)node).FoldStatus = "Expand";
            }
        }

        [ContextEntryAttribute(ContextType.Node, "ClearLink/LeftInput")]
        private static void ClearLeftInputConnect(NodeEditorInputInfo info)
        {
            info.SetAsCurrentEnvironment();
            info.editorState.focusedNode.connectionKnobs[0].ClearConnections();
        }

        [ContextEntryAttribute(ContextType.Node, "ClearLink/RightInput")]
        private static void ClearRightInputConnect(NodeEditorInputInfo info)
        {
            info.SetAsCurrentEnvironment();
            info.editorState.focusedNode.connectionKnobs[1].ClearConnections();
        }

        [ContextEntryAttribute(ContextType.Node, "ClearLink/LeftOutput")]
        private static void ClearLeftOutputConnect(NodeEditorInputInfo info)
        {
            info.SetAsCurrentEnvironment();
            info.editorState.focusedNode.connectionKnobs[2].ClearConnections();
        }

        [ContextEntryAttribute(ContextType.Node, "ClearLink/RightOutput")]
        private static void ClearRightOutputConnect(NodeEditorInputInfo info)
        {
            info.SetAsCurrentEnvironment();
            info.editorState.focusedNode.connectionKnobs[3].ClearConnections();
        }
    }
}
