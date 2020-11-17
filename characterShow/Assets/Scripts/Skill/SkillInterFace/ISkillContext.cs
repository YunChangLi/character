using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillContext 
{
    GameObject player { get;set; }
    string ID { get; set; }
    void PrepareSkill();
    IEnumerator StartSkill();
    IEnumerator StopSkill();
}
