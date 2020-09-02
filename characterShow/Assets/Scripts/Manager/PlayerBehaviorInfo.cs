using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorInfo : BehaviorInfo
{
    //當前血量
    public float HP { get; set; }
    //最大血量
    public float MaxHP;
    //當前魔量
    public float MP { get; set; }
    //最大魔量
    public float MaxMp ;
    //內部調整的位移向量
    private Vector3 movement;
    
    public bool JumpInput;

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
        get { return !IsBlocked /*&& IsGrounded */ && isAttack; }
    }
    public bool IsDefense
    {
        get { return /**IsGrounded**/Input.GetKey(KeyCode.Z); }
    }

    public override bool IsDead()
    {
        return HP <= 0;
    }

    //內部調整攻擊判定
    private bool isAttack;
    //用來延遲攻擊判定
    private Coroutine AttackWait;
    //延遲多少秒
    const float AttackWaitTime = 0.1f;

    private void Update()
    {
        movement.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        JumpInput = Input.GetButton("Jump");

        if (Input.GetButtonDown("Fire1")) {

            if (AttackWait != null)
                StopCoroutine(AttackWait);
            AttackWait = StartCoroutine(AttackWaitCoroutine());
        }
    }
    private IEnumerator AttackWaitCoroutine() 
    {
        isAttack = true;
        yield return new WaitForSeconds(AttackWaitTime);
        isAttack = false;
    }


}
