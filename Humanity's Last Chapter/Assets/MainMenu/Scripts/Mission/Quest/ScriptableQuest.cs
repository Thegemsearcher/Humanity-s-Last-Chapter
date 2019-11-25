using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class ScriptableQuest : ScriptableObject {

    public string missionName = "Mission name Here";    //Name
    public string description;                          //Description
    public string hint;                                 //Mission hint
    public string dialog;                               //dialog
    public ScriptableQuest nextMission;                 //Next mission
    public bool isChainMission;                         //Chain mission
    public int goldReward, rsReward;                    //Reward
    public bool avalible, active, completed;            //Missionstatus
    public string[] bonusObjective;                     //Bonus Objective
    public string[] missionEvents;                      //Events
    public Object[] objectives;                         //Quests that will be used...
}
