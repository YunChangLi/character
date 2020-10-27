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

    public override void MoveItemToFilledField(MovableImageUI movOld, MovableImageUI movNew)
    {
        Destroy(movOld.gameObject);
    }

}
