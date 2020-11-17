using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerManager : Singleton<GamePlayerManager>
{
    public GameObject Player { get; set; }

    public override void Awake()
    {
        base.Awake();
        ManagerInit();
    }
    public void ManagerInit() {
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }
    
}
