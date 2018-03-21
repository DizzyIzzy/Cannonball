using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BehaviorDriver : MonoBehaviour {
   
    public int hunger;
    public int fatigue;
    public int bladder;
    public int social;
    public int homeHasGroceries;
    public float commute;
    public float workStart;
    public float workEnd;
    public int dayOfWeek;
    public float TOD;
    public int calendarDay;
    public int myCalendar=0;

    private bool hasWorkTimes;
    public bool newDay =true;
    public bool homeNeedsGroceries = false;

    public AgentDataGrabber thisAgentData;
    // Use this for initialization
    void Start () {
        getTime();
     //   thisAgentData = gameObject.GetComponent<AgentDataGrabber>();
    }
	
	// Update is called once per frame
	void Update () {
        if (thisAgentData == null)
        {
            thisAgentData = gameObject.GetComponent<AgentDataGrabber>();
        }
        if (!hasWorkTimes && thisAgentData != null)
        {
            GetWorkTimes();
        }
        if (calendarDay ==0 )
        { UpdateCalendar();
            PlanTheDay();
        }
        getTime();

      
    }
    private void getTime()
    { 
        TOD = CanadianRhythm.timeOfDay;
        if (myCalendar == 0)
        {
            UpdateCalendar();
        }
        
        if (myCalendar < CanadianRhythm.calendarDay && newDay == false)
        {
            newDay = true;
            PlanTheDay();
        }
    }

    private void UpdateCalendar()
    {
        calendarDay = CanadianRhythm.calendarDay;
        dayOfWeek = (calendarDay % 7);
    }

    private void GetWorkTimes()
    {
        workStart = thisAgentData.workPlaceTransform.GetComponent<LocationDataGrabber>().workStartTime;
        workEnd = thisAgentData.workPlaceTransform.GetComponent<LocationDataGrabber>().workEndTime;
        commute = thisAgentData.commuteDistance*.016f;
        hasWorkTimes = true;
    }

    private void PlanTheDay()
    {
        UpdateCalendar();
        GetWorkTimes();

        int foodAtHome = thisAgentData.homePlaceTransform.GetComponent<LocationDataGrabber>().foodResource;
        int foodThreshold = thisAgentData.homePlaceTransform.GetComponent<LocationDataGrabber>().foodThreshold;
        if (foodAtHome < foodThreshold)
        {
            homeNeedsGroceries = true;
        }

        string dailySkedsTring = BuildSchedule(thisAgentData.agentName, workStart, workEnd, homeNeedsGroceries, false, false);
        print (dailySkedsTring);
        
        myCalendar = calendarDay;
        newDay = false;
    }

    private string BuildSchedule(string agentName, float workStart, float workEnd, bool needsGroceries, bool needsGas, bool wannaPlay)
    {
        string outputSked = agentName + "'s plan, Day: " + calendarDay + ". ";
        if (dayOfWeek < 5)
        {
            float breakfast = workStart - MathHelpers.Fuzzify(.7f);
            float lunch = breakfast + MathHelpers.Fuzzify(5f);
            float dinner = lunch + MathHelpers.Fuzzify(5f, 10f);
            float leaveHome = workStart - MathHelpers.Fuzzify(commute);
            float leaveWork = MathHelpers.Fuzzify(workEnd);
            string breakfastString = MathHelpers.FloatToTime(breakfast).ToString();
            string leaveHomeString = MathHelpers.FloatToTime(leaveHome).ToString();
            string lunchString = MathHelpers.FloatToTime(lunch).ToString();
            string dinnerString = MathHelpers.FloatToTime(dinner).ToString();
            string leaveWorkString = MathHelpers.FloatToTime(leaveWork).ToString();
            if (homeNeedsGroceries)
            {
                leaveWorkString = leaveWorkString + " and get groceries";
            }
            //build the sequence of events as a string
            outputSked = (outputSked + " Breakfast: " + breakfastString + "Leave for Work at:" + leaveHomeString + " Lunch: " + lunchString + " Dinner: " + dinnerString + " Leave work at:" + leaveWorkString);

            //clear the last day's schedule
            gameObject.GetComponent<ScheduleBuilder>().Refresh();
            //build and populate the schedule items from recurring schedule items
            ScheduleItem hopper1 = BuildScheduleItem(leaveHome, "Leave Home", thisAgentData.homePlaceTransform.position, thisAgentData.workPlaceTransform.position, 1);
     
            gameObject.GetComponent<ScheduleBuilder>().AddIn(hopper1);

            if (!homeNeedsGroceries)
            {
                ScheduleItem hopper2 = BuildScheduleItem(leaveWork, "Leave Work to Home", thisAgentData.workPlaceTransform.position, thisAgentData.homePlaceTransform.position, 1);
                gameObject.GetComponent<ScheduleBuilder>().AddIn(hopper2);
            }
            else
            {
                //uses hard code location for grocery - need to change to data driven
                ScheduleItem hopper3 = BuildScheduleItem(leaveWork, "Leave Work to Grocery", thisAgentData.workPlaceTransform.position, new Vector3 (8,0,7), 1);
                gameObject.GetComponent<ScheduleBuilder>().AddIn(hopper3);
                //uses hard code location for grocery - need to change to data driven
                //uses hard code time for grocery time duration - need to change to data driven
                ScheduleItem hopper4 = BuildScheduleItem(leaveWork+.5f, "Leave Groc to Home", new Vector3(8, 0, 7), thisAgentData.homePlaceTransform.position, 1);
                gameObject.GetComponent<ScheduleBuilder>().AddIn(hopper4);
            }

         
        }
        else
        {
            string partyPlan ;
            int choice = MathHelpers.MakeAChoice(1, 4);
            switch (choice)
            {
                case 1:
                    partyPlan = "beach";
                    break;
                case 2:
                    partyPlan = "bar";
                    break;
                case 3:
                    partyPlan = "houseparty";
                    break;

                default:
                    partyPlan = "movies";
                    break;
            }
            outputSked = outputSked + partyPlan;
        }
        return outputSked;
    }


    private ScheduleItem BuildScheduleItem(float eventTime, string eventName, Vector3 from, Vector3 to, int priority )
    {
        ScheduleItem newScheduleItem = new ScheduleItem( eventTime,  eventName,  from,  to,  priority);
        return newScheduleItem;
    }


}
