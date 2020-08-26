using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    // 控制基礎的移動、跳躍、重力影響等

    public CharacterController CharacterController { get; private set; }
    // 重力參數
    public const float Gravity = 9.8f;
    // 移動速度
    public float MoveSpeed = 10;

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 dir)
    {
        if (dir == Vector3.zero)
            return;

        gameObject.transform.forward = dir;
        CharacterController.Move(dir * MoveSpeed * Time.deltaTime);
    }

    public void Jump()
    {

    }
}
