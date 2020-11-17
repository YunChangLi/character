using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallSkillContext : MonoBehaviour , ISkillContext
{

    public float DamageValue ;
    public float WeaponRange;
    public float HitForce ;
    public string ID { get; set ; }
    public GameObject player {
        get { return GamePlayerManager.instance.Player; }
        set { }
    }

    public void PrepareSkill()
    {
        //choose the animator
        player.GetComponent<PlayerBehaviorInfo>().IsSkill = false;
    }

    public IEnumerator StartSkill()
    {
        player.GetComponent<PlayerBehaviorInfo>().IsSkill = true;
        Debug.Log(player.GetComponent<PlayerBehaviorInfo>().CanAttack);
        yield return new WaitForSeconds(10);
        player.GetComponent<PlayerBehaviorInfo>().IsSkill = false;

    }

    public IEnumerator StopSkill()
    {
        player.GetComponent<PlayerBehaviorInfo>().IsSkill = false;
        yield return null;
    }
}
