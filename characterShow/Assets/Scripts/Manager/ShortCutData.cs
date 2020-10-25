using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ShortCutData
{
    public KeyCode[] skillsShortCut = new KeyCode[10];
    public KeyCode openBag;
    public KeyCode menu;

    public ShortCutData(KeyCode[] skillsKey , KeyCode openBagKey , KeyCode menuKey)
    {
        skillsShortCut = skillsKey;
        openBag = openBagKey;
        menu = menuKey;
    }



}
