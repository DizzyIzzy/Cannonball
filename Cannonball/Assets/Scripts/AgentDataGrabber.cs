using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgentDataGrabber : MonoBehaviour {
  
    public Text flagText;
    public AgentTemplate agentData;
    public AgentTemplate partnerData;

    public string agentName;
    public string agentWorksAt;
    public string agentLivesAt;
    public float socialDrive;
    public string partnerName;
    public Vector3 positionData;
    public Vector3 homeAddress;
    public Vector3 workAddress;
    public Vector3 partnerPosition;
    public bool workFound;
    public bool homeFound;
    public bool distCalculated;
    public bool hasPartner;
    
    private GameObject locationLibrary;
    public float commuteDistance;

    public Transform workPlaceTransform;
    public Transform homePlaceTransform;

    public Transform partnerTransform;
    bool partnerInfo=false;

    // Use this for initialization

    void Start () {
      
        locationLibrary = GameObject.Find("Locations");
    
        agentName = agentData.cannonAgentName;
        gameObject.name = agentName;
        flagText.text = agentName;
        agentWorksAt = agentData.workPlace;
        agentLivesAt = agentData.homePlace;
        socialDrive = agentData.socialDrive;
        if (partnerData != null)
        {
            hasPartner = true;
            partnerName = partnerData.cannonAgentName;
        }
        workPlaceTransform = locationLibrary.transform.Find(agentWorksAt);
        homePlaceTransform = locationLibrary.transform.Find(agentLivesAt);
        }

    // Update is called once per frame
    void Update()
    {
        if (workPlaceTransform == null || workPlaceTransform ==null)
        {
            workPlaceTransform = locationLibrary.transform.Find(agentWorksAt);
            homePlaceTransform = locationLibrary.transform.Find(agentLivesAt);
        }

   
        if (partnerInfo == false)
        {
            if (partnerData != null)
            {
                partnerTransform = GameObject.Find(partnerName).transform;
                partnerPosition = partnerTransform.position;
                hasPartner = true;
                partnerInfo = true;
            }
        }
       

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
