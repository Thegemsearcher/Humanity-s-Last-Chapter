using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackWindow : MonoBehaviour {

    private GameObject[] buildings;

    private void Start() {
        buildings = GameObject.FindGameObjectsWithTag("Building");
    }

    public void btnExit() {
        //foreach (GameObject building in buildings) {
        //    building.SetActive(true);
        //}
        gameObject.SetActive(false);
    }
}
