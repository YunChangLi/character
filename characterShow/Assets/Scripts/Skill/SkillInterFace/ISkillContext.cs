using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillContext 
{
    string ID { get; set; }
    void PrepareSkill();
    void StartSkill();
    void StopSkill();
}
