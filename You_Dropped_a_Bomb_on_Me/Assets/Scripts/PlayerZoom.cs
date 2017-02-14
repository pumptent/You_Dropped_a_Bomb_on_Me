using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoom : MonoBehaviour {
    public bool zoomed;
    public int zoomStrength;
    private GameObject myCamera;
	// Use this for initialization
	void Start () {
        zoomed = false;
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2"))
        {
            if (zoomed)
            {
                zoomed = false;
                myCamera.GetComponent<Camera>().fieldOfView = 60;
            }
            else
            {
                zoomed = true;
                myCamera.GetComponent<Camera>().fieldOfView = zoomStrength;
            }
        }
        
	}
}
