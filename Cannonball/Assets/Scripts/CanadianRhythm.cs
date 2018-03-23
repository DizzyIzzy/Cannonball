using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanadianRhythm : MonoBehaviour {
    private float startTime;
    public float elapsedTime;
    public DateTime realTimeticks;
    public float startTicks;
    public float elapsedTicks;


    public static float timeScale;
    public static int calendarDay;
    public static int dayOfWeek;
    public static float timeOfDay;
    

    private GUIStyle guiStyle = new GUIStyle();
    // Use this for initialization
    private void Awake()
    {
        startTime = Time.time;
        startTicks = DateTime.Now.Ticks;
    }
    void Start () {
        calendarDay=1;
        timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
       
        elapsedTime = (Time.time - startTime) ;
        timeOfDay = (elapsedTime*timeScale) % (24 ) ;
        calendarDay = Mathf.CeilToInt((elapsedTime * timeScale) / 24);
        dayOfWeek = calendarDay % 7;

    
    }

    void OnGUI() {
    
        guiStyle.fontSize = 20;
        GUI.Label(new Rect(20, 10, 120, 20), ("TOD: " + MathHelpers.FloatToTime(timeOfDay)),guiStyle);
     //   GUI.Label(new Rect(20, 30, 100, 20), ("Day: " + calendarDay.ToString()) + "/" + weekday, guiStyle);
    }

    public static float GameTime()
    {
        return timeOfDay;
    }
    public static float GameDay()
    {
        return calendarDay;
    }


  

}
