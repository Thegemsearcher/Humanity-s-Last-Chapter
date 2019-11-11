using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSlotManager : MonoBehaviour {
    public GameObject saveSlot;
    private GameObject saveHolder, parent;

    private int saveCounter;
    private string path;

    void Start() {
        path = Application.persistentDataPath + "/Saves/";
        saveCounter = Directory.GetFiles(path).Length;
        parent = GameObject.FindGameObjectWithTag("forSaves");

        for (int i = 0; i < saveCounter; i++) {
            if (!File.Exists(path + "save" + i + ".save")) {
                Debug.Log("Save Slot empty!");
                saveCounter++;
            } else {
                SaveData data = SaveSystem.LoadWorld(i);
                saveHolder = Instantiate(saveSlot);
                saveHolder.GetComponent<SaveSlot>().activeSave = i;
                saveHolder.transform.SetParent(parent.transform, false);
            }
        }
    }
}
