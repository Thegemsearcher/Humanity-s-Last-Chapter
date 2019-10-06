using QuestSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStarter : MonoBehaviour {
    public ScriptableQuest quest;
    public GameObject QuestHolder;
    private GameObject QuestHolderO;

    void Start() { //Start ska sen bort!
        QuestHolderO = Instantiate(QuestHolder);
        QuestHolderO.transform.parent = GameObject.Find("forMissions").transform;
        QuestHolderO.transform.localScale.Scale(new Vector3(1, 1, 1));
        QuestHolderO.GetComponent<QuestObject>().GetQuest(quest);
    }

    public void ActivateQuest() {
        Debug.Log("Does it get here?");
        QuestHolderO = Instantiate(QuestHolder);
        QuestHolderO.GetComponent<QuestObject>().GetQuest(quest);
    }

    public void InteractWithQuestgiver() {

    }
}
