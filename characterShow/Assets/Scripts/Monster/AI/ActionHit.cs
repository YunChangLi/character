using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/ActionNode/Hit", typeof(StateMachineCanvasType))]
    public class ActionHit : ActionNodeBase
    {
        // 這個Action用來讓怪物進行撞擊

        public override string GetID { get { return "hitNode"; } }

        public override string ActionName { get { return "Hit"; } }

        public override IEnumerator Process()
        {
            ActionController.Animator.SetTrigger("Attack");
            //DamageAreaCreator.instance.CreateCubeArea()
            yield return null;
        }
    }
}
