using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldScript {

    public static WorldScript world;

    public int gold, rs, saveNr;
    public bool isActive; //Den sparningen som startar om man klickar continue

    public List<CharacterScript> characterList;
    public List<Stats> statsList;

    private GameObject[] characterArr;

    public void Reset() {
        characterList = new List<CharacterScript>();
        statsList = new List<Stats>();
        gold = 400;
        isActive = true;
        rs = 0;
        saveNr = 0;
    }

    public void Save() {
        characterList.Clear();
        statsList.Clear();

        characterArr = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in characterArr) {
            characterList.Add(character.GetComponent<CharacterScript>());
            statsList.Add(character.GetComponent<Stats>());
        }
        SaveSystem.SaveWorld(this);
    }

    public void Load() {
        
    }

}
