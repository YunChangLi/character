using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// the Task Item
/// </summary>
public class Task : MonoBehaviour, ITask
{
    public enum TaskState
    {
        UnReceived,
        Receiving,
        Completed

    }
    public int TaskID { get; set; } = -1;                   //用來記錄與查找 (等於taskList Number)
    public string TaskName;                                 //Task名稱
    //public TaskGoal MTaskGoal { get; set; }                 //任務目標及進度追蹤        


    protected TaskState taskState = TaskState.UnReceived;    //init the State
    
    /// <summary>
    /// 設定是否完成
    /// </summary>
    /// <returns></returns>
    public bool IsFinished()
    {
        /*if (MTaskGoal.CheckTaskFinished())
            this.taskState = TaskState.Completed;

        return this.taskState == TaskState.Completed;*/
        return false;
    }

    /// <summary>
    /// 改變狀態 (主要是將任務設為已完成)
    /// </summary>
    /// <param name="state"></param>
    public void ChangeTaskState(TaskState state) 
    {
        this.taskState = state;
    }
    /// <summary>
    /// 外部call取得狀態
    /// </summary>
    /// <returns></returns>
    public TaskState GetTheCurrentState()
    {
        return taskState;
    }

}
