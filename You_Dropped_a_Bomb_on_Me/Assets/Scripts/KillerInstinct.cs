using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerInstinct : MonoBehaviour {
    public GameObject[] victims;
    public int numberOfVictims;
    public GameObject myVictim;
    public GameObject watcher;
    public int speed;
    private GameObject lights;

    // Use this for initialization
    void Start () {
        lights = GameObject.FindGameObjectWithTag("Lights");
        victims = GameObject.FindGameObjectsWithTag("Victim");
        watcher = GameObject.FindGameObjectWithTag("Player");
        numberOfVictims = victims.Length;
        myVictim = victims[0];
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, myVictim.transform.position, speed * Time.deltaTime);
    }

    public void lightsOn()
    {
        if(lights != null)
            lights.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag.Equals("Victim"))
        {
            if (!gameObject.GetComponent<Renderer>().isVisible || !watcher.GetComponent<PlayerZoom>().zoomed)
            {
                collision.gameObject.SetActive(false);
                victims = GameObject.FindGameObjectsWithTag("Victim");
                numberOfVictims = victims.Length;
                if (numberOfVictims != 0)
                    myVictim = victims[0];
                
                GameObject.FindGameObjectWithTag("GameController").GetComponent<gui>().deaths++;
                if (numberOfVictims == 0)
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<gui>().deaths = -1;
            }
            if (numberOfVictims != 0)
            {
                int nextVictim = Mathf.RoundToInt(Random.Range(0, numberOfVictims));
                myVictim = victims[nextVictim];
                if(transform.position.y + 2 < myVictim.transform.position.y - 1 || transform.position.y + 2 > myVictim.transform.position.y + 1)
                {
                    GameObject lights = GameObject.FindGameObjectWithTag("Lights");
                    if(lights != null)
                    {
                        lights.SetActive(false);
                        Invoke("lightsOn", .5f);
                    }
                        
                    transform.position = new Vector3(transform.position.x, myVictim.transform.position.y + 2, transform.position.z);
                    
                }
                else
                {
                    Debug.Log(transform.position + " " + myVictim.transform.position);
                }
            }
        }
    }
}
