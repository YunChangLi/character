using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public List<QuestEvent> QuestEvents = new List<QuestEvent>();
    //List<QuestEvent> pathList = new List<QuestEvent>();

    public QuestEvent AddQuestEvent(string name, string des)
    {
        QuestEvent questEvent = new QuestEvent(name, des);
        QuestEvents.Add(questEvent);
        return questEvent;
    }
    public void AddPath(string fromQuestEventId, string toQuestEventId)
    {
        QuestEvent from = FindQuestEvent(fromQuestEventId);
        QuestEvent to = FindQuestEvent(toQuestEventId);

        if (from != null && to != null)
        {
            QuestPath p = new QuestPath(from, to);
            from.pathList.Add(p);
        }

    }
    public QuestEvent FindQuestEvent(string id)
    {
        foreach (QuestEvent e in QuestEvents)
        {
            if (e.GetID() == id)
                return e;
        }
        return null;
    }
}
