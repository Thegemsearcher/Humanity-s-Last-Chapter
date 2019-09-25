using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManagerScript : MonoBehaviour {
    public GameObject selectParty;
    
    public void btnSetup() {
        selectParty.SetActive(true);
    }
}
