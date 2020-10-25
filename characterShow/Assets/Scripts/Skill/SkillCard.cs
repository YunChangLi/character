using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Skill UI : operation
/// 1. show the skill data
/// 2. show the skill UI image
/// </summary>
public class SkillCard : MovableImageUI
{
    public Skill SkillEntity;
    

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (IsInTheField)
        {
            Debug.Log("In the Field.");
        }  
        else
        {
            Debug.Log("Not in the Field");
        }
            
    }
}
