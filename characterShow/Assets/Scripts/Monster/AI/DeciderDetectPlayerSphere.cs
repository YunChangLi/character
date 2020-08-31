using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;
using System.Reflection.Emit;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/DeciderNode/DetectPlayerSphere", typeof(StateMachineCanvasType))]
    public class DeciderDetectPlayerSphere : DeciderNodeBase
    {
        public override string GetID { get { return "detectPlayerSphereDeciderNode"; } }

        public override string Title { get { return "DetectPlayerSphere"; } }

        public bool IsRangeStable = false;  // 範圍是否會跟著怪物移動

        public Vector3 DetectOffset;    // 偵測範圍位移

        public float DetectRadius;      // 偵測範圍半徑

        public override bool IsShowRange { get { return true; } }

        public override Vector3 GetRangeOffset { get { return DetectOffset; } }

        public override float GetRangeRadius { get { return DetectRadius; } }

        public override RangeDrawer.RangeType RangeType { get { return RangeDrawer.RangeType.Sphere; } }

        private Collider[] playerCollider;
        private Vector3 initRangePos;

        public override void DoBeforeRunFSM()
        {
            base.DoBeforeRunFSM();
            initRangePos = AIObject.transform.position;
        }

        public override void Init()
        {

        }

        public override bool Calculate()
        {
            if (IsRangeStable)
                playerCollider = Physics.OverlapSphere(initRangePos + DetectOffset, DetectRadius, LayerMask.GetMask("Player"));
            else
                playerCollider = Physics.OverlapSphere(AIObject.transform.position + DetectOffset, DetectRadius, LayerMask.GetMask("Player"));

            if (playerCollider.Length > 0)
                return true;

            return false;
        }

        public override void DeciderBody()
        {
            base.DeciderBody();
            IsRangeStable = RTEditorGUI.Toggle(IsRangeStable, new GUIContent("Is Range Stable", "Detect range will follow monster if false"));
            DetectRadius = RTEditorGUI.FloatField(new GUIContent("Detect Radius"), DetectRadius);
            GUILayout.Label("Detect Range Offset");
            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 10;
            DetectOffset.x = RTEditorGUI.FloatField(new GUIContent("x"), DetectOffset.x);
            DetectOffset.y = RTEditorGUI.FloatField(new GUIContent("y"), DetectOffset.y);
            DetectOffset.z = RTEditorGUI.FloatField(new GUIContent("z"), DetectOffset.z);
            EditorGUIUtility.labelWidth = 100;
            EditorGUILayout.EndHorizontal();
        }

    }
}
