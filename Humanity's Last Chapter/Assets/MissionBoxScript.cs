using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MissionBoxScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public Text txtName;
    private ScriptableQuest quest;
    private GameObject ActiveQuest, QuestDesc;

    private void Start() {
        ActiveQuest = GameObject.FindGameObjectWithTag("ForActiveQuest");
        QuestDesc = GameObject.FindGameObjectWithTag("QuestDesc");
    }

    public void GetQuest(ScriptableQuest quest) {
        this.quest = quest;
        txtName.text = quest.missionName;
    }

    public void SetActive() {
        WorldScript.world.activeQuest = quest;
        ActiveQuest.GetComponent<ActiveMissionScript>().GetActiveQuest();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        QuestDesc.GetComponent<QuestDescScript>().QuestInfo(quest);
    }

    public void OnPointerExit(PointerEventData eventData) {
        QuestDesc.GetComponent<QuestDescScript>().QuestReset();
    }
}
