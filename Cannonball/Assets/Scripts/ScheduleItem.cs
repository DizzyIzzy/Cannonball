using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleItem {
    public float eventTime;
    public string action;
    public int priority;
    public bool complete;
    public Vector3 itemNavFromPos;
    public Vector3 itemNavTarget;


    public ScheduleItem(float newTime, string newAction, int newPriority)
    {
        eventTime = newTime;
        action = newAction;
        priority = newPriority;
        complete = false;
    }

    public ScheduleItem(float newTime, string newAction, Vector3 navFromPos, Vector3 navTarget, int newPriority)
    {
        eventTime = newTime;
        action = newAction;
        priority = newPriority;
        complete = false;
        itemNavFromPos = navFromPos;
        itemNavTarget = navTarget;
        
    }

    public string ScheduleItemString()
    {
        string skedItemString = eventTime +"/"+ action + "/" + itemNavFromPos.ToString() + "/" + itemNavTarget.ToString() + "/" + itemNavTarget + "/" + priority;
        
        return skedItemString;
    }

}
