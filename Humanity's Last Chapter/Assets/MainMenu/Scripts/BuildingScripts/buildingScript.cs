using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingScript : MonoBehaviour { //Borde heta barrackScript

    public string buildingName;
    public int level;
    public bool active;

    public GameObject BuildingWindow;
    private GameObject[] buildings;

    private void Start() {
        buildings = GameObject.FindGameObjectsWithTag("Building");
    }

    public void btnEnterBuilding() {
        BuildingWindow.SetActive(true);
        //foreach (GameObject building in buildings) {
        //    if(!(building.GetComponent<buildingScript>().buildingName == buildingName)) {
        //        building.SetActive(false);
        //    }
    //}
        
    }
}
