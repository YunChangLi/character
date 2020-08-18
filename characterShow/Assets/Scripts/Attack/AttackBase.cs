using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    protected Animator animator;
    public KeyCode shortCut;
    
    /// <summary>
    /// 組合動作初始化
    /// </summary>
    public virtual void AttackInit() {
        //Get the shortCut
        animator = this.GetComponent<Animator>();
    }
    public abstract void Attacking();

    public abstract void AttackFinish();
}
