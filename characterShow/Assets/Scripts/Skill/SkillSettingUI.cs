﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSettingUI : MonoBehaviour
{
    public SkillField[] skills;
    public Button StoredButton;
    public GameObject ChosenSkillsGroup;

    //put on the skill manager init
    public void SkillSettingUIInit()
    {
        StoredButton.onClick.AddListener(Setting);
    }
    private void Setting()
    {
        SkillManager.instance.mActiveSkillDict.Clear();
        skills = this.GetComponentsInChildren<SkillField>();
        for (int i  = 0 ; i < skills.Length; i++ )
        {
            if (skills[i].GetSkillEntity() != null) 
            {
                skills[i].GetSkillEntity().initialize(skills[i].GetSkillContext()); // skill初始化
                SkillManager.instance.RegistToSkillBar(skills[i].GetSkillEntity() , i);
               
            }
                
        }
    }
}
