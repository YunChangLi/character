using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    /// <summary>
    /// SkillRegist : 當玩家將技能拉入快捷鍵技能列表
    /// SkillUnRegist : 當玩家將技能拉出快捷鍵技能列表
    /// </summary>
    public Dictionary<string, ISkillContext> mActiveSkillDict;
    public int SkillCount;

    public override void Awake()
    {
        base.Awake();
        ManagerInit();
    }

    public void ManagerInit()
    {
        mActiveSkillDict = new Dictionary<string, ISkillContext>(SkillCount);
       
    }
    public void RegistToSkillBar(ISkillContext skill)
    {
        Debug.Log("SkillContext : " + skill + " , " + skill.ID);
        mActiveSkillDict.Add(skill.ID, skill);
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
}
