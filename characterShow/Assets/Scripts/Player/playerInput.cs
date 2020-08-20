using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// return action bool
/// </summary>
public class playerInput : MonoBehaviour
{
    protected Vector2 playerMove;
    protected Vector2 cameraMove;
    protected bool playerBlocked = false;
    protected bool isJump;
    protected bool isAttack;
    protected bool isSkill;
    protected skillBase skillmode;
    protected int[] skillCD = new int[3];
    
    //protected bool[] skillKey = new KeyCode[3];
    
    public Vector2 MoveInput
    {
        get 
        {
            if (playerBlocked)
                return Vector2.zero;
            return playerMove;
        }
    
    }
    public Vector2 CameraInput
    {
        get
        {
            if (playerBlocked)
                return Vector2.zero;
            return cameraMove;
        }

    }
    public bool jumpInput
    {
        get { return isJump && !playerBlocked; }
    }
    public bool Attack 
    {
        get { return isAttack && !playerBlocked; }
    }
    public bool Skill
    {
        get { return isSkill; }
    }
    
    WaitForSeconds AttackInputWait;
    Coroutine AttackWaitCoroutine;
    const float AttackInputDuration = 0.03f;

    public void InputInit()
    {
        
        AttackInputWait = new WaitForSeconds(AttackInputDuration);
    }
    public void Inputing() 
    {
        playerMove.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        cameraMove.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        isJump = Input.GetButton("Jump");
        //綁定skill按鈕

        if (Input.GetButtonDown("Fire1")) { // attack

            if (AttackWaitCoroutine != null)
                StopCoroutine(AttackWaitCoroutine); //will attack after 3 sec for last attack

            AttackWaitCoroutine = StartCoroutine(AttackWait());
            isJump = Input.GetButton("Jump");
        }
       
    }
    private IEnumerator AttackWait() {

        isAttack = true;
        Debug.Log("Attack");
        yield return AttackInputWait;

        isAttack = false;
        Debug.Log("NotAttack");
    }
}
