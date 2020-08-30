using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
    public abstract class ActionNodeBase : StateNodeBase
	{
		public override string Title { get { return StateName; } }

		public override Vector2 MinSize { get { return new Vector2(200, 10); } }

		public override bool AutoLayout { get { return true; } } // IMPORTANT -> Automatically resize to fit list

		// 允許有多個輸入狀態
		[ValueConnectionKnob("Input", Direction.In, "Float", MaxConnectionCount = ConnectionCount.Multi, NodeSide = NodeSide.Left)]
		public ValueConnectionKnob inputLeftKnob;

		[ValueConnectionKnob("Input", Direction.In, "Float", MaxConnectionCount = ConnectionCount.Multi, NodeSide = NodeSide.Right)]
		public ValueConnectionKnob inputRightKnob;

		[ValueConnectionKnob("Output", Direction.Out, "System.String", MaxConnectionCount = ConnectionCount.Multi, NodeSide = NodeSide.Left)]
		public ValueConnectionKnob outputLeftKnob;

		[ValueConnectionKnob("Output", Direction.Out, "System.String", MaxConnectionCount = ConnectionCount.Multi, NodeSide = NodeSide.Right)]
		public ValueConnectionKnob outputRightKnob;

		// 這個狀態的名稱
		public string StateName = "";

		// 已經在這個狀態多久了
		public float RunTime = 0;

		// 行為名稱
		public virtual string ActionName { get; protected set; }

		// 紀錄這個Action連接的所有Decider
		public List<DeciderNodeBase> DeciderList;

		// 是否為執行中的Action
		public bool IsActiveAction = false;

		public AudioClip Clip;
		public float SoundDelay;

        protected override void OnCreate()
        {
			backgroundColor = new Color(1, 0.85f, 0.92f, 1f);
		}

		/// <summary>
		/// 計時器
		/// </summary>
		/// <returns></returns>
		public IEnumerator Timer()
        {
            while (true)
            {
				RunTime += Time.deltaTime;
				yield return null;	
            }
        }

        public override void NodeGUI()
		{
			IsFold = RTEditorGUI.Foldout(IsFold, FoldStatus);
			if (IsFold)
			{
				// State name and input
				GUILayout.BeginVertical();
				StateName = RTEditorGUI.TextField(new GUIContent(" State Name", "The name of this state"), StateName);
				EditorGUIUtility.labelWidth = 100;
				GUILayout.BeginHorizontal();
				inputLeftKnob.DisplayLayout();
				inputRightKnob.DisplayLayout();
				GUILayout.EndHorizontal();
				GUILayout.EndVertical();
				// Action	
				DrawUILine(Color.gray, 4);
				GUILayout.BeginVertical();
				GUILayout.Label("Action Name: " + ActionName);
				ActionBody();
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

			DrawRange();
		}

		/// <summary>
		/// Action初始化
		/// </summary>
		public virtual void Init()
		{
			// 儲存所有Decider
			DeciderList = new List<DeciderNodeBase>();
			outputLeftKnob.connections.ForEach((connection) => DeciderList.Add((DeciderNodeBase)connection.body));
			outputRightKnob.connections.ForEach((connection) => DeciderList.Add((DeciderNodeBase)connection.body));
			// 依照Order排序
			DeciderList.Sort((d1, d2) => d1.Order.CompareTo(d2.Order));
			RunTime = 0;
			IsActiveAction = true;
		}

		/// <summary>
		/// Action執行中
		/// </summary>
		public virtual IEnumerator Process()
		{
			yield return null;
		}

		/// <summary>
		/// Action結束
		/// </summary>
		public virtual void Exit()
		{
			IsActiveAction = false;
		}

		/// <summary>
		/// 子類別實作此函式來製作各自Node的GUI
		/// </summary>
		public virtual void ActionBody()
        {
			Clip = RTEditorGUI.ObjectField("Sound Effect", Clip, false);
			SoundDelay = RTEditorGUI.FloatField(new GUIContent("Sound Delay", "Delay to play sound effect"), SoundDelay);
		}
	}
}
