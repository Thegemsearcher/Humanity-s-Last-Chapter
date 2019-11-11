using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldScript {

    public static WorldScript world;

    public int gold, rs, saveNr;
    public bool isActive; //Den sparningen som startar om man klickar continue

    public List<string> storageList;

    public List<CharacterScript> characterList;
    public List<Stats> statsList;

    private GameObject[] characterArr;

    public void Reset() {
        characterList = new List<CharacterScript>();
        storageList = new List<string>();
        statsList = new List<Stats>();
        gold = 400;
        isActive = true;
        rs = 0;
        saveNr = 0;

        AddItem("hi0", 3);
        AddItem("hi1", 2);

        AddItem("wp1", 2);
        AddItem("wp2", 1);
    }

    public void AddItem(string id, int amount) {
        for(int i = 0; i < amount; i++) {
            storageList.Add(id);
        }
    }

    public void Save() {
        characterList.Clear();
        statsList.Clear();

        characterArr = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in characterArr) {
            if (character.GetComponent<Stats>().hp > 0) {
                characterList.Add(character.GetComponent<CharacterScript>());
                statsList.Add(character.GetComponent<Stats>());
            }
        }
        SaveSystem.SaveWorld(this);
    }

    public void Load() {
        
    }

}
