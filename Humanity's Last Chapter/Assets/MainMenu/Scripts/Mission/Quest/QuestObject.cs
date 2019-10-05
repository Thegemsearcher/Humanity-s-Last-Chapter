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

        public ScriptableQuest quest;

        public void GetQuest(ScriptableQuest quest) {
            this.quest = quest;
            NextObjective();
        }

        public void NextObjective() {
        CollectionObjective coQuest = new CollectionObjective(quest.objectives[objectiveCounter] as ScriptableCollection);
        

        }


    }


