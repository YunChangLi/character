using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "Monster Data", order = 1)]
public class MonsterData : ScriptableObject
{
    // 名字
    public string Name;
    // 最大血量
    public float MaxHP;
    // 最大移動速度
    public float MaxMoveSpeed;
    // 跳躍初速度
    public float JumpSpeed;
    // 原地旋轉速度
    public float StandRotateSpeed;
}
