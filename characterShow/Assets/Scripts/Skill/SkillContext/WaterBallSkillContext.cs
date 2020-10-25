using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallSkillContext : MonoBehaviour  , ISkillContext
{
    public float DamageValue ;
    public float WeaponRange;
    public float HitForce ;
    public string ID { get; set ; }

    public void PrepareSkill()
    {
        
    }

    public void StartSkill()
    {
    }

    public void StopSkill()
    {
        
    }

   
}
