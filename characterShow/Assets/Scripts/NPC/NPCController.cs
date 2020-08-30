using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Serializable]
    public struct HandingTask
    {
        public Task UnReceiveTask;   //will give to player
        public Task WillReceiveTask;   //will receive the task from player  
    }
    public HandingTask NPCOwnTask;
    public Vector3 DetectSize;      // the player detected area size
    public bool isGivenTask { get; set; } //NPC是否已經交出任務
    
    /// <summary>
    ///give a Task to the player
    /// </summary>
    public void GiveTask(PlayerController player) 
    {
        Task task = new Task();
        player.PTaskController.AddTask(task);
    }
    public void GiveGroupTask(PlayerController player)
    {
        GroupTask tasks = new GroupTask();
        player.PTaskController.AddTask(tasks);
    }
    /// <summary>
    /// called by player
    /// </summary>
    /// <param name="player"></param>
    public void ChattedWithPlayer(PlayerController player) 
    {
        //catch player
        if (player != null) 
        {
            PlayerController pController = player.GetComponent<PlayerController>();
            
            //GiveTask(player);
        }
    }
    /// <summary>
    /// 有空任務/有已完成任務/皆無(表示任務進行中)
    /// </summary>
    /// <returns></returns>
    private IEnumerator npcChattingProcess() 
    {
        //有空任務沒有被完成() && 預計要接收的任務也沒有完成()
        if (!NPCOwnTask.UnReceiveTask.IsFinished() && ! NPCOwnTask.WillReceiveTask.IsFinished())    
            yield return null;

        
    }
    
}
