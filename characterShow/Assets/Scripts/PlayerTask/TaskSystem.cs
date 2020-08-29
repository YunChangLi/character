using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TaskSystem
{
    //TaskSystem 由 player掌管(player Task Controller)，任務由NPC派發

    /// <summary>
    /// the Task Item
    /// </summary>
    [Serializable]
    public class Task 
    {
        public int TaskID { get; set; }
        public Text TaskContent;
        public NPCController TaskFinishNPC;
    }
    /// <summary>
    /// NPC 可能不只給一個Task 
    /// </summary>
    public class GroupTask : Task
    {
        public List<Task> SubTaskList = new List<Task>();
    }
    //任務清單
    private List<Task> taskList;

    public TaskSystem() 
    {
        taskList = new List<Task>();
    }
    //player requesting a task
    public void FinishTask(Task finishTask) 
    {
        if (taskList.Count > 0)
        {

            for (int i = 0; i < taskList.Count; i++)
            {
                if (finishTask.TaskID == taskList[i].TaskID)
                    taskList.RemoveAt(i);
            }

        }
    }
    public void AddTask(Task task)
    {
        taskList.Add(task);
    }
}
