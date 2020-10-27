using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSkillContext :MonoBehaviour ,  ISkillContext
{
    public string ID { get; set; }
    public float DamageValue ;
    public float WeaponRange ;
    public float HitForce ;



    public void PrepareSkill()
    {
       
    }

    public IEnumerator StartSkill()
    {
        yield return null;
    }

    public IEnumerator StopSkill()
    {
        yield return null;
    }


}
