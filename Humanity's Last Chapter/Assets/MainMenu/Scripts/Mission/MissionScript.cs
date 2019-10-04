using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MissionScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    private GameObject SelectedMission;
    public GameObject MissionInfo;
    public Text txtName, txtDescription, txtReward;
    public string missionName, description, gold, rs;
    public int goldReward, rsReward;

    void Start() {
        txtName.text = missionName;
        txtDescription.text = description;

        if (goldReward > 0) {
            gold = goldReward + " Gold ";
        } else {
            gold = "";
        }

        if (rsReward > 0) {
            rs = rsReward + " RS ";
        }
        else {
            rs = "";
        }

        txtReward.text = "Reward: " + gold + rs;
        SelectedMission = GameObject.Find("forSelectedMission");
    }

    public void Pressed() {
        if(SelectedMission.transform.childCount > 0) {
            SelectedMission.GetComponent<SelectedMissionScript>().ChangeSelected();
        }
        transform.SetParent(SelectedMission.transform, false);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        MissionInfo.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData) {
        MissionInfo.SetActive(false);

    }
}
//Name
//Description
//SourceID
//MissionID
//Next mission ID
//Chain mission
//Reward
//Missionstatus
//Objectives
//Bonus Objective
//Events
