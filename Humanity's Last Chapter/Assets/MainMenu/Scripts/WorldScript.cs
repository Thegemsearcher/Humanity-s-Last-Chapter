using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldScript {

    public static WorldScript world;

    public int gold, rs, saveNr, storageSize, shopSize, shopLevel, date;
    public bool isActive; //Den sparningen som startar om man klickar continue
    private bool isChoosing;
    private int itemTest;

    public string[] storageArr, shopArr;

    public List<CharacterScript> characterList;
    public List<Stats> statsList;

    private GameObject[] characterArr;

    public void Reset() {
        characterList = new List<CharacterScript>();
        statsList = new List<Stats>();
        storageSize = 64;
        shopSize = 10;
        shopLevel = 1;
        storageArr = new string[storageSize];
        shopArr = new string[shopSize];

        gold = 400;
        isActive = true;
        rs = 0;
        saveNr = 0;
        date = 1;

        ClearInventory();
        ClearShop();

        AddItem("hi0", 3);
        AddItem("hi1", 2);

        AddItem("wp1", 2);
        AddItem("wp2", 1);

        FillShop();
    }

    public void ClearInventory() {
        for (int i = 0; i < storageSize; i++) {
            storageArr[i] = "";
        }
    }

    public void ClearShop() {
        for (int i = 0; i < shopSize; i++) {
            shopArr[i] = "";
        }
    }

    public void FillShop() {
        for (int i = 0; i < shopSize; i++) {
            isChoosing = true;
            switch (Random.Range(0,2)) {
                case 0: //Weapon
                    while (isChoosing) {
                        itemTest = Random.Range(0, Assets.assets.weaponTemp.Length);
                        if (Assets.assets.weaponTemp[itemTest].wpLevel <= shopLevel) {
                            shopArr[i] = "wp" + itemTest;
                            isChoosing = false;
                        }
                    }
                    break;
                case 1: //Healing
                    shopArr[i] = "hi" + Random.Range(0, Assets.assets.healingTemp.Length);
                    break;
                case 2: //Combat
                    shopArr[i] = "ci" + Random.Range(0, Assets.assets.combatTemp.Length);
                    break;
            }
            
        }
    }
    public void AddToStore(string id, int amount) {
        for (int i = 0; i < amount; i++) {
            for (int j = 0; j < shopSize; j++) {
                if (shopArr[j] == "") {
                    shopArr[j] = id;
                    break;
                }
            }
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
