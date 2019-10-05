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
        
    }

    public void btnSetup() {
        //selectParty.SetActive(true);
    }
}
