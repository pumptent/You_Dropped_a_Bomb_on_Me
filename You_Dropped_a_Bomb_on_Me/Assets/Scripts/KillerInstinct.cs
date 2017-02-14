using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerInstinct : MonoBehaviour {
    public GameObject[] victims;
    public int numberOfVictims;
    public GameObject myVictim;
    public GameObject watcher;
    public int speed;
    
	// Use this for initialization
	void Start () {
        victims = GameObject.FindGameObjectsWithTag("Victim");
        watcher = GameObject.FindGameObjectWithTag("Player");
        numberOfVictims = victims.Length;
        myVictim = victims[0];
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, myVictim.transform.position, speed * Time.deltaTime);
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
                transform.position = new Vector3(transform.position.x, myVictim.transform.position.y, transform.position.z);
            }
        }
    }
}
