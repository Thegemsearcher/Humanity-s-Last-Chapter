using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHolder : MonoBehaviour {
    private int activeSave;

    private int saveCounter;
    private string path;

    private int[] saveNrArr;

    private List<CharacterScript> characterList;
    private List<Stats> statsList;

    void Start() {
        characterList = new List<CharacterScript>();
        statsList = new List<Stats>();

        path = Application.persistentDataPath + "/Saves/";
        saveCounter = Directory.GetFiles(path).Length;

        saveNrArr = new int[saveCounter];
        for (int i = 0; i < saveCounter; i++) {
            SaveData data = SaveSystem.LoadWorld(i);
            if(data == null) {
                Debug.Log("Save Slot empty!");
                //saveCounter++;

            } else {
                saveNrArr[i] = data.worldData.saveNr;
            }
        }
    }

    public void BtnContinue() {
        //foreach (int saveNr in saveNrArr) {
        //    if(save.isActive) {
        //        WorldScript.world = save;
        //        Debug.Log("Loaded: save" + save.saveNr);
        //        StartGame();
        //    }
        //}
        Debug.Log("To be fixed!");
    }

    public void BtnNewGame() {
        bool isFree = true;
        int testSave = 0;
        while(isFree) {
            if(!File.Exists(path + "save"+testSave+".save")) {
                WorldScript.world = new WorldScript();
                WorldScript.world.Reset();
                WorldScript.world.saveNr = testSave;
                isFree = false;
            }
            else {
                testSave++;
            }
        }
        StartGame();
    }

    public void BtnPlay() {
        foreach (int saveNr in saveNrArr) {
            if (saveNr == activeSave) {
                WorldData(saveNr);
                break;
            }
        }
        StartGame();
    }

    public void BtnDelete() {
        foreach (int saveNr in saveNrArr) {
            if (saveNr == activeSave) {
                FileUtil.DeleteFileOrDirectory(path + "/Saves/save"+saveNr);
                Debug.Log("Deleted: save" + saveNr);
                break;
            }
        }
    }

    private void WorldData(int saveNr) {
        SaveData data = SaveSystem.LoadWorld(saveNr);

        WorldScript.world = new WorldScript();
        WorldScript.world.gold = data.worldData.gold;
        WorldScript.world.rs = data.worldData.rs;
        WorldScript.world.saveNr = data.worldData.saveNr;
        WorldScript.world.isActive = data.worldData.isActive;

        foreach (CharacterData characterData in data.characterDataList) {
            
            CharacterScript character = new CharacterScript();
            character.id = characterData.id;
            character.health = characterData.health;
            character.strName = characterData.strName;
            character.wpId = characterData.wpId;
            character.itemID = characterData.itemID;
            characterList.Add(character);

            Stats stats = new Stats();
            stats.hp = characterData.hp;
            stats.maxHp = characterData.maxHp;
            statsList.Add(stats);
            
        }
        
        WorldScript.world.characterList = characterList;
        WorldScript.world.statsList = statsList;
    }

    private void StartGame() {
        SceneManager.LoadScene("Hub"); //Kanske ska worldScript ha koll på active scene?
    }

    public void GetSave(int activeSave) {
        this.activeSave = activeSave;
    }
}
