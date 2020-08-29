using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    public class ActionController : MonoBehaviour
    {
        // FSM Canvas
        public StateMachineCanvasType StateMachineCanvas;

        [HideInInspector]
        // 狀態機的當前Action
        public ActionNodeBase CurrentActionNode;

        // Animator
        public Animator Animator;

        // 怪物資訊
        public MonsterInfo MonsterInfo;

        // 計算移動
        public MonsterController MonsterController;

        // 第一個符合條件的Decider
        private DeciderNodeBase targetDecider;
        
        // 儲存所有Node
        private List<Node> nodeList;

        private IEnumerator timer;

        private IEnumerator process;

        private void Start()
        {
            NodeEditor.checkInit(false);
            StateMachineCanvas.Validate();
            // 初始化MonsterController
            MonsterController.Init();
            InitNodes();
            StartCoroutine(UpdateAction());
        }

        private void FixedUpdate()
        {
            // 持續計算移動量
            MonsterController.UpdateCalculation();
        }

        /// <summary>
        /// 初始化所有Node的資料
        /// </summary>
        private void InitNodes()
        {
            nodeList = StateMachineCanvas.nodes;
            foreach (Node node in nodeList)
            {
                StateNodeBase stateNode = (StateNodeBase)node;
                stateNode.AIObject = gameObject;
                stateNode.ActionController = this;
                //stateNode.MovementController = StateInfo.MovementController;
                stateNode.DoBeforeRunFSM();
            }
            CurrentActionNode = (ActionNodeBase)StateMachineCanvas.FirstStateNode.FirstActionNode;
        }

        /// <summary>
        /// 執行當前Action的LifeCycle
        /// </summary>
        /// <returns></returns>
        private IEnumerator UpdateAction()
        {
            while (true)
            {
                Debug.Log(CurrentActionNode.Title);
                // Action初始化
                CurrentActionNode.Init();
                // 計時器
                timer = CurrentActionNode.Timer();
                // Action具體過程
                process = CurrentActionNode.Process();
                StartCoroutine(timer);
                StartCoroutine(process);
                // 等待有某個Decider符合條件
                yield return new WaitUntil(() => ReadyToChangeState());
                CurrentActionNode.Exit();
                StopCoroutine(process);
                StopCoroutine(timer);
                CurrentActionNode = targetDecider.NextNode;
            }
        }

        // 是否準備好換狀態
        private bool ReadyToChangeState()
        {
            foreach (DeciderNodeBase decider in CurrentActionNode.DeciderList)
            {
                if (decider.Decider())
                {
                    targetDecider = decider;
                    return true;
                }
            }
            return false;
        }
    }
}