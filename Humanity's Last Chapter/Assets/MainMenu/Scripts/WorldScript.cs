using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldScript {

    public static WorldScript world;

    public int gold, rs, saveNr, storageSize;
    public bool isActive; //Den sparningen som startar om man klickar continue

    public string[] storageArr;

    public List<CharacterScript> characterList;
    public List<Stats> statsList;

    private GameObject[] characterArr;

    public void Reset() {
        characterList = new List<CharacterScript>();
        statsList = new List<Stats>();
        storageSize = 64;
        storageArr = new string[storageSize];

        gold = 400;
        isActive = true;
        rs = 0;
        saveNr = 0;

        ClearInventory();

        AddItem("hi0", 3);
        AddItem("hi1", 2);

        AddItem("wp1", 2);
        AddItem("wp2", 1);
    }

    public void ClearInventory() {
        for (int i = 0; i < storageSize; i++) {
            storageArr[i] = "";
        }
    }

    public void AddItem(string id, int amount) {
        for(int i = 0; i < amount; i++) {
            for(int j = 0; j < storageSize; j++) {
                if(storageArr[j] == "") {
                    storageArr[j] = id;
                    break;
                }
            }
        }
    }

    public void MoveItem(int oldSpot, int newSpot, string id) {
        storageArr[oldSpot] = "";
        storageArr[newSpot] = id;
        Debug.Log("OldSpot : " + oldSpot + " storageArr[" + oldSpot + "]: " + storageArr[oldSpot]);
        //Create Item igen
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
