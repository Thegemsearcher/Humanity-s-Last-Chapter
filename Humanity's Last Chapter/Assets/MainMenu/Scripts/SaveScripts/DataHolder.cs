using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHolder {

    public static DataHolder dataHolder;

    public int activeSave;

    private string path;

    private List<CharacterScript> characterList;
    private List<Stats> statsList;

    public void NewHolder() {
        characterList = new List<CharacterScript>();
        statsList = new List<Stats>();

        if(Assets.assets == null) {
            Assets.assets = new Assets();
            Assets.assets.GetAssets();
        }

        path = Application.persistentDataPath + "/Saves/";
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
        if (File.Exists(path + "save" + activeSave + ".save")) {
            WorldData(activeSave);
            StartGame();
        } else {
            Debug.Log("Can't find Save" + activeSave);
        }
        
    }

    public void BtnDelete() {
        if(File.Exists(path + "save" + activeSave + ".save")) {
            FileUtil.DeleteFileOrDirectory(path + "save" + activeSave + ".save");
            Debug.Log("Deleted: save" + activeSave);
        } else {
            Debug.Log("Can't find Save" + activeSave);
        }
        
    }

    private void WorldData(int saveNr) {
        SaveData data = SaveSystem.LoadWorld(saveNr);

        WorldScript.world = new WorldScript();
        WorldScript.world.gold = data.worldData.gold;
        WorldScript.world.rs = data.worldData.rs;
        WorldScript.world.saveNr = data.worldData.saveNr;
        WorldScript.world.storageSize = data.worldData.storageSize;
        WorldScript.world.shopSize = data.worldData.shopSize;
        WorldScript.world.shopLevel = data.worldData.shopLevel;
        WorldScript.world.storageArr = data.worldData.storageArr;
        WorldScript.world.shopArr = data.worldData.shopArr;
        WorldScript.world.isActive = data.worldData.isActive;

        foreach (CharacterData characterData in data.characterDataList) {
            
            CharacterScript character = new CharacterScript();
            character.id = characterData.id;
            character.strName = characterData.strName;
            character.rangedId = characterData.wpId;
            character.itemID = characterData.itemID;
            characterList.Add(character);

            Stats stats = new Stats();
            stats.hp = characterData.hp;
            stats.maxHp = characterData.maxHp;

           
            stats.quirkIDList = characterData.quirkID;

            stats.shit = characterData.shit;

            stats.str = characterData.str;
            stats.def = characterData.def;
            stats.Int = characterData.Int;
            stats.dex = characterData.dex;
            stats.cha = characterData.cha;
            stats.ldr = characterData.ldr;
            stats.snt = characterData.snt;
            stats.exp = characterData.exp;
            statsList.Add(stats);
        }
        
        WorldScript.world.characterList = characterList;
        WorldScript.world.statsList = statsList;
    }

    private void StartGame() {
        SceneManager.LoadScene("Hub"); //Kanske ska worldScript ha koll på active scene?
    }
}
