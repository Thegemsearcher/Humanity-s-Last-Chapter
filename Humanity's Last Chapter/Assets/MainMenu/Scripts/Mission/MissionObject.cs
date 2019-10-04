using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    [System.Serializable]
    public class MissionObject : ScriptableObject { //Tänk ut ett sätt att skapa id... tror det är bäst att ha id = mix där mi står för att det är ett mission och x är antalet missions som finns

        public string missionName = "Mission name Here";    //Name
        public string description;                          //Description
        public string hint;                                 //Mission hint
        public string dialog;                               //dialog
        public string sourceID;                             //SourceID
        public string missionID;                            //MissionID
        public string nextMissionID;                        //Next mission ID
        public bool isChainMission;                         //Chain mission
        public int goldReward, rsReward;                    //Reward
        public bool avalible, active, completed;            //Missionstatus
        public string[] objectives;                         //Objectives
        public string[] bonusObjective;                     //Bonus Objective
        public string[] missionEvents;                      //Events
        private IMissionInformation information;
        public IMissionInformation Information {
            get {
                return information;
            }
        }
    }
}
 
