﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// control the NPC Story (like quest story(End or Finish))
/// </summary>
namespace NodeEditorFramework.Standard 
{
    /// <summary>
    /// 任務的處理與觸發
    /// </summary>
    public class NPCController : MonoBehaviour
    {
        [Serializable]
        public struct HandingTask
        {
            public Task SendTask;   //will give to player
            public Task ReceiveTask;   //will receive the task from player  
        }

        public Vector3 DetectSize;      // the player detected area size
        public bool isGivenTask { get; set; } //NPC是否已經交出任務
        public bool isMeetingPlayer { get; set; } //用來讓NPC知道是否遇到Player



        /// <summary>
        /// Init the Quest....
        /// </summary>
        public void NPCControllerInit() 
        {
            
        }

        public void GiveGroupTask(PlayerController player)
        {
            GroupTask tasks = new GroupTask();
            //player.PTaskController.AddTask(tasks);
        }
        /// <summary>
        /// called by player
        /// </summary>
        /// <param name="player"></param>
        public GameObject catchPlayer(Vector3 center, float radius)
        {
            //catch player
            //hitCollider為撞進Sphere的GameObject
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);//get gameObject
            if (hitColliders.Length <= 0)
                return null;
            else 
            {
                foreach (var hitCollider in hitColliders) 
                {
                    if(hitCollider.gameObject.GetComponent<PlayerQuestController>()) //唯有player可以進入
                        return hitCollider.gameObject;

                }
                    

                return null;
            }


        }
        /// <summary>
        /// 有空任務/空任務被接收
        /// </summary>
        /// <returns></returns>
        /*private IEnumerator npcChattingProcessForUR(PlayerTaskController player) 
        {
            //尋找派送任務是否有在玩家的任務清單
            Task sendedTask = player.FindTaskInList(NPCOwnTask.SendTask.TaskID);

            if (sendedTask == null)    //空任務未被接收(第一次與player接觸)
                yield return null;
            //StartCoroutine(NPCSpeeking(sendedTask));

            else if (sendedTask.IsFinished()) //發送出去的任務被完成
            {  
                //換下一個派送任務
                yield return null;
            }
            else if (sendedTask.GetTheCurrentState() == Task.TaskState.Receiving) //發送出去的任務未被完成
                yield return null;



        }
        /// <summary>
        /// 有代為接收的任務
        /// </summary>
        /// <returns></returns>
        private IEnumerator npcChattingProcessForWR(PlayerTaskController player)
        {
            //尋找接收任務是否有在玩家的任務清單
            Task recievedTask = player.FindTaskInList(NPCOwnTask.ReceiveTask.TaskID);

            if (recievedTask == null)    //沒有接收任務 (沒有開啟支線)
                yield return null;

            else if (recievedTask.IsFinished()) //要接收的任務被完成
            {
                //換下一個接收任務
                yield return null;
            }
            else if (recievedTask.GetTheCurrentState() == Task.TaskState.Receiving) //要接收的任務未被完成
                yield return null;

        }*/

        private IEnumerator NPCSpeeking(String speechContent)
        {
            //導入 GameUIManager speech UI
            //int curPos = 0;  //記錄這一行到哪裡

            //int index = 0; //記錄到哪一行

            /* while (isActive)
             {
                 this.transform.GetChild(3).GetComponent<Text>().text = "";
                 this.transform.GetChild(2).GetComponent<Text>().text = dialog[index].Substring(0, curPos);//刷新文本显示内容
                 curPos++;
                 if (curPos >= dialog[index].Length)
                 {
                     if (index + 1 == dialog.Count)
                     {
                         this.transform.GetChild(3).GetComponent<Text>().text = "按下Z鍵";
                         yield return new WaitUntil(() => Input.GetKey(KeyCode.Z));
                         isActive = false;
                     }
                     else
                     {
                         this.transform.GetChild(3).GetComponent<Text>().text = "按下Z鍵";
                         yield return new WaitUntil(() => Input.GetKey(KeyCode.Z));
                         curPos = 0;
                         index += 1;
                     }
                 }
                 yield return new WaitForSeconds(textSpeed);


             }*/
            yield return null;
        }

    }
}

