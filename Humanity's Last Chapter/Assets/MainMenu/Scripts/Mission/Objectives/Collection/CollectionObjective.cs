using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {

    public class CollectionObjective : MonoBehaviour {
        public string title, description, verb;
        private int collectionAmount, targetsLeft; //Ammout of things that will be collected
        private int currentAmount, counter; //starts at 0
        private bool isComplete, isBonus, isRandomSpawn;
        private GameObject itemsToCollect, itemO; //Kanske ska bytas till något annat
        private GameObject[] objectiveList;
        private List<GameObject> toCollectList;
        private Transform[] spawnPos;
        private ScriptableCollection data;

        public void GetData(ScriptableCollection coQuest) {
            data = coQuest;
            isRandomSpawn = coQuest.isRandomSpawn;
            toCollectList = new List<GameObject>();
            collectionAmount = data.collectionAmount;
            title = data.verb + " " + collectionAmount + " " + data.itemsToCollect.name;
            verb = data.verb;
            description = data.description;
            itemsToCollect = data.itemsToCollect;
            currentAmount = 0;
            isBonus = data.isBonus;
            spawnPos = data.spawnPos;
            targetsLeft = 0;
            SpawnTarget();
            CheckProgress();
        }

        private void SpawnTarget() {
            if(isRandomSpawn) {
                for (int i = 0; i < collectionAmount; i++) {
                    counter = Random.Range(0, spawnPos.Length);
                    itemO = Instantiate(itemsToCollect, spawnPos[counter].position, Quaternion.identity);
                    itemO.transform.SetParent(GameObject.Find("SpawnHolder").transform, false);
                    toCollectList.Add(itemO);
                }
            }
            else {
                counter = 0;
                for (int i = 0; i < collectionAmount; i++) {
                    itemO = Instantiate(itemsToCollect, spawnPos[counter].position, Quaternion.identity);
                    itemO.transform.SetParent(GameObject.Find("SpawnHolder").transform, false);
                    toCollectList.Add(itemO);

                    counter++;
                    if (counter >= spawnPos.Length) {
                        counter = 0;
                    }
                    //itemO.GetComponent<Enemy>().id = data.name + "Enemy";
                }
            }
            
        }

        public bool CheckProgress() {
            //objectiveList = GameObject.FindGameObjectsWithTag("Enemy");
            targetsLeft = 0;
            foreach(GameObject toCollect in toCollectList) {
                if(toCollect == null) {
                    toCollectList.Remove(toCollect);
                    break;
                } else {
                    targetsLeft++;
                }
                
            }
            if(targetsLeft > 0) {
                return false;
            }
            return true;
        }

        public void UpdateProgress() {
            throw new System.NotImplementedException();
        }
        
    }
}

