using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackB : AttackBase
{
    public override void AttackInit()
    {
        base.AttackInit();
    }
    public override void Attacking()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            animator.SetTrigger("Defend");

        }
    }
    public override void AttackFinish()
    {
        throw new System.NotImplementedException();
    }
}
