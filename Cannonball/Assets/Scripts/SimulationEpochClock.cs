using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimulationEpochClock : MonoBehaviour {
    public DateTime startDateTime;
    public static DateTime gameDateTime;
    
    public static float simDeltaTime;

    public float startTimeFloat;
    public float simDeltaTimeFloat;
    public float elapsedTime;
    public static float timeFactor;

    public string gameDateString;
    public TimeSpan simElapsed;
    public string simElapsedString;

    private GUIStyle guiStyle = new GUIStyle();

    // Use this for initialization
    void Start () {
        startDateTime = DateTime.Now;
        startTimeFloat = Time.time;
        gameDateTime = startDateTime;
    }
	
	// Update is called once per frame
	void Update () {
        float timeIncrement = (Time.deltaTime) * timeFactor;
        DateTime simDeltaBase = gameDateTime; 

        elapsedTime = elapsedTime + timeIncrement;
        double elapseDouble = elapsedTime;
        gameDateTime = startDateTime.AddSeconds(elapseDouble);
        gameDateString = gameDateTime.ToString();
        simDeltaTime = ((float)(gameDateTime.Subtract(simDeltaBase)).TotalMilliseconds)/1000f;
        simDeltaTimeFloat = simDeltaTime;
        simElapsed = gameDateTime.Subtract(startDateTime);
        simElapsedString = simElapsed.ToString();
        
            }
    public void AdjustTimeFactor(float timeSlider)
    {
        //makes the time slider a base 10 logarithmic scale 0=1:1 realtime flow, 1= 1:10 etc
        timeFactor = Mathf.Pow(10, timeSlider);
    }

    void OnGUI()
    {
        guiStyle.fontSize = 20;
        GUI.Label(new Rect(20, 10, 1000, 20), (gameDateTime.DayOfWeek.ToString()+ ", " + gameDateString),guiStyle);
        GUI.Label(new Rect(20, 40, 1000, 20), ("Elapsed simulation "  + simElapsed.TotalDays.ToString("000") + " / "+ simElapsedString));

    }

    public static DateTime SimulationEpochTime()
    {
        return gameDateTime;
    }

}
