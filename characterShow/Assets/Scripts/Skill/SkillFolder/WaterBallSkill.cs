using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
[CreateAssetMenu(fileName = "WaterBallSkill", menuName = "New Skill/WaterBallSkill")]
public class WaterBallSkill : Skill
{
    public override string SkillName => "WaterBallSkill";
    public float DamageValue = 1;
    public float WeaponRange = 50f;
    public float HitForce = 100f;
    private WaterBallSkillContext waterBallContext;

    

    public override ISkillContext GetSkillContext()
    {
        return waterBallContext;
    }

    public override void initialize(ISkillContext skillContext)
    {
        Debug.Log("initialize : WaterBall");
        waterBallContext = (WaterBallSkillContext)skillContext;
        waterBallContext.ID = this.skillID;
        waterBallContext.DamageValue = this.DamageValue;
        waterBallContext.WeaponRange = this.WeaponRange;
        waterBallContext.HitForce = this.HitForce;
        waterBallContext.PrepareSkill();
    }

    public override void TriggerSkill()
    {
        waterBallContext.StartSkill();
    }
}
