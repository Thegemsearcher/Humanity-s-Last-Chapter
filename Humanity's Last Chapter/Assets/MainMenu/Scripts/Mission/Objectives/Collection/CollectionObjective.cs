using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {

    public class CollectionObjective : MonoBehaviour {
        private string title, description, verb;
        private int collectionAmount, enemiesLeft; //Ammout of things that will be collected
        private int currentAmount; //starts at 0
        private bool isComplete, isBonus;
        private GameObject itemsToCollect, itemO; //Kanske ska bytas till något annat
        private GameObject[] objectiveList;
        private Transform[] spawnPos;
        private ScriptableCollection data;

        public void GetData(ScriptableCollection coQuest) {
            data = coQuest;
            collectionAmount = data.collectionAmount;
            //title = data.verb + " " + collectionAmount + " " + data.itemsToCollect.name;
            verb = data.verb;
            description = data.description;
            itemsToCollect = data.itemsToCollect;
            currentAmount = 0;
            isBonus = data.isBonus;
            spawnPos = data.spawnPos;
            enemiesLeft = 0;
            SpawnTarget();
            CheckProgress();
        }

        private void SpawnTarget() {
            for (int i = 0; i < collectionAmount; i++) {
                itemO = Instantiate(itemsToCollect, spawnPos[i].position, Quaternion.identity);
                itemO.transform.SetParent(GameObject.Find("SpawnHolder").transform, false);
                itemO.GetComponent<MarkusEnemy>().id = data.name + "Enemy";
            }
        }


        public bool CheckProgress() {
            objectiveList = GameObject.FindGameObjectsWithTag("Enemy");
            enemiesLeft = 0;
            foreach(GameObject enemy in objectiveList) {
                if(enemy.GetComponent<MarkusEnemy>().id == data.name+"Enemy") {
                    
                    return false;
                }
            }
            Debug.Log("Done right");
            return true;
            //currentAmount = collectionAmount - enemiesLeft;

            //if(currentAmount >= collectionAmount) {
            //    Debug.Log("Quest Complete!");
            //    isComplete = true;
            //}
            //else {
            //    isComplete = false;
            //}
            //return isComplete;
        }

        public void UpdateProgress() {
            throw new System.NotImplementedException();
        }

        // 0/x items collected
        //public override string ToString() {
        //    return currentAmount +"/"+ collectionAmount + " "+itemsToCollect.name + " " + verb+"ed!";
        //}
    }
}

