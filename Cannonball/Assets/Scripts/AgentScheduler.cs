using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AgentScheduler : MonoBehaviour {
    public DateTime simTime;
    public int homeHasGroceries;
    public float commute;
    public TimeSpan workStart;
    public TimeSpan workEnd;
    
//    public int dayOfWeek;
    public TimeSpan TOD;
    public DateTime date;
 //   public int calendarDay;
    public DateTime lastUpdate;

    private bool hasWorkTimes;
    public bool newDay =true;
    public bool homeNeedsGroceries = false;

    public AgentDataGrabber thisAgentData;



    // Use this for initialization
    void Start () {
        getTime();
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
        if (lastUpdate == null )
        { 
            PlanTheDay();
        }
        getTime();

      
    }
    private void getTime()
    {
        simTime = SimulationEpochClock.gameDateTime;
        TOD = simTime.TimeOfDay;
        //TOD = CanadianRhythm.timeOfDay;
        if (lastUpdate == null)
        {
            PlanTheDay();
        }
        
        if (lastUpdate.Date < simTime.Date && newDay == false)
        {
            newDay = true;
            PlanTheDay();
        }
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
    
        GetWorkTimes();

        int foodAtHome = thisAgentData.homePlaceTransform.GetComponent<LocationDataGrabber>().foodResource;
        int foodThreshold = thisAgentData.homePlaceTransform.GetComponent<LocationDataGrabber>().foodThreshold;
        if (foodAtHome < foodThreshold)
        {
            homeNeedsGroceries = true;
        }

        string dailySkedsTring = BuildSchedule(thisAgentData.agentName, workStart, workEnd, homeNeedsGroceries, false, false);
        print (dailySkedsTring);
        TextfileHandler.WriteString(dailySkedsTring);
        lastUpdate = simTime;
        newDay = false;
    }

    private string BuildSchedule(string agentName, TimeSpan workStart, TimeSpan workEnd, bool needsGroceries, bool needsGas, bool wannaPlay)
    {
        string outputSked = agentName + "'s plan, Day: " + simTime.ToShortDateString() + ". ";
        if (!(simTime.DayOfWeek == DayOfWeek.Saturday || simTime.DayOfWeek == DayOfWeek.Sunday))
        {
            TimeSpan breakfast = MathHelpers.FuzzyTime(workStart.Subtract(TimeSpan.FromHours(.75)),13);
            //TimeSpan lunch = MathHelpers.FuzzyTime(workStart.Add(TimeSpan.FromHours(5)), 20);
            //TimeSpan dinner = MathHelpers.FuzzyTime(lunch.Add(TimeSpan.FromHours(5)), 25); 
            //TimeSpan leaveHome = MathHelpers.FuzzyTime(workStart.Subtract(TimeSpan.FromMinutes(commute)), 4); 
            TimeSpan leaveWork = MathHelpers.FuzzyTime(workEnd, 4);

            //TimeSpan breakfast = workStart;
            TimeSpan lunch = workStart;
            TimeSpan dinner = workStart;
            TimeSpan leaveHome = workStart;
            //TimeSpan leaveWork = workEnd;
            string breakfastString = (breakfast).ToString();
            string leaveHomeString = (leaveHome).ToString();
            string lunchString = (lunch).ToString();
            string dinnerString = (dinner).ToString();
            string leaveWorkString = (leaveWork).ToString();
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
                ScheduleItem hopper4 = BuildScheduleItem(leaveWork.Add(TimeSpan.FromHours(.5f)), "Leave Groc to Home", new Vector3(8, 0, 7), thisAgentData.homePlaceTransform.position, 1);
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


    private ScheduleItem BuildScheduleItem(TimeSpan eventTime, string eventName, Vector3 from, Vector3 to, int priority )
    {
        ScheduleItem newScheduleItem = new ScheduleItem( eventTime,  eventName,  from,  to,  priority);
        return newScheduleItem;
    }


}
