using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem {
    public interface IQuestIdentifier {

        string ID { get; }
        string ChainQuestID { get; }
        string SourceID { get; }
    }
}

