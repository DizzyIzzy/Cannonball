using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    public Vector3 navTarget;
    public Vector3 startPos;

    public float speed = 100F;
    private float tripStartTime;
    private float journeyLength;
    public bool moving = false;
    public bool clockStarted = false;
    void Start()
    {
   
    }
    void Update()
    {
        if (moving == true)
        {
            if (clockStarted == false)
            {
                tripStartTime = Time.time;
                journeyLength = Vector3.Distance(startPos, navTarget);
                clockStarted = true;
            }


            float distCovered = (Time.time - tripStartTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPos, navTarget, fracJourney);
            float distRemaining = Vector3.Distance(transform.position, navTarget);
            if (distRemaining < .2f)
            {
                moving = false;
                clockStarted = false;
            }
        }
    }

    public void MoveOut(Vector3 startFrom, Vector3 navTo)
    {
        moving = true;
        navTarget = navTo;
        startPos = startFrom;
        tripStartTime = Time.time;
        journeyLength = Vector3.Distance(startPos, navTarget);
    }
}