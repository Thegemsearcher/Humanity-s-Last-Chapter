using QuestSystem;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MissionManagerScript : MonoBehaviour { //Markus, håller koll på alla missions som finns och dess progression

    //public GameObject Mission, MissionList;
    private GameObject MissionO;
    //private ScriptableQuest quest;
    private QuestObject quest;

    public List<QuestObject> activeQuestList;
    //public MissionObject[] missions;
    private MissionScript missionScript;
    private int missionCounter;
    private Text txtQuest, txtObjective;
    private bool isAnnounced;
    private float timer, timeStamp;

    public ScriptableQuest testQuest;
    public bool isTesting;
    private string title, objective;

    private void Start() {
        txtQuest = GameObject.FindGameObjectWithTag("QuestStarted").GetComponent<Text>();
        txtObjective = GameObject.FindGameObjectWithTag("ObjectiveStarted").GetComponent<Text>();
        txtQuest.text = "";
        txtObjective.text = "";
        timer = 4f;
        
        if (isTesting) {
            StartQuest(testQuest); //for test
        }
    }

    public void btnSetup() {
        //selectParty.SetActive(true);
    }

    public void StartQuest(ScriptableQuest startedQuest) {
        quest = new QuestObject(startedQuest, gameObject);
        title = "Quest started: " + quest.titel;
        activeQuestList.Add(quest);
    }

    private void Update() {
        if (activeQuestList.Count > 0) {
            UpdateQuests();
        }

        if(isAnnounced) {
            AnnonceQuest();
        }
    }

    public void NewObjective(string objective) {
        this.objective = "Objective: " + objective;
        isAnnounced = true;
    }

    private void UpdateQuests() {
        foreach (QuestObject activeQuest in activeQuestList) {
            if(!activeQuest.isCompleted) {
                if (activeQuest.CheckObjective()) {
                    activeQuest.NextObjective();
                    isAnnounced = true;
                }
            }
            
        }
    }

    private void AnnonceQuest() {
        timeStamp += Time.deltaTime;
        if(title != "") {
            if (timeStamp >= timer) {
                title = "";
                timeStamp = 0;
            }
            txtQuest.text = title;
        } else if (objective != "") {
            if (timeStamp >= timer) {
                objective = "";
                timeStamp = 0;
            }
            txtObjective.text = objective;
        } else {
            isAnnounced = false;
        }
    }
}
