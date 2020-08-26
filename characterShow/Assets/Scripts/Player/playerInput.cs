using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// return action bool
/// </summary>
public class playerInput : Singleton<playerInput>
{
    protected Vector2 playerMove;
    protected Vector2 cameraMove;
    protected bool playerBlocked = false;
    protected bool isJump;
    protected bool isAttack;

    protected ShortCutData shortKey;
    
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

    
    WaitForSeconds AttackInputWait;
    Coroutine AttackWaitCoroutine;
    const float AttackInputDuration = 0.3f;

    public void InputInit()
    {
        shortKey = GameDataManager.instance.flowData.keyDatas;
        AttackInputWait = new WaitForSeconds(AttackInputDuration);
    }
    /*public void move(CharacterController controller , Vector3 Dir) { 
        controller.Move()
    }*/
    public void Inputing() 
    {
        playerMove.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        cameraMove.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        isJump = Input.GetButton("Jump");
        //綁定skill按鈕

        if (Input.GetButtonDown("Fire1")) { // attack

            if (AttackWaitCoroutine != null) {
                StopCoroutine(AttackWaitCoroutine); //避免一直新增cooroutine
                Debug.Log("Stop");
            }

            AttackWaitCoroutine = StartCoroutine(AttackWait());

        }
        if (Input.GetKeyDown (shortKey.Skill_1)) {

            
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
