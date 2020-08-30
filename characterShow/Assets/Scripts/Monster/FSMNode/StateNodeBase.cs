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
	}
}
