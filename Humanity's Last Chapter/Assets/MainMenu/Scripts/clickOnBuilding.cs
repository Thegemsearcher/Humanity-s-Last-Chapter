using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickOnBuilding : MonoBehaviour
{
    public string buildingName;
    public Canvas specificBuildingCanvas;
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
                specificBuildingCanvas.gameObject.SetActive(true);
                //if (buildingName.Equals("middle"))
                //{
                //    specificBuildingCanvas.gameObject.SetActive(true);
                //}
            }
        }
    }
}
