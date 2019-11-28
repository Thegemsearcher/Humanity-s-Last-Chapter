using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadQuests : MonoBehaviour {

    private GameObject holder;
    public GameObject MissionBox, MissionHolder;

    void Start() {
        foreach (QuestObject quest in WorldScript.world.questList) {
            holder = Instantiate(MissionBox);
            holder.GetComponent<MissionBoxScript>().GetQuest(quest.titel);
            holder.transform.SetParent(MissionHolder.transform, false);
        }
    }
}
