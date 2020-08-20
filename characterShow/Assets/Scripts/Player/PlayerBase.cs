using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    public GameObject playerModel;
    protected int blood; //get from FlowData
    protected int mana;  //get from FlowData
    protected int level;  //get from FlowData
    protected Animator animator;
    protected Bag bag;
    public List<AttackBase> AttackSet = new List<AttackBase>();
    public List<skillBase> SkillSet = new List<skillBase>();

    protected MoveManager moveManager = new MoveManager();
    protected playerInput mInput /*= new playerInput()*/ ;


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

        animator = playerModel.GetComponent<Animator>() ;
        //add Attack
        AttackSet = playerModel.GetComponents<AttackBase>().ToList();
        //add Skill
        SkillSet = playerModel.GetComponents<skillBase>().ToList();

        GameDataManager.instance.init();

        AttackSet.ForEach(p =>
        {
            p.AttackInit();
        });

        SkillSet.ForEach(p =>
        {
            p.skillInit();
        });

        mInput = GetComponent<playerInput>();
        moveManager.MoveInit(animator, playerModel, mInput);
        mInput.InputInit();


        //Create Task Manager
    }
    public virtual void PlayerLive() {

        mInput.Inputing();

        foreach (AttackBase attack in AttackSet)
        {
            attack.Attacking();
        }
        foreach (skillBase skill in SkillSet)
        {
            skill.skilling();
        }

    }
    public abstract void PlayerDead();

    protected void createPlayer(Vector3 createPos , Vector3 createRot, GameObject model) {

        var player = Instantiate(model, createPos, Quaternion.Euler(createRot));
        player.name = "DogKnight";
    }

    
}
