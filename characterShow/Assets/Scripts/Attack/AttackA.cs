using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackA : AttackBase
{
    // Start is called before the first frame update
    public override void AttackInit()
    {
        
        base.AttackInit();
    }
    public override void Attacking()
    {
        animator.SetFloat("StateTime", Mathf.Repeat(animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 1f));
        
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            
        }
        
    }
    public override void AttackFinish()
    {
        throw new System.NotImplementedException();
    }
}
