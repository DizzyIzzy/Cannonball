using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class NavigateOnTime : MonoBehaviour
{

    public float TOD;
    public List<ScheduleItem> planOfTheDay;
    public ScheduleItem nextAction;
    public float nextTime;
    public string nextActionString;
    

    // Use this for initialization
    void Start()
    {
        ScheduleItem item1 = new ScheduleItem(8f, "dang", 2);
        ScheduleItem item2 = new ScheduleItem(15f, "pop", 3);
        //        planOfTheDay.Add(new ScheduleItem(item1.eventTime,item1.action,item1.p);

        nextAction = item1;
        QueueAction();
        print(nextAction + "/" + nextTime + nextActionString);
    }

    private void QueueAction()
    {
        nextTime = nextAction.eventTime;
        nextActionString = nextAction.action;
    }

    // Update is called once per frame
    void Update()
    {
        getTime();
        if (TOD> nextAction.eventTime && nextAction.complete == false)
        {
            print(name + ":" + nextAction.action + " @ " + MathHelpers.FloatToTime(TOD));
            nextAction.complete = true;
            nextAction = new ScheduleItem(15f, "pop", 3);
            QueueAction();
        }
    }
    private void getTime()
    {
        TOD = CanadianRhythm.timeOfDay;
    }
}
