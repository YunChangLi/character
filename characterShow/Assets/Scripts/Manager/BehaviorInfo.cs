using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class BehaviorInfo : MonoBehaviour
{   
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

    /// <summary>
    /// 是否死亡
    /// </summary>
    /// <returns></returns>
    public abstract bool IsDead();

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


}
