using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [Node(false, "State/ActionNode/Idle", typeof(StateMachineCanvasType))]
    public class ActionIdle : ActionNodeBase
    {
        public override string GetID { get { return "idleNode"; } }

        public override string ActionName { get { return "Idle"; } }
    }
}
