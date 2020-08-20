using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowData 
{
    // Start is called before the first frame update
    public ShortCutData keyDatas;

    public  GameFlowData(ShortCutData keyDatas) 
    {

        this.keyDatas = keyDatas;

    }
    public GameFlowData() {
        keyDatas = new ShortCutData();
        keyDatas.Skill_1 = KeyCode.Alpha1;
        keyDatas.Skill_2 = KeyCode.Alpha2;
        keyDatas.Skill_3 = KeyCode.Alpha3;
        keyDatas.openBag = KeyCode.M;
        keyDatas.menu = KeyCode.Escape;
    }
}
