using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

   
    public VirtualJoystick jsMovement;
    public Transform player;
    public float moveSpeed = .00005f;
    Vector3 desiredPosition;

	// Use this for initialization
	void Start () {
        desiredPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        desiredPosition += jsMovement.InputDirection;
        desiredPosition.y = 0;


        Debug.Log("desired: " + desiredPosition);

        if (desiredPosition.magnitude != 0)
        {
            player.transform.position += (desiredPosition * moveSpeed);

        }
	}
}
