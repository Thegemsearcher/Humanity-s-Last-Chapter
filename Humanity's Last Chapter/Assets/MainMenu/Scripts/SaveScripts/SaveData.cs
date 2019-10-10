using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {

    public List<CharacterScript> characterList;
    public List<stats> statsList;
    public List<ScriptableQuest> questList;
    public WorldScript world;

    public SaveData(List<CharacterScript> characterList, List<stats> statsList, List<ScriptableQuest> questList, WorldScript world) {
        this.characterList = characterList;
        this.statsList = statsList;
        this.questList = questList;
        this.world = world;
    }

    //Denna ska användas vid load av alla scener och uppdateras vid scenbyte!
}
