using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostMissionScript : MonoBehaviour {
    public Color colourSuccess, colourFail;
    public GameObject PostRewardWindow; //Fönstret som ska öppnas om man klickar Continue
    public bool isSuccess;              //Håller koll på om den ska skriva ut att uppdraget lyckades eller ej
    public Text txtMissionOutcome, txtMissionName, txtStoryProgression, txtReward; //Ifall uppdraget misslyckas ska inte reward ritas ut
    private string strMissionOutcome, strStoryProgression, strReward;  //Förberreda strings för det som ska skrivas ut på fönstret
    private ScriptableQuest quest;  //Den aktiva questen
    private List<string> rewardList;    //En lista av de rewards man får av questen för att snyggare kunna skriva ut de
    private int rewardCount, i; //Counters för att snyggare kunna skriva ut quests

    private void Start() {
        quest = WorldScript.world.activeQuest;
        if (isSuccess) { //Kollar ifall uppdraget lyckades
            rewardList = new List<string>();
            strMissionOutcome = "Mission Succeeded";
            
            strStoryProgression = quest.description; //description ska bytas ut till storyProgression
            strReward = "Reward: ";

            if (quest.goldReward > 0) {
                rewardList.Add(quest.goldReward + "gold");
            }

            if (quest.rsReward > 0) {
                rewardList.Add(quest.rsReward + "rs");
            }

            rewardCount = rewardList.Count;
            i = 0;
            foreach (string strReward in rewardList) {  //går igenom alla rewards den har hittat
                this.strReward += strReward;

                i++;
                if (i < rewardCount - 1) { //Om i är större än detta vet vi att nästa reward är sista
                    this.strReward += ", ";
                } else if (i == rewardCount - 1) {
                    this.strReward += " & ";
                }
            }
            txtReward.text = strReward;

            //Har success färger
            txtReward.color = colourSuccess;
            txtMissionName.color = colourSuccess;
            txtMissionOutcome.color = colourSuccess;
            txtStoryProgression.color = colourSuccess;
        } else {
            strMissionOutcome = "Mission Failed";
            strStoryProgression = "We failed this time... We have to retreat back to base! Heal the men at the hospital to recover their strength. Having more firepower or being more carefull might help next time.";
            Destroy(txtReward); //ser till att de inte syns om uppdraget misslyckades

            //Har fail färger
            txtMissionName.color = colourFail;
            txtMissionOutcome.color = colourFail;
            txtStoryProgression.color = colourFail;
        }

        txtMissionName.text = quest.missionName;
        txtMissionOutcome.text = strMissionOutcome;
        txtStoryProgression.text = strStoryProgression;
    } 

    public void BtnContinue() {
        if (isSuccess) {
            Instantiate(PostRewardWindow, transform.parent.transform); //Skapa PostReward
            Destroy(gameObject);
        } else {
            GameObject.FindGameObjectWithTag("SceneSwitcher").GetComponent<SceneSwitcher>().GoToHub(); //Gå till hubben
        }
    }
}
