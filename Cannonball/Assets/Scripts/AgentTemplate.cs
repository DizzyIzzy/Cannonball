using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New cannonAgent", menuName = "cannonAgent")]
public class AgentTemplate: ScriptableObject {

    public int cannonAgentSerial;
    public string cannonAgentName;
    public float socialDrive;
    public int extroversion;
    public int libido;
    public int gymDrive;
    public int beachDrive;
    public string homePlace;
    public string workPlace;
    public int sleepDrive;
    public int punctuality;
    public int cashResource;
    public string licensePlate;
    public string cellPhoneNumber;
    public int bodyWaste;
    public int foodCargo;
    public AgentTemplate partner;
  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
   

}
