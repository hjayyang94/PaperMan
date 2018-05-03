using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    public bool tap, swipeLeft, swipeRight;
    public Vector2 startTouch, swipeDelta;

    private bool isDragging;
    private Vector2 touchOrigin = -Vector2.one;

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        tap = false;
        swipeLeft = false;
        swipeRight = false;


        //Mouse Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Reset();
        }

        //Mobile Inputs
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];

            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }

            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                touchOrigin.x = -1;
            }


            if(Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }


        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //Out of dead zone
        if(swipeDelta.magnitude > 100)
        {
            //Which direction?

            float x = swipeDelta.x;

            if (x < 0)
            {
                swipeLeft = true;
            }

            else
            {
                swipeRight = true;
            }

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
        isDragging = false;
    }
}
