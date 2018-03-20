using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class NavigateOnTime : MonoBehaviour
{

    public float TOD;
    public List<ScheduleItem> mySchedule;
    public ScheduleItem nextAction;
    public float nextTime;
    public string nextActionString;
    public bool scheduleUpdated;

    // Use this for initialization
    void Start()
    {
      
    }
    
    // Update is called once per frame
    void Update()
    {
        getTime();
        if (TOD> nextAction.eventTime && nextAction.complete == false)
        {
            print(name + ":" + nextAction.action + " @ " + MathHelpers.FloatToTime(TOD));
            nextAction.complete = true;

        }
    }
    private void getTime()
    {
        TOD = CanadianRhythm.timeOfDay;
    }
}
