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
        KeyCode[] tempSkillsKey = { KeyCode.F1 , KeyCode.F2 , KeyCode.F3 , KeyCode.F4 , KeyCode.F5 , KeyCode.F6 , KeyCode.F7
                                    , KeyCode.F8 , KeyCode.F9 , KeyCode.F10};
        keyDatas = new ShortCutData(tempSkillsKey , KeyCode.B , KeyCode.M);

    }
}
