using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationDataGrabber : MonoBehaviour {
    public Text text;
    public LocationTemplate locationData;
    public string locName;
    public Vector3 positionData;
    public Transform locationTransform;
    public float workStartTime;
    public float workEndTime;
    public List<string> occupants = new List<string>();

    public int foodResource;
    public int foodThreshold;

    // Use this for initialization
    void Start () {
        locName = locationData.locationName;
        text.text = locName;
        positionData = new Vector3(locationData.xPos, 0, locationData.yPos);
        gameObject.transform.position = positionData;
        workStartTime = locationData.workStart;
        workEndTime = locationData.workEnd;
        foodResource = locationData.foodStores;
        foodThreshold = 8;




    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
