using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMissionScript : MonoBehaviour {

    public GameObject MissionBox;
    private GameObject holder;

    public void GetActiveQuest() {
        holder = Instantiate(MissionBox);
        holder.GetComponent<MissionBoxScript>().GetQuest(WorldScript.world.activeQuest);
        holder.transform.SetParent(gameObject.transform, false);
    }
}
