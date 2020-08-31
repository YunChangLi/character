using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAreaCreator : Singleton<DamageAreaCreator>
{
    public GameObject DamageAreaPrefab;

    // 產生立方體區域
    public void CreateCubeArea(Vector3 pos, Quaternion rot, Vector3 size, float Damage, float keepTime)
    {
        GameObject obj = Instantiate(DamageAreaPrefab);
        obj.transform.position = pos;
        obj.transform.rotation = rot;
        //obj.tag = "DamageArea";
        DamageArea area = obj.GetComponent<DamageArea>();
        area.Damage = Damage;
        BoxCollider collider = obj.GetComponent<BoxCollider>();
        collider.size = size * 2;
        collider.enabled = true;
        Destroy(obj, keepTime);
    }

    // 產生球體區域
    public void CreateSphereArea(Vector3 pos, float radius, float Damage, float keepTime)
    {
        GameObject obj = Instantiate(DamageAreaPrefab);
        obj.transform.position = pos;
        //obj.tag = "DamageArea";
        DamageArea area = obj.GetComponent<DamageArea>();
        area.Damage = Damage;
        SphereCollider collider = obj.GetComponent<SphereCollider>();
        collider.radius = radius;
        collider.enabled = true;
        Destroy(obj, keepTime);
    }

}
