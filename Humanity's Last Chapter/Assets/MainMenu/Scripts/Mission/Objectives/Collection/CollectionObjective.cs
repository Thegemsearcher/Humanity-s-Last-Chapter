using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    public class CollectionObjective : IQuestObjectives {
        private string title, description, verb;
        private int collectionAmount; //Ammout of things that will be collected
        private int currentAmount; //starts at 0
        private bool isComplete, isBonus;
        private GameObject itemsToCollect; //Kanske ska bytas till något annat

        public CollectionObjective(string titleVerb, int totalAmount, GameObject item, string descrip, bool bonus) {
            title = titleVerb + " " + totalAmount + " " + item.name;
            verb = titleVerb;
            description = descrip;
            itemsToCollect = item;
            collectionAmount = totalAmount;
            currentAmount = 0;
            isBonus = bonus;
            CheckProgress();
        }

        public string Title {
            get {
                return title;
            }
        }

        public string Description {
            get {
                return description;
            }
        }

        public bool IsComplete {
            get {
                return isComplete;
            }
        }

        public bool IsBonus {
            get {
                return isBonus;
            }
        }

        public void CheckProgress() {
            if(currentAmount >= collectionAmount) {
                isComplete = true;
            }
            else {
                isComplete = false;
            }
        }

        public void UpdateProgress() {
            throw new System.NotImplementedException();
        }

        // 0/x items collected
        public override string ToString() {
            return currentAmount +"/"+ collectionAmount + " "+itemsToCollect.name + " " + verb+"ed!";
        }
    }
}

