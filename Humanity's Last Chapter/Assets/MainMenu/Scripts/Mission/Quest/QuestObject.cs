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
    private CollectionObjective coQuest;
    private LocationObjective loQuest;
    public ScriptableQuest quest;

    public void GetQuest(ScriptableQuest quest) {
        this.quest = quest;
        NextObjective();
    }

    //Alla objectives borde skapas samtidigt, men de blir checkade i ordning! Borde isåfall ha coQuest etc som array så att den vet vilken den ska kolla in inte srkiver över varandra...

    public void NextObjective() { 
        id = quest.objectives[objectiveCounter].name[0].ToString() + quest.objectives[objectiveCounter].name[1].ToString();
        Debug.Log("Id: " + id);

        switch (id) { //Jättefult, I know... kommer någon på bättre lösning vi kan använda?
            case "co":
                coQuest = new CollectionObjective(quest.objectives[objectiveCounter] as ScriptableCollection);
                Debug.Log("coQuest: " + coQuest);
                break;
            case "lo":
                loQuest = new LocationObjective(quest.objectives[objectiveCounter] as LocationObject);
                break;
            case "io":
                //Interactive quest;
                break;
            case "":
                Debug.Log("Id error! "+id);
                break;
        }
        objectiveCounter++;
        if(objectiveCounter > quest.objectives.Length) {
            Debug.Log("Quest Complete!");
        }
        
    }

    public void CheckObjective() {
        switch (id) { //Jättefult, I know... kommer någon på bättre lösning vi kan använda?
            case "co":
                //Debug.Log("What is coQuest: " + coQuest);
                if(!(coQuest == null)) {
                    if (coQuest.GetComponent<CollectionObjective>().CheckProgress()) {
                        NextObjective();
                    }
                }
                
                break;
            case "lo":
                if (loQuest.GetComponent<LocationObjective>().CheckProgress()) {
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


