using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingScript : MonoBehaviour { //Borde heta barrackScript

    public string buildingName;
    public int level;

    public GameObject BuildingWindow;

    private void Start() {
        GetComponent<roasterScript>().CreateRoaster(BuildingWindow); //Flyttar vi denna kan vi nog ändra så att alla byggnader 
        //kan använda denna script
    }

    public void btnBarrack() {
        BuildingWindow.SetActive(true);
    }
}
