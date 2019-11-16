using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldData {

    //public List<CharacterScript> characterList;
    public int gold, rs, saveNr, storageSize, shopSize, shopLevel;
    public string[] storageArr, shopArr;
    public bool isActive; //Den sparningen som startar om man klickar continue

    public WorldData(WorldScript gameData) {
        gold = gameData.gold;
        rs = gameData.rs;
        saveNr = gameData.saveNr;
        storageSize = gameData.storageSize;
        shopSize = gameData.shopSize;
        shopLevel = gameData.shopLevel;
        storageArr = gameData.storageArr;
        shopArr = gameData.shopArr;
        isActive = gameData.isActive;
    }
}
