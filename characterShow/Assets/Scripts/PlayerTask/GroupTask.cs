using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// NPC 可能不只給一個Task 
/// </summary>
public class GroupTask : Task
{
    public List<Task> SubTaskList = new List<Task>();
}
