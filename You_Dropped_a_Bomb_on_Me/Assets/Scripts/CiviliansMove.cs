using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiviliansMove : MonoBehaviour {
    private Vector3 pointA;
    public Vector3 pointB;
    public float speed;
    private Vector3 destination;
	// Use this for initialization
	void Start () {
        pointA = transform.position;
        destination = pointB;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position == pointA)
        {
            destination = pointB;
        }

        if (transform.position == pointB)
        {
            destination = pointA;
        }
        transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
    }
}
