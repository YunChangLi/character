using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Skill Data" , menuName = "New Skill Data")]
public class SkillData : ScriptableObject
{
    public int coolDownSec;
    public Animator animator;
    public Sprite skillPhoto;
}
