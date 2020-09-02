﻿using NodeEditorFramework.Utilities;
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

        private GameObject targetObject;

        public override void Init()
        {
            base.Init();
            targetObject = GameObject.FindWithTag("Player");
        }

        public override IEnumerator Process()
        {
            ActionController.Animator.SetTrigger("Attack");
            ActionController.MonsterController.CanMove = false;
            while (RunTime < ThrowDelay)
            {
                ActionController.MonsterController.LookAtTarget = targetObject;
                yield return null;
            }
            ActionController.MonsterController.LookAtTarget = null;
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
        }
    }
}