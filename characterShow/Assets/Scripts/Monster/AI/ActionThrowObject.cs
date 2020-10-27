using NodeEditorFramework.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/ActionNode/ThrowObject", typeof(StateMachineCanvasType))]
    public class ActionThrowObject : ActionNodeBase
    {
        public override string GetID { get { return "throwObjectNode"; } }

        public override string ActionName { get { return "ThrowObject"; } }

        public override bool IsShowRange { get { return true; } }

        public override RangeDrawer.RangeType RangeType => RangeDrawer.RangeType.Sphere;

        public override Vector3 GetRangeOffset => ThrowPosOffset;

        public override float GetRangeRadius => 0.5f;

        // 投擲位置位移
        public Vector3 ThrowPosOffset;

        // 投擲延遲時間
        public float ThrowDelay;

        // 投擲物
        public GameObject ThrowObject;

        // 傷害
        public float Damage;

        private GameObject targetObject;

        public override void Init()
        {
            base.Init();
            targetObject = GameObject.FindWithTag("Player");
        }

        public override IEnumerator Process()
        {
            ActionController.Animator.SetTrigger("Throw");
            ActionController.MonsterController.CanMove = false;
            ActionController.MonsterController.LookAtTarget = targetObject;
            // 投擲前會持續面向玩家
            while (RunTime < ThrowDelay)
            {
                yield return null;
            }
            ActionController.MonsterController.LookAtTarget = null;

            // 計算新的發射點
            Vector3 newOffset = Quaternion.AngleAxis(AIObject.transform.rotation.eulerAngles.y, Vector3.up) * ThrowPosOffset;
            // 生成投射物
            GameObject rock = Instantiate(ThrowObject, AIObject.transform.position + newOffset, Quaternion.identity);
            var skillObject = rock.GetComponent<Projectile>();
            skillObject.TargetPos = targetObject.transform.position + Vector3.up;   // 設定目標
            skillObject.Damage = Damage;                                            // 設定傷害
            skillObject.Shoot();                                                    // 發射
        }

        public override void Exit()
        {
            base.Exit();
            ActionController.MonsterController.CanMove = true;
        }

        public override void ActionBody()
        {
            base.ActionBody();
            GUILayout.Label("Throw Position Offset");
            EditorGUILayout.BeginHorizontal();
            EditorGUIUtility.labelWidth = 10;
            ThrowPosOffset.x = RTEditorGUI.FloatField(new GUIContent("x"), ThrowPosOffset.x);
            ThrowPosOffset.y = RTEditorGUI.FloatField(new GUIContent("y"), ThrowPosOffset.y);
            ThrowPosOffset.z = RTEditorGUI.FloatField(new GUIContent("z"), ThrowPosOffset.z);
            EditorGUIUtility.labelWidth = 100;
            EditorGUILayout.EndHorizontal();
            ThrowDelay = RTEditorGUI.FloatField(new GUIContent("Throw Delay", "Delay before throw object"), ThrowDelay);
            ThrowObject = RTEditorGUI.ObjectField(new GUIContent("Throw Object", "Object to throw"), ThrowObject, false);
            Damage = RTEditorGUI.FloatField(new GUIContent("Damage", "Damage of the projectile"), Damage);
        }
    }
}
