using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour {

    public int activeSave;
    public Text saveName;

    private void Start() {
        saveName.text = "Save - " + activeSave;
    }

    public void ActivateSave() {
        DataHolder.dataHolder.activeSave = activeSave;
    }
}
