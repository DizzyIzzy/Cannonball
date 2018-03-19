using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleBuilder : MonoBehaviour {
    public List<ScheduleItem> dayPlanner = new List<ScheduleItem>();
    public string hopper;
    public string hopper2;


    private void Update()
    {
        hopper = dayPlanner[0].action.ToString() + " @ " + MathHelpers.FloatToTime(dayPlanner[0].eventTime) ;
        hopper = dayPlanner[1].action.ToString() + " @ " + MathHelpers.FloatToTime(dayPlanner[1].eventTime);
    }
    public void printSchedule()
    {
        print(dayPlanner);
    }
    public void Refresh()
    {
       dayPlanner.Clear();
    }
}
