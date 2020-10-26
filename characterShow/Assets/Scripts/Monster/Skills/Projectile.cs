using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    // 該腳本用於讓怪物使用技能時產生的拋射物件使用

    public Vector3 TargetPos { get; set; }       // 目標座標
    public float Speed;     // 移動速度
    public GameObject ImpactPrefab;     // 碰撞特效

    protected Rigidbody rigid;

    private bool readyToShoot = false;

    /// <summary>
    /// 發射
    /// </summary>
    public void Shoot()
    {
        readyToShoot = true;
    }

    /// <summary>
    /// 設定該物件向前的方向
    /// </summary>
    protected void SetForwardDirection()
    {
        var direction = TargetPos - transform.position;
        var rotation = Quaternion.LookRotation(direction);
        transform.localRotation = Quaternion.Lerp(transform.rotation, rotation, 1);
    }

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody>();
        SetForwardDirection();
    }

    protected virtual void FixedUpdate()
    {
        if (!readyToShoot)
            return;

        if (Speed != 0 && rigid != null)
        {
            rigid.position += transform.forward * (Speed * Time.deltaTime);
        }
    }
}
