using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuildingScript : MonoBehaviour {
    public GameObject buildingO;
    public int level;

    public void btnBuilding() {
        buildingO.SetActive(true);
    }
}
