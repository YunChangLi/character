using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    public KeyCode ShortCut;
    protected Animator animator;
    protected PlayerBehaviorInfo behaviorInfo;
    
    
    /// <summary>
    /// 組合動作初始化
    /// </summary>
    public virtual void AttackInit() {
        //Get the shortCut
        animator = this.GetComponent<Animator>();
        behaviorInfo = this.GetComponent<PlayerBehaviorInfo>();
    }
    public abstract void Attacking();

    public abstract void AttackFinish();
}
