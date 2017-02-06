using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gui : MonoBehaviour {
    public int deaths = 0;
    Text deathCounter;

    // Use this for initialization
    void Start () {
        deathCounter = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        deathCounter.text = "Number of Murders: " + deaths;
    }
}
