using NodeEditorFramework.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/ActionNode/FacePlayer", typeof(StateMachineCanvasType))]
    public class ActionFacePlayer : ActionNodeBase
    {
        public override string GetID { get { return "facePlayerNode"; } }

        public override string ActionName { get { return "FacePlayer"; } }

        private GameObject targetObject;

        public override void Init()
        {
            base.Init();
            targetObject = GameObject.FindWithTag("Player");
        }

        public override IEnumerator Process()
        {
            ActionController.MonsterController.CanMove = false;
            ActionController.MonsterController.LookAtTarget = targetObject;
            yield return null;
        }

        public override void Exit()
        {
            base.Exit();
            ActionController.MonsterController.LookAtTarget = null;
            ActionController.MonsterController.CanMove = true;
        }
    }
}
