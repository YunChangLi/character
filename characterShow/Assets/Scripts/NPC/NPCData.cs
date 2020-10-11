using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new NPC", menuName = "Create a New NPC Data")]
public class NPCData : ScriptableObject
{
    public Vector3 Location;
    public string NPCName;
    public string NPCID;

    public void SetNPCID(string npcId) 
    {
        this.NPCID = npcId;
    }
}
