using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    
    protected int blood; //get from FlowData
    protected int mana;  //get from FlowData
    protected int level;  //get from FlowData
    protected Animator animator;
    protected Bag bag;
    public List<AttackBase> AttackSet = new List<AttackBase>();
    public skillBase skill_A;
    public skillBase skill_B;
    public skillBase skill_C;


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
        GameDataManager.instance.init();

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

    
}
