using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/DeciderNode/WaitTime")]
    public class DeciderWaitTime : DeciderNodeBase
    {
        public override string GetID { get { return "waitTimeDeciderNode"; } }

        public override string Title { get { return "WaitTime"; } }

        public float WaitTime;      // 等待時間

        private float currentTime = 0;

        public override void Init()
        {
            
        }

        public override bool Calculate()
        {
            return ActionController.CurrentActionNode.RunTime >= WaitTime;
        }

        public override void DeciderBody()
        {
            base.DeciderBody();
            WaitTime = RTEditorGUI.FloatField(new GUIContent("Wait Time"), WaitTime);
        }
    }
}
