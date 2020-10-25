using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : Singleton<GameDataManager>
{
    public GameFlowData flowData;

    private void Awake()
    {
        ManagerInit();
    }
    public void ManagerInit() {

        flowData = new GameFlowData();
        

    }
}
