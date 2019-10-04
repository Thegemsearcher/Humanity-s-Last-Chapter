
namespace QuestSystem {
    public interface IMissionInformation {
        
        string Name { get; }
        string Description { get; }
        string Hint { get; }
        string Dialog { get; }
        string SourceID { get; }
        string MissionID { get; }
        string ChainMissionID { get; }
        bool HasChainMission { get; }
    }
}

//Name
//Description
//Mission hint
//dialog
//SourceID
//MissionID
//Next mission ID
//Chain mission
//Reward
//Missionstatus
//Objectives
//Bonus Objective
//Events

