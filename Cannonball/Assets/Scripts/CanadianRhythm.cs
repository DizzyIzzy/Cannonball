using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanadianRhythm : MonoBehaviour {
    private float startTime;
    public float elapsedTime;
    public int timeScale =100 ;
    public static int calendarDay;
    public static float timeOfDay;
    // Use this for initialization
    private void Awake()
    {
        startTime = Time.time;
    }
    void Start () {
        calendarDay=1;
    }
	
	// Update is called once per frame
	void Update () {
        elapsedTime = (Time.time - startTime) ;
        timeOfDay = (elapsedTime*timeScale) % (24 );
        calendarDay = Mathf.CeilToInt((elapsedTime * timeScale) / 24);
    }

    void OnGUI() {
       GUI.Label(new Rect(300, 100, 100, 20), ("Day: " + calendarDay.ToString()));
       GUI.Label(new Rect(300, 40, 120, 20), ("TOD: " + (timeOfDay).ToString()));
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
