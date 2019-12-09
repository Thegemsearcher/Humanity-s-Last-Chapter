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
        private Object[] startEvents;
        private Object[] endEvents;

        private WaveEvent waveEvent;

        public void GetData(ScriptableCollection coQuest, WaveEvent waveEvent) {
            this.waveEvent = waveEvent;
            data = coQuest;
            isRandomSpawn = coQuest.isRandomSpawn;
            toCollectList = new List<GameObject>();
            collectionAmount = data.collectionAmount;
            startEvents = data.startEvents;
            endEvents = data.endEvents;
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
        public Transform[] SpawnPos()
        {
            return spawnPos;
        }

        private void SpawnTarget() {
            if (startEvents != null) {
                StartEvent(startEvents);
            }

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

        private void StartEvent(Object[] eventObj) {
            foreach (Object obj in eventObj) {
                switch (obj.name[0]) {
                    case 'w':
                        waveEvent.GetEvent(obj as WaveObject);
                        break;
                }
            }
        }

        public bool CheckProgress() {
            //objectiveList = GameObject.FindGameObjectsWithTag("Enemy");
            //bool isDone = true;
            foreach(GameObject toCollect in toCollectList) {
                if(toCollect == null) {
                    toCollectList.Remove(toCollect);
                    //isDone = false;
                    break;
                } else {
                }
                
            }
            if(toCollectList.Count <= 0) {
                return true;
            }
            return false;
        }

        public void UpdateProgress() {
            throw new System.NotImplementedException();
        }
        
    }
}

