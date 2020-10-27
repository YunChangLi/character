using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // 該腳本用於讓怪物使用技能時產生的拋射物件使用

    public Vector3 TargetPos { get; set; }      // 目標座標
    public float Damage { get; set; }           // 傷害
    public float Speed;                         // 移動速度
    public GameObject ImpactPrefab;             // 碰撞特效
    public List<GameObject> Trails;             // 尾部特效

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

    private void OnCollisionEnter(Collision collision)
    {
        Speed = 0;

        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if (ImpactPrefab != null)
        {
            var impactVFX = Instantiate(ImpactPrefab, pos, rot);
            Destroy(impactVFX, 5);
        }

        if (Trails.Count > 0)
        {
            for (int i = 0; i < Trails.Count; i++)
            {
                Trails[i].transform.parent = null;
                var ps = Trails[i].GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Stop();
                    Destroy(ps.gameObject, ps.main.duration + ps.main.startLifetime.constantMax);
                }
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehaviorInfo>().HP -= Damage;
            Debug.Log("Area Hit!");
        }

        Destroy(gameObject);
    }
}
