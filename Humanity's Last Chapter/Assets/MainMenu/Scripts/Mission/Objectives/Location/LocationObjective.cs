using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    public class LocationObjective : MonoBehaviour {
        private string titel = "t.ex. Enter the Kitchen";
        private string description = "t.ex. A distress call from the Dinner Room calls for an investigation";
        private string id = "t.ex. lo0";
        private GameObject Location;
        private GameObject[] clearOutTarget; //I fall man vill ha en quest som handlar om att rensa rum av fiender
        private GameObject[] characters;
        private bool isComlete;
        private bool isBonus;
        private LocationScript loScript;

        LocationObject data;

        public void GetData(LocationObject data) {
            this.data = data;
            titel = data.titel;
            description = data.description;
            id = data.id;
            Location = data.Location;
            clearOutTarget = data.clearOutTarget;
            isComlete = false;
            isBonus = data.isBonus;
            loScript = Location.GetComponent<LocationScript>();
            characters = GameObject.FindGameObjectsWithTag("Characters");
        }

        public bool CheckProgress() {
            Debug.Log("Does it get here?");
            foreach (GameObject character in characters) {
                if (loScript.GetComponent<BoxCollider2D>().bounds.Contains(character.transform.position)) {
                    if(clearOutTarget.Length == 0) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

