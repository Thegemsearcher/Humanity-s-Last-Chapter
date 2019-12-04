using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    public class LocationObjective : MonoBehaviour {
        public string title = "t.ex. Enter the Kitchen";
        private string description = "t.ex. A distress call from the Dinner Room calls for an investigation";
        private string id = "t.ex. lo0";
        private GameObject Location;
        private GameObject[] clearOutTarget; //I fall man vill ha en quest som handlar om att rensa rum av fiender
        private GameObject[] characters;
        private bool isComlete;
        private bool isBonus;
        private LocationScript loScript;
        private WaveEvent waveEvent;

        private Object[] startEvents;
        private Object[] endEvents;

        LocationObject data;

        public void GetData(LocationObject data, WaveEvent waveEvent) {
            this.data = data;
            this.waveEvent = waveEvent;
            title = data.titel;
            description = data.description;
            id = data.id;
            Location = data.Location;
            clearOutTarget = data.clearOutTarget;
            isComlete = false;
            isBonus = data.isBonus;
            loScript = Location.GetComponent<LocationScript>();
            characters = GameObject.FindGameObjectsWithTag("Character");

            GameObject[] Locations = GameObject.FindGameObjectsWithTag("Location");
            foreach (GameObject location in Locations) {
                if (location.name == data.Location.name) {
                    Location = location;
                    break;
                }
            }

            if (startEvents != null) {
                StartEvent(startEvents);
            }
        }

        public bool CheckProgress() {
            
            foreach (GameObject character in characters) {
                isComlete = Location.GetComponent<LocationScript>().isInRoom;
                //Debug.Log("LocationPos: " + loScript.GetComponent<BoxCollider2D>().bounds);
                //if (loScript.GetComponent<BoxCollider2D>().bounds.Contains(character.transform.position)) {
                //    Debug.Log("It works now!");
                //    if (clearOutTarget.Length == 0) {
                //        return true;
                //    }
                //}
            }
            if (isComlete) {
                if (endEvents != null) {
                    StartEvent(endEvents);
                }
            }
            return isComlete;
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

    }
}

