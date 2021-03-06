﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

namespace NodeEditorFramework.Standard
{
    [RequireComponent(typeof(RangeDrawer))]
    public class ActionController : MonoBehaviour
    {
        // FSM Canvas
        public StateMachineCanvasType StateMachineCanvas;

        // 狀態機的當前Action
        public ActionNodeBase CurrentActionNode { get; set; }

        // Animator
        public Animator Animator;

        // 怪物資訊
        public MonsterInfo MonsterInfo;

        // 計算移動
        public MonsterController MonsterController;

        public RangeDrawer Drawer;

        public bool ShowCurrentAction = false;

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
                stateNode.MonsterInfo = MonsterInfo;
                stateNode.DoBeforeRunFSM();
            }
            var firstStateNode = nodeList.Find((node) => node.name == "Entry State") as FirstStateNode;
            CurrentActionNode = (ActionNodeBase)firstStateNode.FirstActionNode;
        }

        /// <summary>
        /// 執行當前Action的LifeCycle
        /// </summary>
        /// <returns></returns>
        private IEnumerator UpdateAction()
        {
            while (true)
            {
                if(ShowCurrentAction)
                    Debug.Log(CurrentActionNode.Title);
                // Action初始化
                CurrentActionNode.Init();
                // Decider初始化
                CurrentActionNode.DeciderList.ForEach((decider) => decider.Init());
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