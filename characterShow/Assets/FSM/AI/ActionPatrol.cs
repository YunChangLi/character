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

        public override void DoBeforeRunFSM()
        {
            initPos = AIObject.transform.position;
        }

        public override void Init()
        {
            base.Init();
        }

        public override IEnumerator Process()
        {
            //yield return new WaitUntil(() => monsterInfo.isGrounded);
            while (true)
            {
                float rad = (float)UnityEngine.Random.Range(0, 360) / 180f * 3.14f;
                Vector3 targetPos = initPos + new Vector3((float)(PatrolRadius * Math.Cos(rad)), 0, (float)(PatrolRadius * Math.Sin(rad)));
                Vector3 movDir = new Vector3(targetPos.x - AIObject.transform.position.x, 0, targetPos.z - AIObject.transform.position.z);
                while(AIObject.transform.position.x != targetPos.x || AIObject.transform.position.z != targetPos.z)
                {
                    MovementController.CharacterController.Move(movDir.normalized * Time.deltaTime * ActionController.StateInfo.MoveSpeed);
                    yield return null;
                }
                yield return null;
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
        /// 初始化
        /// </summary>
        /*public override void Init()
        {
            //initPos = transform.position;
            startMove = false;
            StartCoroutine(Calculate());
        }

        /// <summary>
        /// 計算移動位置
        /// </summary>
        /// <returns></returns>
        public IEnumerator Calculate()
        {
            // 等待怪物著地後才開始移動
            yield return new WaitUntil(() => monsterInfo.isGrounded);
            while (true)
            {
                float theta = Random.Range(0f, 1f) * 2 * Mathf.PI;
                float len = Random.Range(monsterInfo.FieldRadius * 0.2f, monsterInfo.FieldRadius);
                //centerX + len * cos(theta), centerZ + len * sin(theta)
                targetPos = new Vector3(monsterInfo.FieldCenter.x + len * Mathf.Cos(theta), transform.position.y, monsterInfo.FieldCenter.z + len * Mathf.Sin(theta));
                startMove = true;
                animator.SetBool("Walk", true);
                reCalculate = false;
                yield return CheckArrive();
                if (!reCalculate)
                {
                    startMove = false;
                    animator.SetBool("Walk", false);
                    yield return new WaitForSeconds(2);
                }
            }
        }

        public override void Process()
        {
            if (startMove)
                Move();
        }

        /// <summary>
        /// 巡邏移動
        /// </summary>
        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, monsterInfo.MoveSpeed * Time.deltaTime);
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetPos - transform.position, monsterInfo.RotateSpeed * Time.deltaTime, 0.0f);
            newDirection.y = 0;
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        public override void Exit()
        {
            animator.SetBool("Walk", false);
            StopCoroutine(Calculate());
        }

        /// <summary>
        /// 檢查是否抵達目的地或者中途與其他怪物碰撞
        /// </summary>
        /// <returns></returns>
        private IEnumerator CheckArrive()
        {
            while (Vector3.Distance(transform.position, targetPos) >= 0.5f)
            {
                if (monsterInfo.isCollideMonster)
                {
                    reCalculate = true;
                    yield break;
                }
                yield return null;
            }
        }*/
    }
}
