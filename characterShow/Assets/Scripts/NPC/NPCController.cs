using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private TaskSystem taskSystem;
    //use ChattedWithPlayer function catch the player
    private PlayerBase player;
    /// <summary>
    /// wait for the player
    /// </summary>
    private void Update()
    {
        ChattedWithPlayer();
    }
    /// <summary>
    ///give a Task to the player
    /// </summary>
    public void GiveTask() 
    {
        TaskSystem.Task task = new TaskSystem.Task();
        taskSystem.AddTask(task);
    }
    public void GiveGroupTask()
    {
        TaskSystem.GroupTask tasks = new TaskSystem.GroupTask();
        taskSystem.AddTask(tasks);
    }
    public void ChattedWithPlayer() 
    {
        
        //catch player
        if (player != null)
        {
            /*if (player.task.FinishNPC == this)
            { 
                taskFinish
            }*/
            GiveTask();
        }
    }
    
    
}
