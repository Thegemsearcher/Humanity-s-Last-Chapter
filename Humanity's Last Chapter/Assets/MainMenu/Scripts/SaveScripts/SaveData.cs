using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {
    public List<CharacterData> characterDataList;
    public List<QuestData> questDataList;
    public WorldData worldData;

    public SaveData(List<CharacterData> characterDataList, List<QuestData> questDataList, WorldData worldData) {
        this.characterDataList = characterDataList;
        this.questDataList = questDataList;
        this.worldData = worldData;
    }
}
