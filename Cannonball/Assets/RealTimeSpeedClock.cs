using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RealTimeSpeedClock : MonoBehaviour {
    public DateTime startDateTime;
    public DateTime gameDateTime;

    public float startTimeFloat;
    public float elapsedTime;
    public float timeFactor;

    public string gameDateString;
    public TimeSpan simElapsed;
    public string simElapsedString;

    private GUIStyle guiStyle = new GUIStyle();

    // Use this for initialization
    void Start () {
        startDateTime = DateTime.Now;
        startTimeFloat = Time.time;
        
    }
	
	// Update is called once per frame
	void Update () {
        float timeIncrement = (Time.deltaTime) * timeFactor;
        elapsedTime = elapsedTime + timeIncrement;
        double elapseDouble = elapsedTime;
       
        gameDateTime = startDateTime.AddSeconds(elapseDouble);
        gameDateString = gameDateTime.ToString();
        simElapsed = gameDateTime.Subtract(startDateTime);
        simElapsedString = simElapsed.ToString();

    }

    void OnGUI()
    {
        guiStyle.fontSize = 20;
        GUI.Label(new Rect(20, 50, 1000, 20), ("GameDay: " + gameDateString));
        GUI.Label(new Rect(20, 80, 1000, 20), ("SimDay: "  + simElapsed.TotalDays.ToString("00") + "/SimRunning: "+ simElapsedString));

    }
}
