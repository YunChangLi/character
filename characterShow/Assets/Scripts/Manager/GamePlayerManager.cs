using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerManager : Singleton<GamePlayerManager>
{
    public PlayerBase Player { get; set; }
    public PlayerTaskController PTaskController { get; set; }

    public void ManagerInit() {
        Player = FindObjectOfType<PlayerBase>();
        
    }
    
}
