using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

    public string titel, descrip, hint, dialog, id, nextID;
    private bool isChainMission, isAvalible, isActive, isCompleted;
    private string[] objectives, bObjectives, events;
    private int gReward, rsReward;

    public ScriptableQuest quest;

    public void GetQuest(ScriptableQuest quest) {
        this.quest = quest;
        Debug.Log("Quest stuff: " + quest.missionName);
    }
    

}
