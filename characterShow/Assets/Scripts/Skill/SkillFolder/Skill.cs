using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Skill : ScriptableObject
{
    public string SkillName = "New Skill";
    public Sprite SkillSprite;
    public AudioClip SkillSound;
    public float SkillCoolDown = 1f;
    [SerializeField]
    protected string skillID = System.Guid.NewGuid().ToString();

    public abstract void initialize(ISkillContext skillContext);
    public abstract void TriggerSkill();
    public abstract ISkillContext GetSkillContext();

    public virtual string GetSkillID()
    {
        return skillID;
    }
}
