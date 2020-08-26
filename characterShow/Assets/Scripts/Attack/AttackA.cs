using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackA : AttackBase
{
    private float stateTime = 0.0f;
    public override void AttackInit()
    {
        
        base.AttackInit();
    }
    public override void Attacking()
    {

        //animator.SetFloat("StateTime", Mathf.Repeat(animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 1f));
        animator.ResetTrigger("Attack");

        if (behaviorInfo.CanAttack) {
            animator.SetTrigger("Attack");
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
                stateTime++;
            animator.SetFloat("StateTime", stateTime);
        }
        
    }
    public override void AttackFinish()
    {
        
    }
}
