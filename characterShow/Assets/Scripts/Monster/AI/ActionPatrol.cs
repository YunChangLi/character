using NodeEditorFramework.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/ActionNode/Patrol")]
    public class ActionPatrol : ActionNodeBase
    {
        // 這個Action用來讓怪物在活動領域內巡邏

        public override string GetID { get { return "patrolNode"; } }

        public override string ActionName { get { return "Patrol"; } }

        // 巡邏範圍半徑
        public float PatrolRadius;

        private Vector3 initPos;
        private Vector3 targetPos;

        public override void Init()
        {
            base.Init();
            initPos = AIObject.transform.position;
        }

        public override IEnumerator Process()
        {
            yield return new WaitUntil(() => MonsterInfo.IsGrounded);
            while (true)
            {
                float rad = (float)UnityEngine.Random.Range(0, 360) / 180f * 3.14f;
                targetPos = initPos + new Vector3((float)(PatrolRadius * Math.Cos(rad)), 0, (float)(PatrolRadius * Math.Sin(rad)));
                Vector3 movDir = new Vector3(targetPos.x - AIObject.transform.position.x, 0, targetPos.z - AIObject.transform.position.z);
                ActionController.MonsterController.MoveDir = movDir.normalized;
                yield return new WaitUntil(ReachTarget);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void NodeGUI()
        {
            base.NodeGUI();
        }

        public override void ActionBody()
        {
            PatrolRadius = RTEditorGUI.FloatField(new GUIContent("Patrol Radius", "Radius of patrol range with center at spawn position"), PatrolRadius);
            base.ActionBody();
        }

        /// <summary>
        /// 判斷是否移動到目的地
        /// </summary>
        /// <returns></returns>
        private bool ReachTarget()
        {
            return Mathf.Abs(AIObject.transform.position.x - targetPos.x) < 0.1f
                && Mathf.Abs(AIObject.transform.position.z - targetPos.z) < 0.1f;
        }
    }
}
