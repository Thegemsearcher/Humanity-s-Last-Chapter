using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBoxScript : MonoBehaviour {

    public Text txtName;

    public void GetQuest(string questName) {
        txtName.text = questName;
    }
}
