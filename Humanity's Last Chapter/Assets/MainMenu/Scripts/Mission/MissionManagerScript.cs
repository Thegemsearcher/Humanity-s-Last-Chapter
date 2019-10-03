using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerScript : MonoBehaviour {
    public GameObject selectParty, Mission, MissionList;
    private GameObject MissionO;
    public MissionObject[] missions;
    private MissionScript missionScript;

    private void Start() {
        for (int i = 0; i < missions.Length; i++) {
            if(missions[i].avalible) {
                missionScript = Mission.GetComponent<MissionScript>();
                MissionO = Instantiate(Mission);
                MissionO.transform.SetParent(MissionList.transform, false);
                missionScript.missionName = missions[i].missionName;
                missionScript.description = missions[i].description;
                missionScript.goldReward = missions[i].goldReward;
                missionScript.rsReward = missions[i].rsReward;
            }
        }
    }

    public void btnSetup() {
        selectParty.SetActive(true);
    }
}
