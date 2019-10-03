using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionScript : MonoBehaviour {
    private GameObject SelectedMission;
    public Text txtName;
    private string[] missionName = { "A Begining", "Scavenger", "Raid" };

    void Start() {
        txtName.text = missionName[Random.Range(0, missionName.Length)];
        SelectedMission = GameObject.Find("forSelectedMission");
    }

    public void Pressed() {
        if(SelectedMission.transform.childCount > 0) {
            SelectedMission.GetComponent<SelectedMissionScript>().ChangeSelected();
        }
        transform.SetParent(SelectedMission.transform, false);
    }
}
