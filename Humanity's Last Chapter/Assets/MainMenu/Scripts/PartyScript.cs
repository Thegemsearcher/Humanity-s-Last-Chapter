using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyScript : MonoBehaviour {
    GameObject characterO;
    public GameObject character;
    int characterCounter;

    void Start() {
        characterCounter = System.IO.Directory.GetFiles(Application.persistentDataPath + "/Characters/").Length;
        for (int i = 0; i < characterCounter; i++) { //Gör vi såhär så raderar vi inte character utan kanske har en bool som säger om de ska visas eller inte
            characterO = Instantiate(character, new Vector2(0, 0), Quaternion.identity) as GameObject;
            characterO.transform.parent = GameObject.Find("PCManager").transform;
            characterO.GetComponent<CharacterScript>().LoadPlayer(i);
        }
    }
}
