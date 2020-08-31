using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingGoal : QuestGoal
{
    public MonsterInfo TargetMonster { get; set; }
    public KillingGoal(int requiredAmount , MonsterInfo targetMonster) : base(requiredAmount)
    {
        this.TargetMonster = targetMonster;
    }

}
