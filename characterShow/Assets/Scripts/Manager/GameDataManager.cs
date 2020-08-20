using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : Singleton<GameDataManager>
{
    public GameFlowData flowData;
    public void init() {

        flowData = new GameFlowData();
        

    }
}
