using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class SkillManager : Singleton<SkillManager>
{
    /// <summary>
    /// SkillRegist : 當玩家將技能拉入快捷鍵技能列表
    /// SkillUnRegist : 當玩家將技能拉出快捷鍵技能列表
    /// </summary>
    public Dictionary<string, Skill> mActiveSkillDict;
    public int SkillCount;
    private SkillApplyUI skillApplyUI; //用快捷鍵使用的UI
    private SkillSettingUI skillSettingUI; //技能設定用的UI

    public override void Awake()
    {
        base.Awake();
        ManagerInit();
    }

    public void ManagerInit()
    {
        mActiveSkillDict = new Dictionary<string, Skill>(SkillCount);
        skillSettingUI = FindObjectOfType<SkillSettingUI>();
        skillApplyUI = FindObjectOfType<SkillApplyUI>();
        skillSettingUI.SkillSettingUIInit();
        skillApplyUI.SkillApplyingUIInit();


    }
    public void RegistToSkillBar(Skill skill , int index )
    {
        Debug.Log("SkillContext : " + skill + " , " + skill.GetSkillID());
        if(!mActiveSkillDict.ContainsKey(skill.GetSkillID())) //確認是否添加過
             mActiveSkillDict.Add(skill.GetSkillID(), skill);

        

    }
    public Skill GetSkill(string skillID)
    {
        return mActiveSkillDict[skillID];
    }
    public bool UnRegistFromSkillBar(string skillID)
    {
        return mActiveSkillDict.Remove(skillID);
    }
    /// <summary>
    /// 負責將技能實例套入模板
    /// </summary>
    /// <param name="skillID"></param>
    /// <param name="skillContext"></param>
    /// <returns></returns>

    /*private void assignShortCut(GameDataManager manager) 
    {
        foreach (KeyValuePair<string , IActiveSkill> activeSkill in mActiveSkillDict)
        {
            activeSkill.Value.SetSkillShortCut(KeyCode.A);
        }
    }*/
    public SkillSettingUI GetSkillSettingCanvas()
    {
        return skillSettingUI;
    }
    public SkillApplyUI GetSkillApplyUI()
    {
        return skillApplyUI;
    }
    public void DestroyTheSkillChosenCard(GameObject skillChosenGroup)
    {
        foreach (Transform child in skillChosenGroup.transform)
        {
            Destroy(child.gameObject);
        }

    }
}
