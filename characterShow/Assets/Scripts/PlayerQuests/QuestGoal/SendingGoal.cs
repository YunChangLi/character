using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendingGoal : QuestGoal
{
    //物品將要交由哪位NPC
    public NPCData TargetNPC;
    //要運送什麼物品
    public Item TargetItem;
    public bool NPCAccept { get; set; }
    public SendingGoal( NPCData targetNPC , Item targetItem) : base()
    {
        this.TargetNPC = targetNPC;
        this.TargetItem = targetItem;
        NPCAccept = false;
    }
    public void AcceptItem() 
    {
        NPCAccept = true;
    }
    public override bool CheckTaskFinished()
    {
        if (NPCAccept)
            return true;
        else
            return false;
    }
}
