using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeEditorFramework.Utilities;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/ActionNode/Hit", typeof(StateMachineCanvasType))]
    public class ActionHit : ActionNodeBase
    {
        // 這個Action用來讓怪物進行撞擊

        public override string GetID { get { return "hitNode"; } }

        public override string ActionName { get { return "Hit"; } }

        public Vector3 AttackRangeOffset;    // 攻擊範圍位移

        public Vector3 AttackRangeSize;     // 攻擊範圍大小

        public float DamageAreaKeepTime;    // 傷害區域出現時間

        public float Damage;                // 傷害量

        public override bool IsShowRange { get { return true; } }

        public override Vector3 GetRangeOffset { get { return AttackRangeOffset; } }

        public override Vector3 GetRangeSize{ get { return AttackRangeSize; } }

        public override RangeDrawer.RangeType RangeType { get { return RangeDrawer.RangeType.Box; } }

        public override IEnumerator Process()
        {
            ActionController.Animator.SetTrigger("Attack");
            ActionController.MonsterController.CanMove = false;
            Vector3 newOffset = Quaternion.AngleAxis(AIObject.transform.rotation.eulerAngles.y, Vector3.up) * AttackRangeOffset;
            DamageAreaCreator.instance.CreateCubeArea(AIObject.transform.position + newOffset, AIObject.transform.rotation, AttackRangeSize, 5, DamageAreaKeepTime);
            yield return null;
        }

        public override void Exit()
        {
            base.Exit();
            ActionController.MonsterController.CanMove = true;
        }

        public override void ActionBody()
        {
            base.ActionBody();
            GUILayout.Label("Attack Range Size");
            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 10;
            AttackRangeSize.x = RTEditorGUI.FloatField(new GUIContent("x"), AttackRangeSize.x);
            AttackRangeSize.y = RTEditorGUI.FloatField(new GUIContent("y"), AttackRangeSize.y);
            AttackRangeSize.z = RTEditorGUI.FloatField(new GUIContent("z"), AttackRangeSize.z);
            EditorGUILayout.EndHorizontal();

            GUILayout.Label("Attack Range Offset");
            EditorGUILayout.BeginHorizontal();
            AttackRangeOffset.x = RTEditorGUI.FloatField(new GUIContent("x"), AttackRangeOffset.x);
            AttackRangeOffset.y = RTEditorGUI.FloatField(new GUIContent("y"), AttackRangeOffset.y);
            AttackRangeOffset.z = RTEditorGUI.FloatField(new GUIContent("z"), AttackRangeOffset.z);
            EditorGUIUtility.labelWidth = 100;
            EditorGUILayout.EndHorizontal();

            DamageAreaKeepTime = RTEditorGUI.FloatField(new GUIContent("Area Keep Time", "Keep time for damage area"), DamageAreaKeepTime);
            Damage = RTEditorGUI.FloatField(new GUIContent("Damage", "Damage of attack"), Damage);
        }
    }
}
