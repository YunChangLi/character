using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class StateInfo : MonoBehaviour
{
    // 最大血量
    public float MaxHP;
    // 當前血量
    public float HP { get; private set; }
    // 最大魔量
    public float MaxMP;
    // 當前魔量
    public float MP { get; private set; }
    // 移動速度
    public float MoveSpeed;
    // 重力參數
    public float Gravity = 9.8f;
    // 速度
    public float SpeedX { get; set; }
    public float SpeedY { get; set; }
    public float SpeedZ { get; set; }
    // 角色控制
    public MovementController MovementController { get; private set; }

    /// <summary>
    /// 各種狀態
    /// </summary>
    // 是否著地
    public bool IsGrounded { get { return MovementController.CharacterController.isGrounded; } }
    // 是否無敵
    public bool IsInvincible;
    // 是否死亡
    public bool IsDead { get { return HP <= 0; } }

    private void Awake()
    {
        MovementController = GetComponent<MovementController>();
    }
}
