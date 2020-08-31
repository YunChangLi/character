using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Vector3 MoveDir { get; set; }
    public bool GoJump = false;
    public bool CanMove = true;
    public float MaxMoveSpeed = 1f; // 最大移動速度
    public float JumpSpeed = 20f;   // 跳躍速度

    private CharacterController characterController;
    private MonsterInfo monsterInfo;
    private float desiredForwardSpeed;
    private float forwardSpeed;
    private float acceleration = 5;
    private bool isGrounded = false;
    private Vector3 movement;
    private float verticalSpeed;
    private bool readyToJump;

    const float gravity = 20f;
    const float inverseOneEighty = 1f / 180f;
    const float stickingGravityProportion = 0.3f;


    public void Init()
    {
        characterController = GetComponent<CharacterController>();
        monsterInfo = GetComponent<MonsterInfo>();
    }

    public void UpdateCalculation()
    {
        CalculateMovement();
        CaluclateVerticalMovement();
    }

    /// <summary>
    /// 計算移動
    /// </summary>
    protected virtual void CalculateMovement()
    {
        //Vector2 moveInput = new Vector2(ActionController.Info.MovementDir.x, playerInfo.MovementDir.z);
        if (MoveDir.sqrMagnitude > 1f)
            MoveDir.Normalize();

        if (!CanMove)
            return;

        // 根據Input計算速度
        desiredForwardSpeed = MoveDir.magnitude * MaxMoveSpeed;

        // 將加速與減速添加到移動速度上
        forwardSpeed = Mathf.MoveTowards(forwardSpeed, desiredForwardSpeed, acceleration * Time.deltaTime);

        // 計算最後的移動值
        movement = forwardSpeed * MoveDir * Time.deltaTime;

        if(movement != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(movement);

        movement += verticalSpeed * Vector3.up * Time.deltaTime;

        characterController.Move(movement);

        isGrounded = monsterInfo.IsGrounded;
    }

    /// <summary>
    /// 計算垂直移動
    /// </summary>
    private void CaluclateVerticalMovement()
    {
        if (monsterInfo.IsGrounded)
        {
            readyToJump = true;
        }

        if (isGrounded)
        {
            // 當怪物在地面上時給予一個輕微的速度使其黏在地面上
            verticalSpeed = -gravity * stickingGravityProportion;

            // 當怪物準備好可以跳
            if (GoJump && readyToJump)
            {
                verticalSpeed = JumpSpeed;
                isGrounded = false;
                readyToJump = false;
                GoJump = false;
            }
        }
        else
        {
            // 當速度接近0時，使其變為0
            if (Mathf.Approximately(verticalSpeed, 0f))
            {
                verticalSpeed = 0f;
            }

            verticalSpeed -= gravity * Time.deltaTime;
        }
    }
}
