using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillField : MonoBehaviour
{
    private DropField dropField;
    private SkillData skillData;

    private void Awake()
    {
        //如果沒有DropField就添加
        dropField = GetComponent<DropField>() ?? gameObject.AddComponent<DropField>();
        dropField.OnDropHandler += OmItemDropped;
    }

    private void OmItemDropped(MovableImageUI obj)
    {
        obj.transform.position = transform.position;
        skillData = ((SkillCard)obj).skillData;
    }
    public SkillData GetSkillData()
    {
        return skillData;
    }
}
