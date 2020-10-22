using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkillContext :MonoBehaviour ,  ISkillContext
{
    public string ID => System.Guid.NewGuid().ToString();
    public float DamageValue ;
    public float WeaponRange ;
    public float HitForce ;

    

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
