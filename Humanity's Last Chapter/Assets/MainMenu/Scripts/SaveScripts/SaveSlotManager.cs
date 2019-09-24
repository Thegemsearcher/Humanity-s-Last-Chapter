using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSlotManager : MonoBehaviour {
    public int activeSave;
    private string path;
    private int characterCounter;

    void Start() {
        path = Application.persistentDataPath;

        if (!Directory.Exists(Application.persistentDataPath + "/SaveSlot1")) {
            BinaryFormatter formatter = new BinaryFormatter();
            for (int i = 1; i <= 9; i++) {
                Directory.CreateDirectory(path + "/SaveSlot" + i);
                Directory.CreateDirectory(path + "/SaveSlot" + i + "/Party");
                Directory.CreateDirectory(path + "/SaveSlot" + i + "/Characters");
            }
        }
    }

    public void SetSlot(int save) {
        activeSave = save;
        //Ska unselecta alla andra slots
    }

    public void DeleteSave() {
        path = Application.persistentDataPath + "/SaveSlot" + activeSave;
        characterCounter = Directory.GetFiles(path + "/Characters/").Length;
        for (int i = 0; i < characterCounter; i++) { //Detta är baserat på att det inte kan finnas flera characterer i party än som finns
            if (Directory.Exists(path + "/Party/Character(" + i + ").txt")) {
                FileUtil.DeleteFileOrDirectory(path + "/Party/Character(" + i + ").txt");
            }
            FileUtil.DeleteFileOrDirectory(path + "/Characters/Character(" + i + ").txt");
        }

        //Kan tas bort när vi använder endast saveSlots
        characterCounter = Directory.GetFiles(Application.persistentDataPath + "/Characters/").Length;
        for (int i = 0; i < characterCounter; i++) {
            if (Directory.Exists(Application.persistentDataPath + "/Party/Character(" + i + ").txt")) { 
                FileUtil.DeleteFileOrDirectory(Application.persistentDataPath + "/Party/Character(" + i + ").txt");
            }
            FileUtil.DeleteFileOrDirectory(Application.persistentDataPath + "/Characters/Character(" + i + ").txt");
        }


    }
}
