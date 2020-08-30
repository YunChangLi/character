using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerManager : Singleton<GamePlayerManager>
{
    public GameObject Player { get; set; }
    

    public void ManagerInit() {
        //Player = FindObjectOfType<PlayerBase>();
        
    }
    
}
