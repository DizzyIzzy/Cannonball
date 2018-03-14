using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fatigue : MonoBehaviour {

    private float forceTimeFactor = 10000;
    private float wakeUpTime;
    private float dayCount =0 ;

    private float startTime;
    private float elapsedTime;
    private float timeOfDay;
    private float fatigue;
    private float fatigueBase = 7f;
    private float recoveryBase = 12f;
    private float fatigueFactor ;
    private float recoveryFactor ;
    private float sleepThreshold;
    private float next_gaussian;



    private bool sleeping;
    private string sleepState;

    private float wakeTime = 6.5f;
    
    private float bedTime = 21.5f;
    private float wakeTarget ;
    private float wakeTimeShift=0;
    private float bedTarget;
    private float bedTimeShift=0;
    private bool uselast = false;

    void Awake()
    {
        startTime = 0;
        print("Today is " + dayCount);
        bedTarget = bedTime;
    }
    // Use this for initialization
    void Start () {
     sleeping = false;
    }

    // Update is called once per frame
    void Update() {
       
        elapsedTime = Time.time*forceTimeFactor - startTime;
        timeOfDay = ((wakeUpTime + elapsedTime) / 3600) % 24;

        dayCount = Mathf.Ceil((wakeUpTime + elapsedTime) / (3600*24));

        if (timeOfDay >= bedTarget && sleeping == false) 
        {
            goToSleep();
        }
        else if (timeOfDay > wakeTarget && sleeping == true)
        {
            wakeyWakey();
        }
    }


    void goToSleep()
    {
        if (sleeping == false)
        {
            sleeping = true;
            sleepState = "zzzz";
            wakeTimeShift = Random.Range(-1.5f, 1.5f);
            wakeTarget = wakeTime + wakeTimeShift;
            print("Good night, It's: " + timeOfDay + " o' clock. I'll wake up at: " + wakeTarget);
            
        }

    }
    void wakeyWakey()
    {
        if (sleeping == true)
        {
            sleeping = false;
            sleepState = "awake";
            bedTimeShift = Random.Range(-1.5f, 1.5f);
            bedTarget = bedTime + bedTimeShift;
            print("Good morning, day: " + dayCount + " It's: " + timeOfDay + " . I'll go to bed at: " + bedTarget);
            
        }
        }
    void OnGUI()
    {
        GUI.Label(new Rect(300, 100, 100, 20), ("Time: " + elapsedTime.ToString()));
        GUI.Label(new Rect(300, 40, 120, 20), ("TOD: " + (timeOfDay).ToString()));
        GUI.Label(new Rect(300, 20, 120, 20), ("Bedtarget:" + (bedTarget).ToString()));
        GUI.Label(new Rect(300, 10, 120, 20), ("Waketarget:" + (wakeTarget).ToString()));
        GUI.Label(new Rect(300, 60, 120, 20), (sleepState));
    }
}
