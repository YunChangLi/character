using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPath 
{
    public QuestEvent StartEvent;   //get start in a path
    public QuestEvent EndEvent;     //get end in a path

    public QuestPath(QuestEvent from, QuestEvent to)
    {
        StartEvent = from;
        EndEvent = to;
    }
}
