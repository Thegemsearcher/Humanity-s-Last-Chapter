using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDescScript : MonoBehaviour {

    public Text txtQuestName, txtQuestDesc, txtReward;
    private List<string> rewardList;
    private string reward;
    private int rewardCount, i;
    private ScriptableQuest activeQuest;

    private void Start() {
        txtQuestName.text = "";
        txtQuestDesc.text = "";
        rewardList = new List<string>();
        reward = "";
        txtReward.text = reward;
    }

    public void QuestInfo(ScriptableQuest quest) {
        txtQuestName.text = quest.missionName;
        txtQuestDesc.text = quest.description;
        rewardList.Clear();

        reward = "Reward: ";

        if (quest.goldReward > 0) {
            rewardList.Add(quest.goldReward + "gold");
        }

        if (quest.rsReward > 0) {
            rewardList.Add(quest.rsReward + "rs");
        }

        rewardCount = rewardList.Count;
        i = 0;
        foreach (string reward in rewardList) {
            this.reward += reward;

            i++;
            if (i < rewardCount - 1) { //Om i är större än detta vet vi att nästa reward är sista
                this.reward += ", ";
            } else if (i == rewardCount - 1) {
                this.reward += " & ";
            }
            
        }
        txtReward.text = reward;
    }

    public void QuestReset() {
        activeQuest = WorldScript.world.activeQuest;
        if(activeQuest != null) {
            QuestInfo(activeQuest);
        } else {
            Clear();
        }
    }

    private void Clear() {
        txtQuestName.text = "";
        txtQuestDesc.text = "";
        reward = "";
        txtReward.text = reward;
    }
}
