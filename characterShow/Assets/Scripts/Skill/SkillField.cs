using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillField : DropField
{
    private Skill skillEntity;
    private ISkillContext skillContext;
    private Color skillFieldColor;


    private void Awake()
    {
        skillFieldColor = GetComponent<Image>().color;
        //如果沒有DropField就添加
        this.OnDropHandler += OnItemDropped;
        this.OnUnDropHandler += OnUnItemDropped;
       
    }

    private void OnItemDropped(MovableImageUI obj)
    {
        
        var skillObj = (SkillCard)obj;

        /*if (skillObj.SkillEntity.SkillSprite)
            this.GetComponentInChildren<Image>().sprite = skillObj.SkillEntity.SkillSprite;
        else
            this.GetComponentInChildren<Image>().color = obj.GetComponent<Image>().color;*/

        if (obj.IsNotReturn)
        {
            obj.transform.position = transform.position;
        }
        else 
        {
            obj.GetRect().anchoredPosition = obj.StoredPosition;//Return
            CreateChosenSkillCard(skillObj);
        }

        
        skillEntity = skillObj.SkillEntity;
        skillContext = obj.GetComponent<ISkillContext>();
        
        
    }
    private void OnUnItemDropped(MovableImageUI movable)
    {
        Debug.Log("UnDrop : " + movable.name);
        if (((SkillCard)dropItem).SkillEntity.GetSkillID() == ((SkillCard)movable).SkillEntity.GetSkillID())
        {
            dropItem = null;
            skillEntity = null;

        }
            
    }
    public Skill GetSkillEntity()
    {
        return skillEntity;
    }
    public ISkillContext GetSkillContext()
    {
        return skillContext;
    }
    private void CreateChosenSkillCard(SkillCard skillcard) 
    {
        var skillChosenCard = Instantiate(skillcard, transform.position, Quaternion.identity);
        skillChosenCard.name = "SkillChosenCard(" + skillcard.SkillEntity.SkillName + ")";
        skillChosenCard.transform.parent = SkillManager.instance.GetSkillSettingCanvas().ChosenSkillsGroup.transform;
        skillChosenCard.ItemField = this;
        skillChosenCard.UIInitialized();
        dropItem = skillChosenCard;
    }


}
