using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGoal
{
    
    public int RequiredAmount { get; set; }
    public int CurrentAmount { get; set; }

    public QuestGoal( int requiredAmount)
    {
        this.RequiredAmount = requiredAmount;
    }
    public bool CheckTaskFinished()
    {
        return CurrentAmount >= RequiredAmount;
    }

}
