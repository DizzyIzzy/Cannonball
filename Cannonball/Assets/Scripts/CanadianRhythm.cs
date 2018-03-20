using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanadianRhythm : MonoBehaviour {
    private float startTime;
    public float elapsedTime;
    public float timeScale =100 ;
    public static int calendarDay;
    public static float timeOfDay;

    private GUIStyle guiStyle = new GUIStyle();
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

   
        guiStyle.fontSize = 20;
 
        GUI.Label(new Rect(20, 30, 100, 20), ("Day: " + calendarDay.ToString()),guiStyle);
        GUI.Label(new Rect(20, 10, 120, 20), ("TOD: " + MathHelpers.FloatToTime(timeOfDay)),guiStyle);
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
