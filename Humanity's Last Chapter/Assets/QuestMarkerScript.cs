using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarkerScript : MonoBehaviour
{
    Transform[] position;
    GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<MissionMarker>
      

        position = GameObject.FindGameObjectWithTag("Marker").GetComponent<QuestObject>().GetQuestLocation();
       transform.position = position[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        position = GameObject.FindGameObjectWithTag("Marker").GetComponent<QuestObject>().GetQuestLocation();
        transform.position = position[0].position;
    }
}
