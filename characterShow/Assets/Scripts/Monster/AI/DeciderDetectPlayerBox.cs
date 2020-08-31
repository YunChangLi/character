using NodeEditorFramework.Utilities;
using UnityEngine;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/DeciderNode/DetectPlayerBox", typeof(StateMachineCanvasType))]
    public class DeciderDetectPlayerBox : DeciderNodeBase
    {
        public override string GetID { get { return "detectPlayerBoxDeciderNode"; } }

        public override string Title { get { return "DetectPlayerBox"; } }

        public bool IsRangeStable = false;  // 範圍是否會跟著怪物移動

        public Vector3 DetectOffset;    // 偵測範圍位移

        public Vector3 DetectSize;      // 偵測範圍大小

        public override bool IsShowRange { get { return true; } }

        public override Vector3 GetRangeOffset { get { return DetectOffset; } }

        public override Vector3 GetRangeSize { get { return DetectSize; } }

        private Collider[] playerCollider;
        private Vector3 initRangePos;
        private Quaternion initRangeRot;

        public override void DoBeforeRunFSM()
        {
            base.DoBeforeRunFSM();
            initRangePos = AIObject.transform.position;
            initRangeRot = AIObject.transform.rotation;
        }

        public override void Init()
        {

        }

        public override bool Calculate()
        {
            if (IsRangeStable)
            {
                Vector3 newCenter = Quaternion.AngleAxis(initRangeRot.eulerAngles.y, Vector3.up) * DetectOffset;
                playerCollider = Physics.OverlapBox(initRangePos + newCenter, DetectSize * 0.5f, initRangeRot, LayerMask.GetMask("Player"));
            }
            else
            {
                Vector3 newCenter = Quaternion.AngleAxis(AIObject.transform.rotation.eulerAngles.y, Vector3.up) * DetectOffset;
                playerCollider = Physics.OverlapBox(AIObject.transform.position + newCenter, DetectSize * 0.5f, AIObject.transform.rotation, LayerMask.GetMask("Player"));
            }

            if (playerCollider.Length > 0)
                return true;

            return false;
        }

        public override void DeciderBody()
        {
            base.DeciderBody();
            IsRangeStable = RTEditorGUI.Toggle(IsRangeStable, new GUIContent("Is Range Stable", "Detect range will follow monster if false"));
            GUILayout.Label("Detect Range Size");
            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 10;
            DetectSize.x = RTEditorGUI.FloatField(new GUIContent("x"), DetectSize.x);
            DetectSize.y = RTEditorGUI.FloatField(new GUIContent("y"), DetectSize.y);
            DetectSize.z = RTEditorGUI.FloatField(new GUIContent("z"), DetectSize.z);
            EditorGUILayout.EndHorizontal();

            GUILayout.Label("Detect Range Offset");
            EditorGUILayout.BeginHorizontal();
            DetectOffset.x = RTEditorGUI.FloatField(new GUIContent("x"), DetectOffset.x);
            DetectOffset.y = RTEditorGUI.FloatField(new GUIContent("y"), DetectOffset.y);
            DetectOffset.z = RTEditorGUI.FloatField(new GUIContent("z"), DetectOffset.z);
            EditorGUIUtility.labelWidth = 100;
            EditorGUILayout.EndHorizontal();
        }
    }
}
