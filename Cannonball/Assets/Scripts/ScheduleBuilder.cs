using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleBuilder : MonoBehaviour {
    public List<ScheduleItem> agentSchedule = new List<ScheduleItem>();
    public ScheduleItem nextAction;
    public string nextActionString;

    public string hopper;
    public string hopper2;
    public bool scheduleUpdated;
    public bool nextActionReflector;

    public float TOD;
    
    private void Update()
    {
        TOD = CanadianRhythm.timeOfDay;
        hopper = agentSchedule[0].action.ToString() + " @ " + MathHelpers.FloatToTime(agentSchedule[0].eventTime);
        hopper2 = agentSchedule[1].action.ToString() + " @ " + MathHelpers.FloatToTime(agentSchedule[1].eventTime);
        nextActionReflector = nextAction.complete;
        if (nextAction.complete)
        {
            agentSchedule.RemoveAt(0);
            nextAction = agentSchedule[0];
            nextActionString = nextAction.eventTime + "/" + nextAction.action;
        }
        checkHopper();
    }

    private void checkHopper()
    {
        if (TOD > nextAction.eventTime && nextAction.complete == false)
        {
            print(name + ":" + nextAction.action + " @ " + MathHelpers.FloatToTime(TOD));
            nextAction.complete = true;
        }
    }

    public void printSchedule()
    {
        print(agentSchedule);
    }

    public void Refresh()
    {
        agentSchedule.Clear();
    }
    public void AddIn(ScheduleItem skedItem)
    {
            agentSchedule.Add(skedItem);
    }


}
