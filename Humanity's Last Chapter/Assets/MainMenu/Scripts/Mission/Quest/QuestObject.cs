using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

public class QuestObject : MonoBehaviour {

    public string titel, descrip, hint, dialog, id, nextID;
    private bool isChainMission, isAvalible, isActive, isCompleted;
    private string[] bObjectives, events;
    private int gReward, rsReward, objectiveCounter;
    private Object[] objectives;
    private CollectionObjective coQuest, coHolder;
    private LocationObjective loQuest;
    public ScriptableQuest quest;

    public void GetQuest(ScriptableQuest quest) {
        this.quest = quest;
        NextObjective();
    }

    //Alla objectives borde skapas samtidigt, men de blir checkade i ordning! Borde isåfall ha coQuest etc som array så att den vet vilken den ska kolla in inte srkiver över varandra...

    public void NextObjective() {
        if (objectiveCounter >= quest.objectives.Length) {
            isCompleted = true;
        }
        else {
            id = quest.objectives[objectiveCounter].name[0].ToString() + quest.objectives[objectiveCounter].name[1].ToString();

            switch (id) { //Jättefult, I know... kommer någon på bättre lösning vi kan använda?
                case "co":
                    GetComponent<CollectionObjective>().GetData(quest.objectives[objectiveCounter] as ScriptableCollection);
                    //Debug.Log("coQuest: " + coHolder);
                    break;
                case "lo":
                    GetComponent<LocationObjective>().GetData(quest.objectives[objectiveCounter] as LocationObject);
                    break;
                case "io":
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
        CheckObjective();
    }

    public void CheckObjective() {
        switch (id) { //Jättefult, I know... kommer någon på bättre lösning vi kan använda?
            case "co":
                if (GetComponent<CollectionObjective>().CheckProgress()) {
                    NextObjective();
                }
                break;
            case "lo":
                if (GetComponent<LocationObjective>().CheckProgress()) {
                    NextObjective();
                }
                break;
            case "io":
                //Interactive quest;
                break;
            case "":
                Debug.Log("Id error! " + id);
                break;

        }


    }


}


