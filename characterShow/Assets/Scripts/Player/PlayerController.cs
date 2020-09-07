using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // 控制基礎的移動、跳躍
    // 各項參數
    const float gravity = 20f;
    const float groundAcceleration = 20f;
    const float groundDeceleration = 25f;
    const float airborneTurnSpeedProportion = 5.4f;
    const float inverseOneEighty = 1f / 180f;
    const float stickingGravityProportion = 0.3f;
    const float jumpAbortSpeed = 10f;   // 當玩家提早放掉跳躍鍵時的額外減速

    //public PlayerTaskController PTaskController { get; set; } //player Task
    public float MaxMoveSpeed = 10f; // 移動速度
    public float MinTurnSpeed = 400f;   // 最小旋轉速度
    public float MaxTurnSpeed = 1200f;  // 最大旋轉速度
    public float JumpSpeed = 10f;   // 跳躍速度

    protected CharacterController characterController;
    protected PlayerBehaviorInfo playerInfo;

    private float desiredForwardSpeed;  
    private float forwardSpeed; // 當前的水平移動速度
    private float verticalSpeed;    // 當前的垂直移動速度
    private float angleDiff;
    private Quaternion targetRotation;
    private bool isGrounded = true;
    private bool readyToJump = true;
    private Vector3 movement;
    private CameraSetting cameraSetting;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInfo = GetComponent<PlayerBehaviorInfo>();
        cameraSetting = FindObjectOfType<CameraSetting>();
        //PTaskController = GetComponent<PlayerTaskController>();
    }

    private void FixedUpdate()
    {
        CalculateMovement();
        CaluclateVerticalMovement();
        SetRotation();
        if(IsMoveInput())
            UpdateOrientation();

        if(forwardSpeed > 0)
        {
            GetComponent<Animator>().SetBool("isMove", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isMove", false);
        }
    }

    private void CalculateMovement()
    {
        Vector2 moveInput = new Vector2(playerInfo.MovementDir.x, playerInfo.MovementDir.z);
        if (moveInput.sqrMagnitude > 1f)
            moveInput.Normalize();

        // 根據Input計算速度
        desiredForwardSpeed = moveInput.magnitude * MaxMoveSpeed;

        // 判斷需要加速還是減速
        float acceleration = IsMoveInput() ? groundAcceleration : groundDeceleration;

        // 將加速與減速添加到移動速度上
        forwardSpeed = Mathf.MoveTowards(forwardSpeed, desiredForwardSpeed, acceleration * Time.deltaTime);

        // 計算最後的移動值
        movement = forwardSpeed * transform.forward * Time.deltaTime;
        movement += verticalSpeed * Vector3.up * Time.deltaTime;

        characterController.Move(movement);

        isGrounded = playerInfo.IsGrounded;
    }

    private void CaluclateVerticalMovement()
    {
        if(!playerInfo.JumpInput && isGrounded)
        {
            readyToJump = true;
        }

        if (isGrounded)
        {
            // 當角色在地面上時給予一個輕微的速度使其黏在地面上
            verticalSpeed = -gravity * stickingGravityProportion;

            // 當玩家按下跳躍鈕且準備好可以跳
            if(playerInfo.JumpInput && readyToJump)
            {
                verticalSpeed = JumpSpeed;
                isGrounded = false;
                readyToJump = false;
            }
        }
        else
        {
            if(!playerInfo.JumpInput && verticalSpeed > 0f)
            {
                // 當玩家按越久則跳躍高
                verticalSpeed -= jumpAbortSpeed * Time.deltaTime;
            }

            // 當速度接近0時，使其變為0
            if (Mathf.Approximately(verticalSpeed, 0f))
            {
                verticalSpeed = 0f;
            }

            verticalSpeed -= gravity * Time.deltaTime;
        }
    }

    private void SetRotation()
    {
        Vector3 localMovementDirection = new Vector3(playerInfo.MovementDir.x, 0, playerInfo.MovementDir.z).normalized;
        // 根據Camera調整向前的方向
        Vector3 forward = Quaternion.Euler(0, cameraSetting.FreeLook.m_XAxis.Value, 0) * Vector3.forward;
        forward.y = 0f;
        forward.Normalize();

        Quaternion targetRotation;

        if (Mathf.Approximately(Vector3.Dot(localMovementDirection, Vector3.forward), -1.0f))
        {
            targetRotation = Quaternion.LookRotation(-forward);
        }
        else
        {
            // Otherwise the rotation should be the offset of the input from the camera's forward.
            Quaternion cameraToInputOffset = Quaternion.FromToRotation(Vector3.forward, localMovementDirection);
            targetRotation = Quaternion.LookRotation(cameraToInputOffset * forward);
        }

        Vector3 resultingForward = targetRotation * Vector3.forward;

        float angleCurrent = Mathf.Atan2(transform.forward.x, transform.forward.z) * Mathf.Rad2Deg;
        float targetAngle = Mathf.Atan2(resultingForward.x, resultingForward.z) * Mathf.Rad2Deg;

        angleDiff = Mathf.DeltaAngle(angleCurrent, targetAngle);
        this.targetRotation = targetRotation;
    }

    void UpdateOrientation()
    {
        Vector3 localInput = new Vector3(playerInfo.MovementDir.x, 0, playerInfo.MovementDir.z);
        // 前進速度越快，旋轉速度越慢
        float groundedTurnSpeed = Mathf.Lerp(MaxTurnSpeed, MinTurnSpeed, forwardSpeed / desiredForwardSpeed);
        float actualTurnSpeed = characterController.isGrounded ? groundedTurnSpeed : Vector3.Angle(transform.forward, localInput) * inverseOneEighty * airborneTurnSpeedProportion * groundedTurnSpeed;
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, actualTurnSpeed * Time.deltaTime);

        transform.rotation = targetRotation;
    }

    /// <summary>
    /// 回傳是否有輸入Input
    /// </summary>
    /// <returns></returns>
    protected bool IsMoveInput()
    {
        Vector2 moveInput = new Vector2(playerInfo.MovementDir.x, playerInfo.MovementDir.z);
        return !Mathf.Approximately(moveInput.sqrMagnitude, 0f);
    }
}
