using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillApplyUI : MonoBehaviour
{
    public SkillCoolDown[] SkillApplyList;

    /// <summary>
    /// Find the Skill Apply List
    /// </summary>
    public void SkillApplyingUIInit() 
    {
        SkillApplyList = this.GetComponentsInChildren<SkillCoolDown>();
    }
    public void AssignTheSkillData(string skillID , int index , KeyCode keyCode)
    {
        SkillApplyList[index].initialize(skillID , keyCode);
    }

}
