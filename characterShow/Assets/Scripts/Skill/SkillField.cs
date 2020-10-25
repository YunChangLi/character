using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillField : MonoBehaviour
{
    private DropField dropField;
    private Skill skillEntity;
    private ISkillContext skillContext;
    public string StoredSkillID;


    private void Awake()
    {
        //如果沒有DropField就添加
        dropField = GetComponent<DropField>() ?? gameObject.AddComponent<DropField>();
        dropField.OnDropHandler += OmItemDropped;
       
    }

    private void OmItemDropped(MovableImageUI obj)
    {
        
        var skillObj = (SkillCard)obj;
        
        obj.transform.position = transform.position; //擺放位置
        skillEntity = skillObj.SkillEntity;
        skillContext = obj.GetComponent<ISkillContext>();
        StoredSkillID = skillObj.SkillEntity.GetSkillID();
        dropField.hasItem = true;
        
    }
    public Skill GetSkillEntity()
    {
        return skillEntity;
    }
    public ISkillContext GetSkillContext()
    {
        return skillContext;
    }

}
