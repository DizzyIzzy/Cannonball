using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentDataGrabber : MonoBehaviour {
  
    public Text flagText;
    public AgentTemplate1 agentData;
    public string agentName;
    public string agentWorksAt;
    public string agentLivesAt;
    public Vector3 positionData;
    public Vector3 homeAddress;
    public Vector3 workAddress;
    public bool workFound;
    public bool homeFound;
    public bool distCalculated;
    private FloatingFlag flagPole;
    private GameObject locationLibrary;
    public float commuteDistance;

    public Transform workPlaceTransform;
    public Transform homePlaceTransform;


    // Use this for initialization

    void Start () {
      
        locationLibrary = GameObject.Find("Locations");
        flagPole = gameObject.GetComponentInChildren<FloatingFlag>();
        flagText = flagPole.flagText;
        agentName = agentData.cannonAgent;
        gameObject.name = agentName;
        flagText.text = agentName;
        agentWorksAt = agentData.workPlace;
        agentLivesAt = agentData.homePlace;
    
        workPlaceTransform = locationLibrary.transform.Find(agentWorksAt);
        homePlaceTransform = locationLibrary.transform.Find(agentLivesAt);


    //TODO
    //find workplace as gameObject
    //get location of work as vector

    //get location of home as vector
    //calculate commute
}

    // Update is called once per frame
    void Update()
    {
        if (workPlaceTransform == null)
        {
            workPlaceTransform = locationLibrary.transform.Find(agentWorksAt);
        }

        homePlaceTransform = locationLibrary.transform.Find(agentLivesAt);
        if (workAddress == Vector3.zero)
        {
            GetWorkAddress();
        }
        if (homeAddress == Vector3.zero)
        {
            GetHomeAddress();
        }
        if (homeFound && !distCalculated)
        {
            CalculateCommute();
        }
    }

    private void GetWorkAddress()
    {
        if (workPlaceTransform != null)
        {
            float x = workPlaceTransform.position.x;
            float z = workPlaceTransform.position.z;
            workAddress = new Vector3(x, 0, z);
            workFound = true;
        }
    }
    private void GetHomeAddress()
    {
        float x = homePlaceTransform.position.x;
        float z = homePlaceTransform.position.z;
        homeAddress = new Vector3(x, 1, z);
        homeFound = true;
        transform.position = homeAddress;
        homePlaceTransform.GetComponent<LocationDataGrabber>().occupants.Add(agentName);
    }
    private void CalculateCommute()
    {
        commuteDistance = Vector3.Distance(workAddress,homeAddress);
        distCalculated = true;
    }
}
