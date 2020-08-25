using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public int speed; //Get from DataManager
    private Animator animator;
    private GameObject player;
    public KeyCode Jump  = KeyCode.Space;
    public KeyCode Forward = KeyCode.W;
    public KeyCode Backward = KeyCode.S;
    public KeyCode Leftward = KeyCode.A;
    public KeyCode Rightward = KeyCode.D;
    private CharacterController playercontroller;
    private Vector3 moveDirection = Vector3.zero;
    /// <summary>
    /// get the animator and flowData to set KeyCode
    /// </summary>
    /// <param name="animator"></param>
    public void MoveInit(Animator animator , GameObject player)
    {
        this.animator = animator;
        this.player = player;
        playercontroller = player.GetComponent<CharacterController>();
    }
    public void Moving()
    {

   
        if (Input.GetKey(Jump) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            animator.SetTrigger("Jump");
        }
        if (Input.GetKeyDown(Forward))
        {
            animator.SetBool("isMove", true);
        }
        else if (Input.GetKeyUp(Forward)) 
        {
            animator.SetBool("isMove", false);
        }
    }
    public void updateDirection() 
    {

    }
    public void MoveStop()
    {


    }

}
