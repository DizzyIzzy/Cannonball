using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LocationDataGrabber : MonoBehaviour {
    public Text text;
    public LocationTemplate locationData;
    public string locName;
    public Vector3 positionData;
    public Transform locationTransform;
    
    public TimeSpan workStartTime;
  

    public TimeSpan workEndTime;
    public TimeSpan workStart;
    public string workStartString;
    public string workEndString;
    public TimeSpan workEnd;

    public List<string> occupants = new List<string>();

    public int foodResource;
    public int foodThreshold;

    // Use this for initialization
    void Start () {
        locName = locationData.locationName;
        text.text = locName;
        positionData = new Vector3(locationData.xPos, 0, locationData.zPos);
        gameObject.transform.position = positionData;
        workStartTime = TimeSpan.FromHours(locationData.workStartFloat);

        workEndTime = TimeSpan.FromHours(locationData.workEndFloat);

        workStartString = workStartTime.ToString();
        workEndString = workEndTime.ToString();

        foodResource = locationData.foodStores;
        foodThreshold = 8;




    }
	
	// Update is called once per frame
	void Update () {
       // workStartString = workStartTime.ToString();

    }
}
