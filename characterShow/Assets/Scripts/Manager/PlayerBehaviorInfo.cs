using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorInfo : BehaviorInfo
{
    //當前血量
    public float MP { get; set; }
    //最大血量
    public float MaxMp ;
    //內部調整的位移向量
    private Vector3 movement;

    public Vector3 MovementDir 
    {
        get 
        {
            if (IsBlocked) return Vector3.zero;
            else return movement;
        }
    }

    /// <summary>
    /// player 各種狀態
    /// </summary>
    public bool CanAttack
    {
        get { return !IsBlocked && IsGrounded && Input.GetButtonDown("Fire1"); }
    }
    private void Update()
    {
        movement.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    }


}
