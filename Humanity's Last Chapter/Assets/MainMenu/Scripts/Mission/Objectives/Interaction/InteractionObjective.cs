using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    public class InteractionObjective : MonoBehaviour {
        public string title = "t.ex. Talk with this person";
        private string verb = "t.ex. talk";
        private string id = "qg0";
        private string description = "It must have been that guy that made the distress call!";
        private bool isComplete, isBonus;
        private GameObject interactObjective; //Object to interact with

        private InteractObject data;

        public void GetData(InteractObject ioQuest) {
            data = ioQuest;
            title = data.title;
            interactObjective = GameObject.FindGameObjectWithTag(data.interactObjective.tag);
        }

        public bool CheckProgress() {
            isComplete = interactObjective.GetComponent<QuestGiver>().isInteracted;
            return isComplete;
        }
    }
}

