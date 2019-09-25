using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterWindow : MonoBehaviour {
    public Texture2D imgPortrait;
    public Text txtInfo, txtName, txtTraits;
    string info, name, traits;
    int ID;

    private void Start() {
        info = "C: - S: - R: - N: - E: -";
        traits = "Traits: -";
        txtInfo.text = info;
        txtTraits.text = traits;
    }

    public void GetInfo(string name, int ID) {
        this.name = name;
        this.ID = ID;
        txtName.text = name;
    }
}
