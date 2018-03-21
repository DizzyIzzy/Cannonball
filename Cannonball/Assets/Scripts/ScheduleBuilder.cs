using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleBuilder : MonoBehaviour {
    public List<ScheduleItem> agentSchedule = new List<ScheduleItem>();

    public string nextMove;
    public float TOD;

    public Vector3 startPos;
    public Vector3 navTarget;
    

    public float speed = 100F;
    private float tripStartTime;
    private float journeyLength;
    public bool moving = false;
    public bool clockStarted = false;
    
    private void Start()
    {
        
        
    }

        private void Update()
    {
        TOD = CanadianRhythm.timeOfDay;
        executeMove();
        if (agentSchedule.Count>0)
          
        {
            nextMove = agentSchedule[0].action.ToString() + " @ " + MathHelpers.FloatToTime(agentSchedule[0].eventTime);
            checkHopper();
            if (agentSchedule[0].complete == true)
            {
                agentSchedule.RemoveAt(0);
                if (moving==false)
                TransferNavData();
            }
        }
        
    }

    private void TransferNavData()
    {
        if (agentSchedule.Count > 0)
        {
            startPos = agentSchedule[0].itemNavFromPos;
            navTarget = agentSchedule[0].itemNavTarget;
        }
    }

    private void checkHopper()
    {
     
        if (TOD > agentSchedule[0].eventTime && agentSchedule[0].complete == false)
        {
            moving = true;
            agentSchedule[0].complete = true;
        }
    }

    private void executeMove()
    {
 
        if (moving == true)
        {
            if (clockStarted == false)
            {
                tripStartTime = Time.time;
                journeyLength = Vector3.Distance(startPos, navTarget);
                clockStarted = true;
            }

            float distCovered = (Time.time - tripStartTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPos, navTarget, fracJourney);
            float distRemaining = Vector3.Distance(transform.position, navTarget);
            if (distRemaining < .2f)
            {
                moving = false;
                clockStarted = false;
                TransferNavData();
               // print("Trip was: " + distCovered + " units, and took: " + MathHelpers.FloatToTime(Time.time - tripStartTime));
            }
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
        TransferNavData();
    }



}
