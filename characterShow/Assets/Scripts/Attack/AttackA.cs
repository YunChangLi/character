using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackA : AttackBase
{
    public override void AttackInit()
    {
        
        base.AttackInit();
    }
    public override void Attacking()
    {
        //Debug.Log(this.GetComponent<PlayerBehaviorInfo>().CanAttack);
        animator.SetFloat("StateTime", Mathf.Repeat(animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 1f));
        //animator.ResetTrigger("Attack");

        if (this.GetComponent<PlayerBehaviorInfo>().CanAttack)
        {
            animator.SetTrigger("Attack");
        }
        else {
            animator.ResetTrigger("Attack");
        }
        
    }
    public override void AttackFinish()
    {
        
    }
}
