using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldData {

    //public List<CharacterScript> characterList;
    public int gold, rs, saveNr;
    public bool isActive; //Den sparningen som startar om man klickar continue

    public WorldData(WorldScript gameData) {
        gold = gameData.gold;
        rs = gameData.rs;
        saveNr = gameData.saveNr;
        isActive = gameData.isActive;
    }

    //Denna ska användas vid load av alla scener och uppdateras vid scenbyte!
}
