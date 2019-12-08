﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float speed = 2f;
    public float edgeScrollSpeed = 0.5f;
    private float zoom = 5;
    public bool edgeScrollEnabled = true;
    private float zoomSpeed = 2f;
    private Vector3 previousPosition;

    private Camera myCam;
    // Start is called before the first frame update
    void Start()
    {
        myCam = GetComponent<Camera>();
        
    }
    // Update is called once per frame
    void Update()
    {
        ScrollZoom();
        EdgeScroll();
        if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftAlt))
        {
            if (Input.GetMouseButtonDown(1))
            {
                previousPosition = Input.mousePosition;
            }
            Vector3 distance = Input.mousePosition - previousPosition;
            transform.position -= distance * 0.1f;
            previousPosition = Input.mousePosition;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
    }
    private void ScrollZoom()
    {
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            zoom -= zoomSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            zoom += zoomSpeed * Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            zoom -= zoomSpeed * Time.deltaTime * 10;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            zoom += zoomSpeed * Time.deltaTime * 10;
        }
            
        myCam.orthographicSize = zoom;
    }

    private void EdgeScroll() //if your mouse goes towards the edge of the screen the screen will go that way
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!edgeScrollEnabled)
                edgeScrollEnabled = true;
            else
                edgeScrollEnabled = false;
        }
        if (!edgeScrollEnabled)
        {
            return;
        }
        int edgeSize = 50;
        if (Input.mousePosition.x > Screen.width - edgeSize)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime * edgeScrollSpeed, 0, 0));
        }
        if (Input.mousePosition.x < edgeSize)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime * edgeScrollSpeed, 0, 0));
        }
        if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime * edgeScrollSpeed, 0));
        }
        if (Input.mousePosition.y <edgeSize)
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime * edgeScrollSpeed, 0));
        }
    }
}
