using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireBallSkill",menuName = "New Skill/FireBallSkill")]
public class FireBallSkill : Skill
{
    public float DamageValue = 1;
    public float WeaponRange = 50f;
    public float HitForce = 100f;

    private FireBallSkillContext SkillTriggable;

    /// <summary>
    /// assign value
    /// </summary>
    /// <param name="obj"></param>
    public override void initialize(SkillCard card)// change to the Skill bar
    {
        Debug.Log("initialize");
        SkillTriggable = card.GetComponent<FireBallSkillContext>();
        SkillTriggable.DamageValue = this.DamageValue;
        SkillTriggable.WeaponRange = this.WeaponRange;
        SkillTriggable.HitForce = this.HitForce;
        SkillTriggable.PrepareSkill();
    }

    public override void TriggerSkill()
    {
        SkillTriggable.StartSkill();
    }
    public override ISkillContext GetSkillContext()
    {
        return SkillTriggable;
    }


    
}
