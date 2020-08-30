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
        UnReceive,
        Receiving,
        Completed

    }
    public int TaskID { get; set; } = -1;                   //用來記錄與查找 (等於taskList Number)
    public string TaskName;                                 //Task名稱
    public Text TaskContent;                                //Task內容 (掛於NPC中)
    public NPCController TaskGivenNPC { get; set; }
    public NPCController TaskFinishNPC { get; set; }            //接收完成任務的NPC
    public Item target;                                     //任務目標

    protected TaskState taskState = TaskState.UnReceive;    //init the State
    
    /// <summary>
    /// 設定是否完成
    /// </summary>
    /// <returns></returns>
    public bool IsFinished()
    {
        return this.taskState == TaskState.Completed;
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
