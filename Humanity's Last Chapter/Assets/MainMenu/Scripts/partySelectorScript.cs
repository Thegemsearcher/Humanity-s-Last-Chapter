using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partySelectorScript : MonoBehaviour { //Borde kanske vara ParytSetupScript eller SetupScript
    public GameObject characterWindow;
    private GameObject windowO;
    private GameObject[] characters, roles, windows;
    public int selectedCharacter;
    private Vector3 windowPos;
    private CharacterScript characterScript;
    private CharacterWindow windowScript;
    private btnAppointScript roleScript;
    private int[] missionParty; //Denna intArray ska spara id för karaktärena som ska på mission

    void Start() {
        //Skriva ut character rutor för varje karaktär
        characters = GameObject.FindGameObjectsWithTag("Character");
        windows = GameObject.FindGameObjectsWithTag("CharacterWindow");
        selectedCharacter = -1;
        windowPos = new Vector3(0, 0, 0);
        missionParty = new int[5]; //Femman är hur många roller som kan vara på mission... ska vi ha oändligt kommer nog inte en array att fungera
        for (int i = 0; i < missionParty.Length; i++) {
            missionParty[i] = -1;
        }

        foreach (GameObject character in characters) { //Kan någon kolla varför de skrivs ut på ett så konstigt ställe?
            //characterScript = character.GetComponent<CharacterScript>();
            //windowO = Instantiate(characterWindow, windowPos, Quaternion.identity);
            //windowO.transform.parent = GameObject.Find("CharacterWindowManager").transform;
            //windowO.GetComponent<CharacterWindow>().GetInfo(characterScript.name, characterScript.id);
            //windowPos.y -= 100;
        }
    }

    public bool AppointCharacter(int role) { //Lägger till karaktärens id till arren med id för karaktärer som går på mission
        if (selectedCharacter >= 0) { 
            foreach (GameObject window in windows) {
                windowScript = window.GetComponent<CharacterWindow>();
                if(windowScript.ID == selectedCharacter) {
                    missionParty[role] = selectedCharacter;
                }
            }

            //Diseabla alla appoint knappar

            selectedCharacter = -1; //För att se till att inte samma karaktär kan vara på flera platser
            return true;
        }
        return false;

    }

    public void RemoveCharacter(int role) { //tar bort en karaktärs id från arrayen med id så att karaktären inte går på mission eller kan vara på en annan roll
        foreach (GameObject window in windows) {
            windowScript = window.GetComponent<CharacterWindow>();
            if (missionParty[role] == windowScript.ID) {
                missionParty[role] = -1;
                windowScript.isSelected = false;
            }
        }
    }
    public void SelectCharacter(int id) {
        selectedCharacter = id;
    }

    public void btnGoToMission() {
        //skriver över missionArray i en fil
    }
    
}
