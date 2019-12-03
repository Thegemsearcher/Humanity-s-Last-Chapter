﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    public class InteractionObjective : MonoBehaviour {
        public string title = "t.ex. Talk with this person";
        private string verb = "t.ex. talk";
        private string id = "qg0";
        private string description = "It must have been that guy that made the distress call!";
        private bool isComplete, isBonus, isSpawned;
        private Transform spawnPos;
        private GameObject interactObjective; //Object to interact with
        private GameObject holder;
        private GameObject[] gameObjects;

        private InteractObject data;

        public void GetData(InteractObject ioQuest) {
            data = ioQuest;
            title = data.title;
            id = ioQuest.id;
            isSpawned = ioQuest.isSpawned;
            interactObjective = ioQuest.interactObjective;
            spawnPos = ioQuest.spawnPos;

            if(isSpawned) {
                holder = Instantiate(interactObjective);
                holder.transform.position = spawnPos.position;
                holder.GetComponent<InteractiveScript>().id = id;
                //holder.transform.SetParent();
            } else {
                gameObjects = GameObject.FindGameObjectsWithTag(data.interactObjective.tag);
                foreach (GameObject objects in gameObjects) {
                    if (objects.GetComponent<InteractiveScript>().id == id) {
                        holder = objects;
                    }
                }
            }
            holder.GetComponent<InteractiveScript>().SetActive();
            //interactObjective = GameObject.FindGameObjectWithTag(data.interactObjective.tag);
        }

        public bool CheckProgress() {
            isComplete = holder.GetComponent<InteractiveScript>().isInteracted;
            return isComplete;
        }
    }
}

