using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTaskController : MonoBehaviour
{
    //TaskSystem 由 player掌管(player Task Controller)，任務由NPC派發
    //Task ID 有問題 (完成的任務應該要被剔除list)
    public List<Task> PTaskList;
    private int taskCount = 0;
    public PlayerTaskController() 
    {
        PTaskList = new List<Task>();
    }

    /// <summary>
    /// 玩家是否完成此任務
    /// </summary>
    /// <param name="finishTask"></param>
    public bool IsFinishTask(Task task)
    {
        if (task != null)
        {
            if (task.GetTheCurrentState() == Task.TaskState.Completed)
            {
                return true;
            }
        }
        return false;
    }
    public Task FindTaskInList(int taskID)
    {
        foreach (Task task in PTaskList)
        {
            if (task.TaskID == taskID)
                return task;
        }
        return null;
    }
    public void AddTask(Task task)
    {
        task.TaskID = taskCount; //assign an taskID
        PTaskList.Add(task);
        taskCount++;
    }
}
