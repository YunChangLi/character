using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
    public abstract class DeciderNodeBase : StateNodeBase
    {
        public override Vector2 MinSize { get { return new Vector2(200, 10); } }
		
        public override bool AutoLayout { get { return true; } } // IMPORTANT -> Automatically resize to fit list

		// 只允許有一個輸入狀態
		[ValueConnectionKnob("Input", Direction.In, "System.String", MaxConnectionCount = ConnectionCount.Single, NodeSide = NodeSide.Left)]
        public ValueConnectionKnob inputLeftKnob;

		[ValueConnectionKnob("Input", Direction.In, "System.String", MaxConnectionCount = ConnectionCount.Single, NodeSide = NodeSide.Right)]
		public ValueConnectionKnob inputRightKnob;

		[ValueConnectionKnob("Output", Direction.Out, "Float", MaxConnectionCount = ConnectionCount.Single, NodeSide = NodeSide.Left)]
		public ValueConnectionKnob outputLeftKnob;

		[ValueConnectionKnob("Output", Direction.Out, "Float", MaxConnectionCount = ConnectionCount.Single, NodeSide = NodeSide.Right)]
		public ValueConnectionKnob outputRightKnob;

		// 決定回傳True或是False時轉移狀態
		public DeciderType Type;

		// Decider的優先度
		public int Order;

		// 連接這個Decider的下一個ActionNode
		public ActionNodeBase NextNode;

		private bool isLeftInputConnected = false;

		private bool isLeftOutputConnected = false;

		protected override void OnCreate()
		{
			backgroundColor = Color.yellow;
		}

		/// <summary>
		/// 整個FSM運作前的初始化(一次性)
		/// </summary>
		public override void DoBeforeRunFSM()
        {
			// 取得下個Action
			if(outputLeftKnob.connected())
				NextNode = (ActionNodeBase)outputLeftKnob.connections[0].body;
			else
				NextNode = (ActionNodeBase)outputRightKnob.connections[0].body;
		}

		/// <summary>
		/// Runtime每次使用這個Deicder時的初始化(重複)
		/// </summary>
		public virtual void Init()
		{
			
		}

		/// <summary>
		/// 透過此函式來判斷Deicder是否條件達成
		/// </summary>
		/// <returns></returns>
		public bool Decider()
        {
			if (Type == DeciderType.True)
				return Calculate();
			else
				return !Calculate();
        }

        public override void NodeGUI()
		{
			IsFold = RTEditorGUI.Foldout(IsFold, FoldStatus);
			if (IsFold)
			{
				// input
				GUILayout.BeginHorizontal();
				inputLeftKnob.DisplayLayout();
				inputRightKnob.DisplayLayout();
				GUILayout.EndHorizontal();
				// Decider	
				DrawUILine(Color.gray, 4);
				GUILayout.BeginVertical();
				DeciderBody();
				GUILayout.EndVertical();

				// Transition output
				DrawUILine(Color.gray, 4);
				GUILayout.BeginHorizontal();
				outputLeftKnob.DisplayLayout();
				outputRightKnob.DisplayLayout();
				GUILayout.EndHorizontal();
				FoldStatus = "Fold";
			}
            else
            {
				GUILayout.BeginHorizontal();
				inputLeftKnob.SetPosition(10);
				inputRightKnob.SetPosition(10);
				GUILayout.EndHorizontal();
				GUILayout.BeginHorizontal();
				outputLeftKnob.SetPosition(30);
				outputRightKnob.SetPosition(30);
				GUILayout.EndHorizontal();
				FoldStatus = "Expand";
            }

			// 避免一個Decider同時有多個Input或多個Output
			if (inputLeftKnob.connected() && !isLeftInputConnected)
			{
				isLeftInputConnected = true;
				inputRightKnob.ClearConnections();
			}

			if (inputRightKnob.connected() && isLeftInputConnected)
			{
				isLeftInputConnected = false;
				inputLeftKnob.ClearConnections();
			}

			if (outputLeftKnob.connected() && !isLeftOutputConnected)
			{
				isLeftOutputConnected = true;
				
				outputRightKnob.ClearConnections();
			}

			if (outputRightKnob.connected() && isLeftOutputConnected)
			{
				isLeftOutputConnected = false;
				outputLeftKnob.ClearConnections();
			}

			DrawRange();
		}

        // 子類別實作此函式來製作各自Node的GUI
        public virtual void DeciderBody()
		{
			Type = (DeciderType)RTEditorGUI.EnumPopup(new GUIContent("Decider Type", "The type of decider to check"), Type);
			Order = RTEditorGUI.IntField(new GUIContent("Order", "Order of the decider"), Order);
		}
	}
}

public enum DeciderType
{
	True,
	False
}
