using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Skill : ScriptableObject
{
    public string SkillName = "New Skill";
    public Sprite SkillSprite;
    public AudioClip SkillSound;
    public float SkillCoolDown = 1f;

    public abstract void initialize(SkillCard card);
    public abstract void TriggerSkill();
    public abstract ISkillContext GetSkillContext();
}
