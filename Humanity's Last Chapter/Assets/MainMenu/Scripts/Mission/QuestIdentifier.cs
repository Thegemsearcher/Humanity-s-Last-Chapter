using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    public class QuestIdentifier : IQuestIdentifier {
        private string id, chainQuestID, sourceID;

        public string ID {
            get {
                return id;
            }
        }

        public string ChainQuestID {
            get {
                return chainQuestID;
            }
        }

        public string SourceID {
            get {
                return sourceID;
            }
        }
    }
}

