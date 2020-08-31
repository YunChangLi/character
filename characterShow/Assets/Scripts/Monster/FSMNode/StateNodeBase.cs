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

		// 範圍類型
		public virtual RangeDrawer.RangeType RangeType { get { return RangeDrawer.RangeType.Box; } }
		// 是否顯示範圍
		public virtual bool IsShowRange { get { return false; } }
		// 範圍位移
		public virtual Vector3 GetRangeOffset { get { return Vector3.zero; } }

		#region 圓球形範圍必須繼承以下參數
		// 範圍半徑
		public virtual float GetRangeRadius { get { return 1f; } }
		#endregion

		#region 方形範圍必須繼承以下參數
		// 範圍大小
		public virtual Vector3 GetRangeSize { get { return Vector3.one; } }
		// 範圍旋轉
		public virtual Quaternion Rot { get { return Quaternion.identity; } }
		#endregion

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
			if (NodeEditor.curEditorState == null)
			{
				Debug.LogError("Null curEditorState");
				return;
			}
			if (NodeEditor.curEditorState.selectedNode == null)
			{
				Debug.Log("Null selectNode");
				return;
			}

			// 繪製範圍
			if (NodeEditor.curEditorState.selectedNode == this)
			{
				foreach(RangeDrawer drawer in FindObjectsOfType<RangeDrawer>())
                {
					if(drawer.GetComponent<ActionController>()?.StateMachineCanvas?.canvasName == NodeEditor.curNodeCanvas.canvasName)
                    {
						// 繪製圓形範圍
						if (RangeType == RangeDrawer.RangeType.Sphere)
						{
							drawer.IsShowRange = IsShowRange;
							drawer.Offset = GetRangeOffset;
							drawer.Radius = GetRangeRadius;
							drawer.DrawRangeType = RangeDrawer.RangeType.Sphere;
						}
						// 繪製矩形範圍
						else if (RangeType == RangeDrawer.RangeType.Box)
						{
							drawer.IsShowRange = IsShowRange;
							drawer.Offset = GetRangeOffset;
							drawer.Size = GetRangeSize;
							drawer.DrawRangeType = RangeDrawer.RangeType.Box;
						}
					}
                }
			}
		}
	}
}
