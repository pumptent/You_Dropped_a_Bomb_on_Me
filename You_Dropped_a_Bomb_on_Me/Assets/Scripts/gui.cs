using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gui : MonoBehaviour {
    public int deaths = 0;
    private bool beginning;
    Text deathCounter;

    // Use this for initialization
    void Start () {
        deathCounter = GetComponent<Text>();
        beginning = true;
        Invoke("changeUI", 5);
    }
	
	// Update is called once per frame
	void Update () {
        if(beginning)
        {
            deathCounter.text = "He's in the other building. Keep watching.";
        }
        else
        {
            deathCounter.text = "Number of Murders: " + deaths;
        }
        if (deaths == -1)
            deathCounter.text = "He got them all.";


    }

    void changeUI()
    {
        beginning = false;
        
    }
}
