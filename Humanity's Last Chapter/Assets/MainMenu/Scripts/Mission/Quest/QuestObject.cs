using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour {

    public string titel, descrip, hint, dialog, id, nextID;
    private bool isChainMission, isAvalible, isActive, isCompleted;
    private string[] bObjectives, events;
    private int gReward, rsReward, objectiveCounter;
    private Object[] objectives;
    private CollectionObjective coQuest, coHolder;
    private LocationObjective loQuest;
    private InteractObject ioQuest;
    public ScriptableQuest quest;

    private float textTimer, timeStamp;
    public Text txtQuest, txtObjective;

    public void GetQuest(ScriptableQuest quest) {
        this.quest = quest;

        //Funderar på att ha texterna som en prefab så att de skapar en text som sen förstör sig själv
        txtQuest = GameObject.FindGameObjectWithTag("QuestStarted").GetComponent<Text>(); 
        txtObjective = GameObject.FindGameObjectWithTag("ObjectiveStarted").GetComponent<Text>();
        txtQuest.text = "";
        txtObjective.text = "";

        textTimer = 1;
        if (!isActive) {
            txtQuest.text = quest.missionName;
        }
        NextObjective();
    }

    //Alla objectives borde skapas samtidigt, men de blir checkade i ordning! Borde isåfall ha coQuest etc som array så att den vet vilken den ska kolla in inte srkiver över varandra...

    public void NextObjective() {
        if (objectiveCounter >= quest.objectives.Length) {
            txtObjective.text = "";
            gameObject.SetActive(false);
            isCompleted = true;
        }
        else {
            id = quest.objectives[objectiveCounter].name[0].ToString() + quest.objectives[objectiveCounter].name[1].ToString();

            switch (id) { //Jättefult, I know... kommer någon på bättre lösning vi kan använda?
                case "co":
                    GetComponent<CollectionObjective>().GetData(quest.objectives[objectiveCounter] as ScriptableCollection);
                    txtObjective.text = GetComponent<CollectionObjective>().title;
                    //Debug.Log("coQuest: " + coHolder);
                    break;
                case "lo":
                    GetComponent<LocationObjective>().GetData(quest.objectives[objectiveCounter] as LocationObject);
                    txtObjective.text = GetComponent<LocationObjective>().title;
                    break;
                case "io":
                    GetComponent<InteractionObjective>().GetData(quest.objectives[objectiveCounter] as InteractObject);
                    txtObjective.text = GetComponent<InteractionObjective>().title;
                    //Interactive quest;
                    break;
                case "":
                    Debug.Log("Id error! " + id);
                    break;
            }
            objectiveCounter++;
        }
    }

    private void Update() {
        timeStamp += Time.deltaTime;
        if(timeStamp >= textTimer) {
            txtQuest.text = "";
            
        }

        CheckObjective();
    }

    public void CheckObjective() {
        switch (id) { //Jättefult, I know... kommer någon på bättre lösning vi kan använda?
            case "co": //CollectionObjective
                if (GetComponent<CollectionObjective>().CheckProgress()) {
                    NextObjective();
                }
                break;
            case "lo": //LocationObjective
                if (GetComponent<LocationObjective>().CheckProgress()) {
                    NextObjective();
                }
                break;
            case "io": //InteractiveObjective
                if (GetComponent<InteractionObjective>().CheckProgress()) {
                    NextObjective();
                }
                break;
            case "":
                Debug.Log("Id error! " + id);
                break;

        }
    }
}

/*ToDo:
 * Fixa så att texterna är en prefab som har ett script som förstör sig själva
 * Fixa interactive missions
 */


