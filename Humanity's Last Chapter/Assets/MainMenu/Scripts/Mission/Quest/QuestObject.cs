using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour {

    public string titel;
    private string id, objective;
    public bool isCompleted;
    private int objectiveCounter;
    //public Object[] objectives;
    private ScriptableQuest quest;
    private GameObject MissionManager;

    private CollectionObjective coObjective;
    private LocationObjective loObjective;
    private InteractionObjective ioObjective;

    //private float textTimer, timeStamp;
    //public Text txtQuest, txtObjective;

    public QuestObject(ScriptableQuest quest, GameObject MissionManager) {
        this.quest = quest;
        this.MissionManager = MissionManager;
        titel = quest.missionName;
        isCompleted = false;
        coObjective = MissionManager.GetComponent<CollectionObjective>();
        loObjective = MissionManager.GetComponent<LocationObjective>();
        ioObjective = MissionManager.GetComponent<InteractionObjective>();
        NextObjective();
        //txtQuest = GameObject.FindGameObjectWithTag("QuestStarted").GetComponent<Text>();
        //txtObjective = GameObject.FindGameObjectWithTag("ObjectiveStarted").GetComponent<Text>();
        //txtQuest.text = "";
        //txtObjective.text = "";
    }

    //public void GetQuest(ScriptableQuest quest) {
    //    this.quest = quest;
    //    //txtQuest = GameObject.FindGameObjectWithTag("QuestStarted").GetComponent<Text>();
    //    //txtObjective = GameObject.FindGameObjectWithTag("ObjectiveStarted").GetComponent<Text>();
    //    //txtQuest.text = "";
    //    //txtObjective.text = "";
    //    //Funderar på att ha texterna som en prefab så att de skapar en text som sen förstör sig själv


    //    //textTimer = 1;
    //    //if (!isActive) {
    //    //    txtQuest.text = quest.missionName;
    //    //}
    //    NextObjective();
    //}

    //Alla objectives borde skapas samtidigt, men de blir checkade i ordning! Borde isåfall ha coQuest etc som array så att den vet vilken den ska kolla in inte srkiver över varandra...

    public void NextObjective() {
        
        if (objectiveCounter >= quest.objectives.Length) {
            CompletedQuest();
            objective = "Quest Completed!";
        }
        else {
            id = quest.objectives[objectiveCounter].name[0].ToString();

            switch (id) {
                case "c":
                    //MissionManager.GetComponent<CollectionObjective>().GetData(quest.objectives[objectiveCounter] as ScriptableCollection);
                    coObjective.GetData(quest.objectives[objectiveCounter] as ScriptableCollection);
                    objective = coObjective.title;
                    break;

                case "l":
                    loObjective.GetData(quest.objectives[objectiveCounter] as LocationObject);
                    objective = loObjective.title;
                    break;

                case "i":
                    ioObjective.GetData(quest.objectives[objectiveCounter] as InteractObject);
                    objective = ioObjective.title;
                    break;
                case "":
                    objective = "Error! no more Objectives";
                    break;
            }
            objectiveCounter++;
            MissionManager.GetComponent<MissionManagerScript>().NewObjective(objective);
        }
    }

    private void CompletedQuest() {
        //txtObjective.text = "";
        //gameObject.SetActive(false);
        isCompleted = true;
        WorldScript.world.gold += quest.goldReward;
        WorldScript.world.rs += quest.rsReward;

        if (quest.isChainMission) { //Kan ändras så at det finns flera olika missions som startar beroend på hur questen går
            MissionManager.GetComponent<MissionManagerScript>().StartQuest(quest.nextMission);
        }
    }

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

/*ToDo:
 * Fixa så att texterna är en prefab som har ett script som förstör sig själva
 * Fixa interactive missions
 */


