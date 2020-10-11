using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringGoal : QuestGoal
{
    public Item TaskItem { get; set; }
    public GatheringGoal(int requiredAmount, Item taskItem) : base(requiredAmount)
    {
        this.TaskItem = taskItem;
    }
    public void GatherItem(Item item)
    {
        if (TaskItem == item)
        {
            CurrentAmount++; 
        }
    }
}
