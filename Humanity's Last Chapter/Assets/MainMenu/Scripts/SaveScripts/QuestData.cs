using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData {
    public string id;
    public int questStage;

    public QuestData(string id, int questStage) {
        this.id = id;
        this.questStage = questStage;
    }
}
