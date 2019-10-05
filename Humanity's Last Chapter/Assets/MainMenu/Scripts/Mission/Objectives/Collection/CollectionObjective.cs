using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {

    public class CollectionObjective : MonoBehaviour {
        private string title, description, verb;
        private int collectionAmount; //Ammout of things that will be collected
        private int currentAmount; //starts at 0
        private bool isComplete, isBonus;
        private GameObject itemsToCollect, itemO; //Kanske ska bytas till något annat
        private Transform[] spawnPos;
        private ScriptableCollection data;

        public CollectionObjective(ScriptableCollection coQuest) {
            data = coQuest;
            collectionAmount = data.collectionAmount;
            title = data.verb + " " + collectionAmount + " " + data.itemsToCollect.name;
            verb = data.verb;
            description = data.description;
            itemsToCollect = data.itemsToCollect;
            currentAmount = 0;
            isBonus = data.isBonus;
            spawnPos = data.spawnPos;
            Debug.Log("Title: " + title);
            SpawnTarget();
            CheckProgress();
        }

        private void SpawnTarget() {
            for (int i = 0; i < collectionAmount; i++) {
                itemO = Instantiate(itemsToCollect, spawnPos[i].position, Quaternion.identity);
                Debug.Log("How many characters to collect? " + collectionAmount);
                //itemO.tag = verb + "Quest";
                itemO.transform.SetParent(GameObject.Find("SpawnHolder").transform, false);
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

