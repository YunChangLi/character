using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingGoal : QuestGoal
{
    public MonsterData TargetMonster { get; set; }
    public KillingGoal(int requiredAmount , MonsterData targetMonster) : base(requiredAmount)
    {
        this.TargetMonster = targetMonster;
    }

}
