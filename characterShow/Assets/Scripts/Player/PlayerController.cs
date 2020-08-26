using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // 控制基礎的移動、跳躍、重力影響等
    // 重力參數
    public const float Gravity = 9.8f;
    // 移動速度
    public float MaxMoveSpeed = 10;
    // 掛在身上的CharacterController
    protected CharacterController characterController;

    protected PlayerBehaviorInfo playerInfo;

    private float desiredForwardSpeed;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInfo = GetComponent<PlayerBehaviorInfo>();
    }

    private void FixedUpdate()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        Vector2 moveInput = new Vector2(playerInfo.MovementDir.x, playerInfo.MovementDir.z);
        if (moveInput.sqrMagnitude > 1f)
            moveInput.Normalize();

        // 根據Input計算速度
        desiredForwardSpeed = moveInput.magnitude * MaxMoveSpeed;
    }

    private void Jump()
    {

    }
}
