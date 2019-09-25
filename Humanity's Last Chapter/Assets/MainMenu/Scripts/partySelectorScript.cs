using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partySelectorScript : MonoBehaviour { //Borde kanske vara ParytSetupScript eller SetupScript
    public GameObject characterWindow;
    private GameObject windowO;
    private GameObject[] characters;
    public int selectedCharacter;
    private Vector3 windowPos;
    private CharacterScript characterScript;

    void Start() {
        //Skriva ut character rutor för varje karaktär
        //characterCounter = GameObject.FindGameObjectWithTag("CharacterManager").transform.childCount;
        characters = GameObject.FindGameObjectsWithTag("Character");
        windowPos = new Vector3(0, 0, 0);

        foreach (GameObject character in characters) {
            characterScript = character.GetComponent<CharacterScript>();
            windowO = Instantiate(characterWindow, windowPos, Quaternion.identity);
            windowO.transform.parent = GameObject.Find("CharacterWindowManager").transform;
            windowO.GetComponent<CharacterWindow>().GetInfo(characterScript.name, characterScript.id);
            windowPos.y -= 100;
        }
    }

    public void AppointCharacter(int role) {
        if (selectedCharacter >= 0) {
            //Spara Karaktären

            //Diseabla alla appoint knappar
            selectedCharacter = -1; //För att se till att inte samma karaktär kan vara på flera platser
        }

    }

    public void RemoveCharacter(int role) {

    }
    
}
