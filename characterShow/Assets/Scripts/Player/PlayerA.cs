using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : PlayerBase
{
    MoveManager moveManager = new MoveManager();
    private void Start()
    {
        this.PlayerInit();
        moveManager.MoveInit(animator);
        
    }
    void Update()
    {
        this.PlayerLive();
        moveManager.Moving();
    }
    public override void PlayerInit()
    {
        base.PlayerInit();

    }
    public override void PlayerLive()
    {
        base.PlayerLive();
    }
    public override void PlayerDead()
    {
        
    }
}
