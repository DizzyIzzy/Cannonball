using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AgentMazlow : MonoBehaviour {
    public AgentDataGrabber thisAgentData;
    private Transform partnerTransform;
    public DateTime lastCall;
    public float socialDrive;
    public float socialState;
    public float socialThreshold;
    public string partnerName;
    public float partnerDistance;
    // public int extroversion;
    //  public int libido;
    //   public int gymDrive;
    //   public int beachDrive;
    //   public string homePlace;
    //   public int sleepDrive;
    //   public int punctuality;
    public int cashResource;
  //  public int bodyWaste;
    public int foodCargo;
    public float stepTime;
    public bool hasPartner;

    public Vector3 partnerPos;
    // Use this for initialization
    void Start () {
        socialState = 1000;
        socialThreshold = 900;
    }


    // Update is called once per frame
    void Update() {
        if (thisAgentData == null)
        {
            thisAgentData = gameObject.GetComponent<AgentDataGrabber>();
            socialDrive = thisAgentData.socialDrive;
            if (thisAgentData.hasPartner)
            {
                partnerName = thisAgentData.partnerName;
                partnerTransform = thisAgentData.partnerTransform;
                hasPartner = true;
            }
        }
        stepTime = Mathf.Clamp(SimulationEpochClock.simDeltaTime * 0.001f,0,500);
        if (hasPartner)
        {
            partnerDistance = Vector3.Distance(transform.position, partnerPos);
        }
        lonelyJack();
    }

        void lonelyJack()
        {
       socialState = socialState - (socialDrive * stepTime);
        if (socialState < socialThreshold)
        {
            partnerPos = thisAgentData.partnerPosition;
            partnerDistance = Vector3.Distance(transform.position, partnerPos);
            if (partnerDistance<1)
            {
                socialState = socialState + (stepTime);
            }

            if (hasPartner)
            {
                
                PhoneAFriend();
            }
        }

        }
    
        void PhoneAFriend()
    {
        
        string callDateTime = SimulationEpochClock.gameDateTime.ToLocalTime().ToString();
        string callLog =(thisAgentData.agentName + " called " + partnerName + " at " + callDateTime);
        TextfileHandler.PhoneLog(callLog, thisAgentData.agentName);
        lastCall = SimulationEpochClock.gameDateTime;
        print(callLog);
        socialState = socialState + MathHelpers.Fuzzify(100);
        float partnerSocialState = partnerTransform.GetComponent<AgentMazlow>().socialState;
        partnerSocialState = partnerSocialState + MathHelpers.Fuzzify(50);
    }
}
