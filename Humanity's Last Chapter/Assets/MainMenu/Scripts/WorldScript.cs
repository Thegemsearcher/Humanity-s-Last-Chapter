﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldScript {

    public static WorldScript world;

    public int gold, rs, storageSize, shopSize, shopLevel, date, supplies, goods, partySize;
    public bool isActive, isNewGame; //Den sparningen som startar om man klickar continue
    public string saveName, saveId;
    private bool isChoosing, hasGoodsQuest;
    private int itemTest;

    public string[] storageArr, shopArr;

    public List<CharacterScript> characterList;
    public List<Stats> statsList;


    public ScriptableQuest activeQuest;
    public List<ScriptableQuest> avalibleQuests;
    public List<ScriptableQuest> completedQuests;
    public List<ScriptableQuest> failedQuests;
    public List<RoleObject> activeRoles;

    private GameObject[] characterArr;

    public void Reset() {
        characterList = new List<CharacterScript>();
        statsList = new List<Stats>();

        avalibleQuests = new List<ScriptableQuest>();
        completedQuests = new List<ScriptableQuest>();
        failedQuests = new List<ScriptableQuest>();
        activeRoles = new List<RoleObject>();

        isNewGame = true;
        storageSize = 64;
        shopSize = 10;
        shopLevel = 1;
        storageArr = new string[storageSize];
        shopArr = new string[shopSize];
        partySize = 4;

        gold = 400;
        isActive = true;
        rs = 0;
        saveId = "save0";
        saveName = "New World";
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
        //Create Item igen
    }

    public void SaveHub(bool isAuto) {
        characterList.Clear();
        statsList.Clear();
        Debug.Log("Characters(HubSave): " + characterList.Count);
        characterArr = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in characterArr) {
            if (character.GetComponent<Stats>().hp > 0) {
                characterList.Add(character.GetComponent<CharacterScript>());
                statsList.Add(character.GetComponent<Stats>());
            }
        }
        SaveSystem.SaveWorld(this, isAuto);
    }

    public void SaveMission(bool isAuto) {
        Debug.Log("Characters(MissionSave): " + characterList.Count);
        characterArr = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject character in characterArr) {
            if (character.GetComponent<CharacterScript>().isEnlisted) {
                if (character.GetComponent<Stats>().hp > 0) {
                    characterList.Add(character.GetComponent<CharacterScript>());
                    statsList.Add(character.GetComponent<Stats>());
                }
            }
        }
        SaveSystem.SaveWorld(this, isAuto);
    }

    public void RemoveAvalible(ScriptableQuest quest) {
        foreach (ScriptableQuest avalibleQuest in avalibleQuests) {
            if (quest.name == avalibleQuest.name) {
                avalibleQuests.Remove(avalibleQuest);
                break;
            }
        }
    }

    public void GetQuests(List<ScriptableQuest> avalibleQuests, List<ScriptableQuest> completedQuests, List<ScriptableQuest> failedQuests) {
        this.avalibleQuests = avalibleQuests;
        this.completedQuests = completedQuests;
        this.failedQuests = failedQuests;
    }

    public void RefreshHub() {
        FillShop();

        if (supplies >= 20) {
            supplies -= 20;
            goods += 10;
        } else {
            goods += (supplies / 2);
            supplies = 0;
        }
    }
}
