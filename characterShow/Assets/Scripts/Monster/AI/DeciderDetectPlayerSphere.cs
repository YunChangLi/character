using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/DeciderNode/DetectPlayerSphere")]
    public class DeciderDetectPlayerSphere : DeciderNodeBase
    {
        public override string GetID { get { return "detectPlayerSphereDeciderNode"; } }

        public override string Title { get { return "DetectPlayerSphere"; } }

        public bool IsRangeStable = false;  // 範圍是否會跟著怪物移動

        public Vector3 DetectCenter = new Vector3(0, 0, 0);

        public float DetectRadius = 1f;

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
                playerCollider = Physics.OverlapSphere(initRangePos + DetectCenter, DetectRadius, LayerMask.GetMask("Player"));
            else
                playerCollider = Physics.OverlapSphere(AIObject.transform.position + DetectCenter, DetectRadius, LayerMask.GetMask("Player"));

            if (playerCollider.Length > 0)
                return true;

            return false;
        }

        public override void DeciderBody()
        {
            base.DeciderBody();
            IsRangeStable = RTEditorGUI.Toggle(IsRangeStable, new GUIContent("Is Range Stable", "Detect range will follow monster if false"));
            DetectRadius = RTEditorGUI.FloatField(new GUIContent("Detect Radius"), DetectRadius);
            
            //EditorGUILayout.BeginHorizontal();
            //DetectCenter.x = RTEditorGUI.FloatField(new GUIContent)
            //EditorGUILayout.EndHorizontal();
        }

    }
}
