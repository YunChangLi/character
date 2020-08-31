using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvent 
{
    public enum QuestStatus
    {
        Waiting,
        Current,
        Done
    }
    public NPCController QuestReceiver { get; set; }
    public NPCController QuestSender { get; set; }
    public string TitleName { get; set; }
    public string Description { get; set; }
    public string QuestId { get; set; }
    public QuestStatus status { get; set; }
    public QuestGoal QuestPrcess { get; set; }  //任務目標及任務進展狀況
    public List<QuestPath> pathList = new List<QuestPath>();

    public QuestEvent()
    {
        QuestId = Guid.NewGuid().ToString();
        status = QuestStatus.Waiting;
    }
    public void SetMissionTitle(string title)
    {
        TitleName = title;
    }
    public void SetMissionDescription(string description)
    {
        Description = description;
        Debug.Log(description);
    }
    public void updateQuestEvent(QuestStatus status) 
    {
        if (status == QuestStatus.Done && !QuestPrcess.CheckTaskFinished())
            return;     //保持原來的Status
        this.status = status;
    }
    public string GetID() {
        return QuestId;
    }
}
