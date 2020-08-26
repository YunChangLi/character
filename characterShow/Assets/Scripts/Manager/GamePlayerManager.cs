using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerManager : Singleton<GamePlayerManager>
{
    public PlayerBase player { get; set; }
    public playerInput input { get; set; }

    public void ManagerInit() {
        player = FindObjectOfType<PlayerBase>();
        input = FindObjectOfType<playerInput>();
    }
    
}
