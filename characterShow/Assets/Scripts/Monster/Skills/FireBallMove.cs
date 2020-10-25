using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class FireBallMove : Projectile
{
    public Transform TargetPoint { get; set; }
=======
public class FireBallMove : SkillObject
{
    public Transform TargetPoint;
>>>>>>> Stashed changes
    public GameObject ImpactPrefab;
    public List<GameObject> Trails;

    protected override void Start()
    {
        base.Start();
<<<<<<< Updated upstream
        TargetPoint = GameObject.FindWithTag("Player").transform;
        SetForwardDirection();
    }

    protected override void FixedUpdate()
=======
        SetForwardDirection();
    }

    protected void FixedUpdate()
>>>>>>> Stashed changes
    {
        base.FixedUpdate();
        if(Speed != 0 && rigid != null)
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

        if(ImpactPrefab != null)
        {
            var impactVFX = Instantiate(ImpactPrefab, pos, rot);
            Destroy(impactVFX, 5);
        }

        if(Trails.Count > 0)
        {
            for(int i = 0; i < Trails.Count; i++)
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

        Destroy(gameObject);
    }

    protected override void SetForwardDirection()
    {
<<<<<<< Updated upstream
        var direction = TargetPoint.position - transform.position + Vector3.up * 0.5f;
=======
        var direction = TargetPoint.position - transform.position;
>>>>>>> Stashed changes
        var rotation = Quaternion.LookRotation(direction);
        transform.localRotation = Quaternion.Lerp(transform.rotation, rotation, 1);
    }
}
