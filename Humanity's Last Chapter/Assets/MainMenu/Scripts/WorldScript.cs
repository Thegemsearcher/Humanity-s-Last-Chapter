using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldScript : MonoBehaviour {
    public TextMeshProUGUI txtGold, txtRS;
    public int gold, rs;

    void Start() {
        gold = 200;
        rs = 0;
    }

    // Update is called once per frame
    void Update() {
        txtGold.text = gold.ToString();
        txtRS.text = rs.ToString();
    }
}
