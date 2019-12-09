using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMissionScript : MonoBehaviour {

    public GameObject MissionBox;
    private GameObject holder;
    private ScriptableQuest activeQuest, newQuest;

    public void GetActiveQuest() {
        newQuest = WorldScript.world.activeQuest;

        if (activeQuest != null) {
            if (!newQuest == activeQuest) {
                holder = Instantiate(MissionBox);
                holder.GetComponent<MissionBoxScript>().GetQuest(newQuest);
                holder.transform.SetParent(gameObject.transform, false);
                activeQuest = newQuest;
            }
        } else {
            holder = Instantiate(MissionBox);
            holder.GetComponent<MissionBoxScript>().GetQuest(newQuest);
            holder.transform.SetParent(gameObject.transform, false);
            activeQuest = newQuest;
        }
        
        
    }
}
