using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackB : AttackBase
{
    public override void AttackInit()
    {
        base.AttackInit();
        ShortCut = KeyCode.Q;
    }
    public override void Attacking()
    {
        if (Input.GetKey(ShortCut))
        {
            animator.SetTrigger("Defend");

        }
    }
    public override void AttackFinish()
    {
        throw new System.NotImplementedException();
    }
}
