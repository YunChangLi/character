using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BehaviorInfo))]
public abstract class PlayerBase : MonoBehaviour
{
    

    public List<AttackBase> AttackSet = new List<AttackBase>();
    public float speed;
    public float jumpSpeed;
    public skillBase skill_A;
    public skillBase skill_B;
    public skillBase skill_C;

    protected int blood; //get from FlowData
    protected int mana;  //get from FlowData
    protected int level;  //get from FlowData
    protected Animator animator;
    protected Bag bag;

    private CharacterController controller;
    private float gravity = 9.8f;
    private Vector3 moveDirection = Vector3.zero;
    protected MoveManager moveManager = new MoveManager();



    public int getBlood() {
        return blood;
    }
    public int getMana() {
        return mana;
    }
    public int getLevel()
    {
        return level;
    }
    public void setBlood(int blood) {
        this.blood = blood;
    }
    public void setMana(int mana) {
        this.mana = mana;
    }
    public void setLevel(int blood)
    {
        this.blood = level;
    }
    public virtual void PlayerInit() {

        GameDataManager.instance.ManagerInit();
        GamePlayerManager.instance.ManagerInit();
        controller = GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>() ;
        //add Attack
        AttackSet = this.GetComponents<AttackBase>().ToList();
        if(skill_A)
            skill_A.skillInit(GameDataManager.instance.flowData.keyDatas.Skill_1);
        if(skill_B)
            skill_B.skillInit(GameDataManager.instance.flowData.keyDatas.Skill_2);
        if(skill_C)
            skill_C.skillInit(GameDataManager.instance.flowData.keyDatas.Skill_3);


        AttackSet.ForEach(p =>
        {
            p.AttackInit();
        });

        moveManager.MoveInit(animator, this.gameObject);
        playerInput.instance.InputInit();


        //Create Task Manager
    }
    public virtual void PlayerLive() {

        playerInput.instance.Inputing();
        PlayerMove();
        foreach (AttackBase attack in AttackSet)
        {
            attack.Attacking();
        }
        skill_A.mSkill();

    }
    public abstract void PlayerDead();

    protected void createPlayer(Vector3 createPos , Vector3 createRot, GameObject model) {

        var player = Instantiate(model, createPos, Quaternion.Euler(createRot));
        player.name = "DogKnight";
    }
    
    /// <summary>
    /// control the move and jump
    /// </summary>
    private void PlayerMove() {
        //bool grounded = playerInput.isGrounded;
        if (/*grounded*/ moveDirection.y < 0) 
        {
            moveDirection.y = 0;
        }
        if (controller.isGrounded) 
        {
            
        }
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); //Get Axis
        //moveDirection = transform.TransformDirection(moveDirection); //change the local Dir to the world space

        /*if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * speed * Time.deltaTime);
        Debug.Log(moveDirection);*/


    }
    
}
