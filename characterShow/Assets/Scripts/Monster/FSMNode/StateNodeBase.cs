using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NodeEditorFramework.Standard {
    public abstract class StateNodeBase : Node
    {
		// 由ActionController負責給予此物件的參考
		public GameObject AIObject { get; set; }
		// AI邏輯控制器
		public ActionController ActionController { get; set; }
		// 怪物狀態
		public MonsterInfo MonsterInfo { get; set; }
		// 是否摺疊
		public bool IsFold = true;
		// 提示摺疊字串
		public string FoldStatus = "Fold";
		// 是否顯示範圍(需要顯示的Action或Decider需要繼承來覆蓋掉false)
		public virtual bool IsShowRange { get { return false; } }
		// 範圍位移
		public Vector3 RangeOffset;
		// 範圍半徑
		public float RangeRadius;

		/// <summary>
		/// 整個FSM運作前的初始化(一次性)
		/// </summary>
		public virtual void DoBeforeRunFSM()
        {

        }

		/// <summary>
		/// 在GUI中繪製線段
		/// </summary>
		/// <param name="color"></param>
		/// <param name="thickness"></param>
		/// <param name="padding"></param>
		public void DrawUILine(Color color, int thickness = 2, int padding = 10)
		{
			Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
			r.height = thickness;
			r.y += padding / 2;
			r.x -= 2;
			r.width += 6;
			EditorGUI.DrawRect(r, color);
		}

		/// <summary>
		/// 繪製範圍
		/// </summary>
		public void DrawRange()
        {
			if (NodeEditor.curEditorState.selectedNode == null)
				return;

			// 繪製範圍
			if (NodeEditor.curEditorState.selectedNode == this)
			{
				foreach(RangeDrawer drawer in FindObjectsOfType<RangeDrawer>())
                {
					if(drawer.GetComponent<ActionController>()?.StateMachineCanvas?.canvasName == NodeEditor.curNodeCanvas.canvasName)
                    {
						drawer.IsShowRange = IsShowRange;
						drawer.Offset = RangeOffset;
						drawer.Radius = RangeRadius;
					}
                }
			}
		}
	}
}
