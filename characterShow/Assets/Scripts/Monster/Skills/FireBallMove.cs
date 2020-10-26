using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMove : Projectile
{
    public List<GameObject> Trails;

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
}
