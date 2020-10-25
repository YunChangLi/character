using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    // 該腳本用於讓怪物使用技能時產生的拋射物件使用

    public float Speed;

    protected Rigidbody rigid;

    private bool readyToShoot = false;

    protected abstract void SetForwardDirection();     // 設定該物件向前的方向

    public void Shoot()
    {
        readyToShoot = true;
    }

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody>();    
    }

    protected virtual void FixedUpdate()
    {
        if (!readyToShoot)
            return;
    }
}
