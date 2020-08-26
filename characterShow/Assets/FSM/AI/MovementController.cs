using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    // 控制基礎的移動、跳躍、重力影響等

    public CharacterController CharacterController { get; private set; }

    public StateInfo StateInfo { get; private set; }

    public Vector3 MoveDirection { get; set; }

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        StateInfo = GetComponent<StateInfo>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (MoveDirection == Vector3.zero)
            return;


    }
}
