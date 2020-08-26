using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorInfo : BehaviorInfo
{
    //當前血量
    public float MP { get; set; }
    //最大血量
    public float MaxMp ;

    /// <summary>
    /// player 各種狀態
    /// </summary>
    public bool CanAttack
    {
        get { return !IsBlocked && IsGrounded && Input.GetButtonDown("Fire1"); }
    }


}
