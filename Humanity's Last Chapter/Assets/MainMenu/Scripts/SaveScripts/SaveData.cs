using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public List<CharacterData> characterDataList;
    public WorldData worldData;

    public SaveData(List<CharacterData> characterDataList, WorldData worldData) {
        this.characterDataList = characterDataList;
        this.worldData = worldData;
    }
}
