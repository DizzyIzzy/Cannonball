using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu (fileName = "New Location", menuName = "3dLocation")]
public class LocationTemplate : ScriptableObject {

    public string locationName;
    public int xPos;
    public int zPos;

    public float workStartFloat;
    public float workEndFloat;


    public int foodStores;
    public int wasteAccumulation;
    public int cashReserve;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
