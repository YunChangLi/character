using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoal
{
    
    public int RequiredAmount { get; set; }
    public int CurrentAmount { get; set; }
    public QuestGoal()
    {

    }
    public QuestGoal( int requiredAmount)
    {
        this.RequiredAmount = requiredAmount;
    }

    public virtual bool CheckTaskFinished()
    {
        return CurrentAmount >= RequiredAmount;
    }

}
