namespace NodeEditorFramework.Standard
{
    public class StateMachineCanvasTraversal : NodeCanvasTraversal
    {
		StateMachineCanvasType canvasType;

		public StateMachineCanvasTraversal(StateMachineCanvasType canvas) : base(canvas)
		{
			canvasType = canvas;
		}

		/// <summary>
		/// Traverse the canvas and evaluate it
		/// </summary>
		public override void TraverseAll()
		{
			FirstStateNode firstStateNode = canvasType.FirstStateNode;
			firstStateNode.Calculate();
			//Debug.Log ("RootNode is " + rootNode);
		}
	}
}
