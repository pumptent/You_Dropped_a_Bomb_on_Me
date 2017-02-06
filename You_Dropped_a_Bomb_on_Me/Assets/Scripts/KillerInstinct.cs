using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerInstinct : MonoBehaviour {
    public GameObject[] victims;
    public int numberOfVictims;
    public GameObject myVictim;
    public int speed;
    
	// Use this for initialization
	void Start () {
        victims = GameObject.FindGameObjectsWithTag("Victim");
        numberOfVictims = victims.Length;
        myVictim = victims[0];
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, myVictim.transform.position, speed * Time.deltaTime);
        if (gameObject.GetComponent<Renderer>().isVisible)
        {
            Debug.Log("i see");
        }
        else
            Debug.Log("i dont see");
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag.Equals("Victim"))
        {

            if (!gameObject.GetComponent<Renderer>().isVisible)
            {
                victims = GameObject.FindGameObjectsWithTag("Victim");
                myVictim = victims[0];
                numberOfVictims = victims.Length;

                collision.gameObject.SetActive(false);
                GameObject.FindGameObjectWithTag("GameController").GetComponent<gui>().deaths++;
            }
            else
            {

                //your plans were foiled. pick a new victim
                int nextVictim = Mathf.RoundToInt(Random.Range(0, numberOfVictims));
                myVictim = victims[nextVictim];
            }
        }
    }
}
