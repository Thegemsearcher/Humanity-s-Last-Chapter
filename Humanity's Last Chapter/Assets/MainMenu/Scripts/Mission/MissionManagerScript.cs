﻿using QuestSystem;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MissionManagerScript : MonoBehaviour { //Markus, håller koll på alla missions som finns och dess progression

    public bool isTesting;
    public ScriptableQuest testQuest;
    public List<QuestObject> activeQuestList;

    private int missionCounter;
    private float timer, timeStamp;
    private bool isAnnounced;
    private string title, objective;
    private QuestObject quest;
    private Text txtQuest, txtObjective;
    private List<string> announceOrder;

    private void Awake() {
        activeQuestList = new List<QuestObject>();
        announceOrder = new List<string>();
    }

    private void Start() {
        txtQuest = GameObject.FindGameObjectWithTag("QuestStarted").GetComponent<Text>();
        txtObjective = GameObject.FindGameObjectWithTag("ObjectiveStarted").GetComponent<Text>();
        announceOrder = new List<string>();
        txtQuest.text = "";
        txtObjective.text = "";
        timer = 4f;

        LoadQuests();
        
        if (isTesting) {
            StartQuest(testQuest); //for test
        }
    }

    public void LoadQuests() {
        if (activeQuestList != null) {
            foreach (QuestObject quest in activeQuestList) {
                quest.UpdateQuest(gameObject);
            }
        }
    }

    public void StartQuest(ScriptableQuest startedQuest) {
        title = "Quest started: " + startedQuest.missionName;
        announceOrder.Add(title);
        quest = new QuestObject();
        quest.GetData(startedQuest, gameObject);
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
        announceOrder.Add(this.objective);
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
        if(timeStamp >= timer) {
            announceOrder.RemoveAt(0);
            txtQuest.text = "";
            txtObjective.text = "";
            timeStamp = 0;
        }

        if (announceOrder.Count <= 0) {
            isAnnounced = false;
        } else {
            string toAnnounce = announceOrder[0];
            switch (toAnnounce[0]) {
                case 'Q':
                    txtQuest.text = toAnnounce;
                    break;
                case 'O':
                    txtObjective.text = toAnnounce;
                    break;
                default:
                    Debug.Log("Error! Nothing to announce... " + toAnnounce[0]);
                    break;
            }
        }
    }
}
