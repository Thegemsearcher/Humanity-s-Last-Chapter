﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToPlayerRoster : MonoBehaviour
{
    public GameObject UIParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (GetComponent<Collider2D>().OverlapPoint(mousePosition))
            {
                AddToPlayer();
            }
        }
    }
    
    public void AddToPlayer()
    {
        this.transform.SetParent(UIParent.transform);
        GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x - 100, 
            GetComponent<RectTransform>().position.y, 0);
    }
}
