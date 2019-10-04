using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    public class LocationObjective : IQuestObjectives {
        private string title, description;
        private bool isComplete, isBonus;

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
            //if (currentAmount >= collectionAmount) {
            //    isComplete = true;
            //} else {
            //    isComplete = false;
            //}
        }

        public void UpdateProgress() {
            throw new System.NotImplementedException();
        }
    }
}

