using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingFlag : MonoBehaviour {
    public Text flagText;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        Vector3 flagPos = Camera.main.WorldToScreenPoint(this.transform.position);
        flagText.transform.position = flagPos;
	}
}
