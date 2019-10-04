using QuestSystem;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MissionManagerScript : MonoBehaviour {
    public GameObject Mission, MissionList;
    private GameObject MissionO;
    public MissionObject[] missions;
    private MissionScript missionScript;
    private int missionCounter;

    private void Start() {
        missionCounter = Directory.GetFiles("Assets/MissionFolder/").Length / 2;
        missions = new MissionObject[missionCounter];

        for (int i = 0; i < missionCounter; i++) {
            missions[i] = (MissionObject)AssetDatabase.LoadAssetAtPath("Assets/MissionFolder/mi" + i + ".asset", typeof(MissionObject));
            if(missions[i].avalible && !(missions[i].completed)) {
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
        //selectParty.SetActive(true);
    }
}
