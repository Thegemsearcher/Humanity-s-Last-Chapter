using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour {

    public string titel, id;
    private string objective;
    public bool isCompleted;
    public int questStage;
    private ScriptableQuest quest;
    private GameObject MissionManager;

    private CollectionObjective coObjective;
    private LocationObjective loObjective;
    private InteractionObjective ioObjective;
    private List<ScriptableQuest> nextMissionComplete;

    public QuestObject() { 
    }

    public void GetData(ScriptableQuest quest, GameObject MissionManager) {
        this.quest = quest;
        this.MissionManager = MissionManager;
        titel = quest.missionName;
        id = quest.name;
        isCompleted = false;
        coObjective = MissionManager.GetComponent<CollectionObjective>();
        loObjective = MissionManager.GetComponent<LocationObjective>();
        ioObjective = MissionManager.GetComponent<InteractionObjective>();
        NextObjective();
    }

    public void UpdateQuest(GameObject MissionManager) {
        this.MissionManager = MissionManager;
        coObjective = MissionManager.GetComponent<CollectionObjective>();
        loObjective = MissionManager.GetComponent<LocationObjective>();
        ioObjective = MissionManager.GetComponent<InteractionObjective>();
    }

    //Alla objectives borde skapas samtidigt, men de blir checkade i ordning! Borde isåfall ha coQuest etc som array så att den vet vilken den ska kolla in inte srkiver över varandra...

    public void NextObjective() {
        
        if (questStage >= quest.objectives.Length) {
            CompletedQuest();
            objective = "Quest Completed!";
        }
        else {
            id = quest.objectives[questStage].name[0].ToString();

            switch (id) {
                case "c":
                    //MissionManager.GetComponent<CollectionObjective>().GetData(quest.objectives[objectiveCounter] as ScriptableCollection);
                    coObjective.GetData(quest.objectives[questStage] as ScriptableCollection);
                    objective = coObjective.title;
                    break;

                case "l":
                    loObjective.GetData(quest.objectives[questStage] as LocationObject);
                    objective = loObjective.title;
                    break;

                case "i":
                    ioObjective.GetData(quest.objectives[questStage] as InteractObject);
                    objective = ioObjective.title;
                    break;
                case "":
                    objective = "Error! no more Objectives";
                    break;
            }
            questStage++;
            MissionManager.GetComponent<MissionManagerScript>().NewObjective(objective);
        }
    }

    private void CompletedQuest() {
        //txtObjective.text = "";
        //gameObject.SetActive(false);
        isCompleted = true;
        WorldScript.world.gold += quest.goldReward;
        WorldScript.world.rs += quest.rsReward;
        WorldScript.world.completedQuests.Add(quest);
        WorldScript.world.RemoveAvalible(quest);

        if (nextMissionComplete.Count > 0) {
            foreach (ScriptableQuest quest in nextMissionComplete) {
                WorldScript.world.avalibleQuests.Add(quest);
            }
        }
    }

    //private void OnDestroy() {
    //    if(!isCompleted) {
    //        WorldScript.world.failedQuests.Add(quest);
    //        WorldScript.world.RemoveAvalible(quest);
    //    }
    //}

    private void Update() {
        //timeStamp += Time.deltaTime;
        //if(timeStamp >= textTimer) {
        //    txtQuest.text = "";
            
        //}

        //CheckObjective();
    }

    public bool CheckObjective() {
        switch (id) { //Jättefult, I know... kommer någon på bättre lösning vi kan använda?
            case "c": //CollectionObjective
                if (coObjective.CheckProgress()) {
                    return true;
                }
                break;
            case "l": //LocationObjective
                if (loObjective.CheckProgress()) {
                    return true;
                }
                break;
            case "i": //InteractiveObjective
                if (ioObjective.CheckProgress()) {
                    return true;
                }
                break;
            case "":
                Debug.Log("Id error! " + id);
                break;
        }
        //Debug.Log("Nothing is done");
        return false;
    }
}


