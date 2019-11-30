using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour {

    public int activeSave;
    public string saveId, saveName;
    public Text txtSaveName;

    private void Start() {
        Debug.Log("SaveId: " + saveId + "\nSaveName: " + saveName);
        if (saveName == "" || saveName == null) {
            saveName = saveId;
        }
        txtSaveName.text = "Save - " + saveName;
    }

    public void ActivateSave() {
        DataHolder.dataHolder.activeSave = activeSave;
    }
}
