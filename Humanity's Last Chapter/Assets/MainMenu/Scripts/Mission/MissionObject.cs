using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionObject : ScriptableObject { //Tänk ut ett sätt att skapa id... tror det är bäst att ha id = mix där mi står för att det är ett mission och x är antalet missions som finns

    public string missionName = "Mission name Here";
    public int goldReward, rsReward;
    public string description;
    public bool avalible, active, completed;
}
