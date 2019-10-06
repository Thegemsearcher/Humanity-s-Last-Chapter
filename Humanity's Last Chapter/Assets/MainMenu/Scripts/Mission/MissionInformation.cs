using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    public class MissionInformation : IMissionInformation {

        private string name, description, hint, dialog, sourceID, missionID, chainMissionID;
        private bool hasChainMission;

        public string Name {
            get {
                return name;
            }
        }
        public string Description {
            get {
                return description;
            }
        }
        public string Hint {
            get {
                return hint;
            }
        }
        public string Dialog {
            get {
                return dialog;
            }
        }
        public string SourceID {
            get {
                return sourceID;
            }

        }
        public string MissionID {
            get {
                return missionID;
            }

        }
        public string ChainMissionID {
            get {
                return chainMissionID;
            }

        }
        public bool HasChainMission {
            get {
                return hasChainMission;
            }

        }
    }
}

