using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo : BehaviorInfo
{
    // 紀錄Monster資訊的ScriptableObject
    public MonsterData Data;

    public float HP { get; private set; }

    private void Start()
    {
        HP = Data.MaxHP;
    }

    public override bool IsDead()
    {
        return HP <= 0;
    }
}
