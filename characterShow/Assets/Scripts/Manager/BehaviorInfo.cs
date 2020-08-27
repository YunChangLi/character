using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BehaviorInfo : MonoBehaviour
{
    //當前血量
    public float HP { get; set; }
    //最大血量
    public float MaxHP;
    
    private CharacterController characterController;


    /// <summary>
    /// 各種狀態
    /// </summary>
    // 是否著地
    public bool IsGrounded 
    { 
        get { return characterController.isGrounded; }
    }
    //是否撞牆
    public bool IsBlocked 
    {
        get { return Physics.Raycast(transform.position, Vector3.forward, 0.05f); }
    }

    // 是否無敵
    public bool IsInvincible { get; set; }
    // 是否死亡
    public bool IsDead { get { return HP <= 0; } }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


}
