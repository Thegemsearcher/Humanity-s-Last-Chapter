using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldScript : MonoBehaviour {
    public TextMeshProUGUI txtGold, txtRS;
    public int gold, rs, saveSlot;

    void Start() {
        gold = 200;
        rs = 0;

        saveSlot = 0; //Behöver får denna från MainMenu
    }

    // Update is called once per frame
    void Update() {
        txtGold.text = gold.ToString();
        txtRS.text = rs.ToString();
    }
}
