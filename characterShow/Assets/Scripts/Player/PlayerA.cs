using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerA : PlayerBase
{
    
    private void Start()
    {
        this.PlayerInit();

        
    }
    void Update()
    {
        this.PlayerLive();
        //moveManager.Moving();
        
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
