﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partySelectorScript : MonoBehaviour { //Borde kanske vara ParytSetupScript eller SetupScript
    public GameObject characterWindow, roleWindow;
    private GameObject characterWindowO, roleWindowO;
    private GameObject[] characters, roles, windows;
    public int ammoutOfRole;
    private int selectedCharacter;
    private int id;
    private float contreverter; //1 här = 78.55004 i spelet av någon anledning, skriv in koordinaterna o dela de men konverteraren
    private Vector3 characterWindowPos, roleWindowPos;
    private CharacterScript characterScript;
    private CharacterWindow windowScript;
    private btnAppointScript roleScript;
    private int[] missionParty; //Denna intArray ska spara id för karaktärena som ska på mission

    void Start() {
        //Skriva ut character rutor för varje karaktär
        contreverter = 78.55004f;
        characters = GameObject.FindGameObjectsWithTag("Character");
        windows = GameObject.FindGameObjectsWithTag("CharacterWindow");
        selectedCharacter = -1;
        
        missionParty = new int[5]; //Femman är hur många roller som kan vara på mission... ska vi ha oändligt kommer nog inte en array att fungera
        for (int i = 0; i < missionParty.Length; i++) {
            missionParty[i] = (int)(100/contreverter);
        }
        CreateCharacterWindow();
        CreateRoleWindow();
    }

    private void CreateCharacterWindow() {
        characterWindowPos = new Vector3(-162.5f / contreverter, 300 / contreverter, 0);

        foreach (GameObject character in characters) { //Kan någon kolla varför de skrivs ut på ett så konstigt ställe?
            characterScript = character.GetComponent<CharacterScript>();
            characterWindowO = Instantiate(characterWindow);
            characterWindowO.transform.parent = GameObject.Find("CharacterWindowManager").transform;
            characterWindowO.GetComponent<CharacterWindow>().GetInfo(characterScript.name, characterScript.id); //Vad används denna till?
            characterWindowO.transform.localScale = new Vector3(1, 1, 1);
            characterWindowO.transform.position = characterWindowPos;
            characterWindowPos.y -= 100 / contreverter;

            //Implementera en scroll funktion om man har fler än x antal karaktärer?
        }
    }

    private void CreateRoleWindow() {
        roleWindowPos = new Vector3(162.5f / contreverter, 300 / contreverter, 0);

        for (int i = 0; i < ammoutOfRole; i++) {
            roleWindowO = Instantiate(roleWindow);
            roleWindowO.transform.parent = GameObject.Find("RoleWindowManager").transform;
            roleWindowO.transform.localScale = new Vector3(1, 1, 1);
            roleWindowO.transform.position = roleWindowPos;
            roleWindowO.GetComponent<btnAppointScript>().roleId = i;
            roleWindowPos.y -= 100 / contreverter;
        }
    }


    public int AppointCharacter(int role) { //Lägger till karaktärens id till arren med id för karaktärer som går på mission
        windows = GameObject.FindGameObjectsWithTag("CharacterWindow");
        if (selectedCharacter >= 0) { 
            foreach (GameObject window in windows) {
                windowScript = window.GetComponent<CharacterWindow>();
                if(windowScript.ID == selectedCharacter) {
                    missionParty[role] = selectedCharacter;
                    windowScript.ShowBtn(true);
                }
            }

            //Diseabla alla appoint knappar
            id = selectedCharacter;
            selectedCharacter = -1; //För att se till att inte samma karaktär kan vara på flera platser
            return id;
        }
        return -1;

    }

    public void RemoveCharacter(int role) { //tar bort en karaktärs id från arrayen med id så att karaktären inte går på mission eller kan vara på en annan roll
        foreach (GameObject window in windows) {
            windowScript = window.GetComponent<CharacterWindow>();
            if (missionParty[role] == windowScript.ID) {
                missionParty[role] = -1;
                windowScript.ShowBtn(false);
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
