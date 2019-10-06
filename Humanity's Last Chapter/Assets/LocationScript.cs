using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationScript : MonoBehaviour {

    public string location;
    private BoxCollider2D room;
    public Text txtLocation; //Ifall man vill att det ska komma upp något i vänstra hörnet att man har gått in i ett rum

    // Start is called before the first frame update
    void Start() {
        room = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter(Collider other) {
        //Enter room
        //If boss room, boos music?
    }

    public void OnTriggerExit(Collider other) {
        //Stop boss music?
    }

    public bool IsContaining(GameObject target) { //Kan användas för att se om fiender är kvar i en location etc etc
        if(room.bounds.Contains(target.transform.position)) {
            return true;
        }
        return false;
    }
}
