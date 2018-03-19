using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New cannonAgent", menuName = "cannonAgent")]
public class AgentTemplate1 : ScriptableObject {

    public string cannonAgent;
    public int gymDrive;
    public int beachDrive;
    public string homePlace;
    public string workPlace;
    public int sleepDrive;
    public int punctuality;
    public int cashResource;
    public int bodyWaste;
    public int foodCargo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
