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

        private Transform playerTransform;

        public override void DoBeforeRunFSM()
        {
            playerTransform = GameObject.FindWithTag("Player").transform;
        }

        public override IEnumerator Process()
        {
            while (true)
            {
                Vector3 movDir = new Vector3(playerTransform.position.x - AIObject.transform.position.x, 0, playerTransform.position.z - AIObject.transform.position.z);
                ActionController.MonsterController.MoveDir = movDir.normalized;
                yield return null;
            }
        }

        public override void Exit()
        {
            base.Exit();
            //target = null;
            //animator.SetBool("Walk", false);
        }
    }
}
