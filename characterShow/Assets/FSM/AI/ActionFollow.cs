using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/ActionNode/Follow")]
    public class ActionFollow : ActionNodeBase
    {
        public override string GetID { get { return "followNode"; } }

        public override string ActionName { get { return "Follow"; } }

        private GameObject target;
        private NavMeshAgent agent;

        public override void Init()
        {
            base.Init();
            //animator.SetBool("Walk", true);

            //target = GameObject.FindWithTag("Player");
            //agent = AIObject.GetComponent<NavMeshAgent>();
            //agent.enabled = true;
        }

        public override IEnumerator Process()
        {
            base.Process();
            //FollowPlayer();
            AIObject.transform.position += Vector3.left * Time.deltaTime;
            yield return null;
        }

        public override void Exit()
        {
            base.Exit();
            //target = null;
            //animator.SetBool("Walk", false);
        }

        /// <summary>
        /// 跟隨玩家
        /// </summary>
        private void FollowPlayer()
        {
            if (target == null)
                return;

            agent.SetDestination(target.transform.position);
        }
    }
}
