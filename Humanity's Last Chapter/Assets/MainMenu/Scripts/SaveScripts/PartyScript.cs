using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyScript : MonoBehaviour {
    GameObject characterO;
    public GameObject character;
    int characterCounter;

    void Start() {
        characterCounter = System.IO.Directory.GetFiles(Application.persistentDataPath + "/Characters/").Length; //Ska fixa att den läser av från /Party/ när den är redo
        for (int i = 0; i < characterCounter; i++) { //Gör vi såhär så raderar vi inte character utan kanske har en bool som säger om de ska visas eller inte
            characterO = Instantiate(character) as GameObject;
            characterO.transform.parent = GameObject.FindGameObjectWithTag("CharacterManager").transform;
            characterO.transform.localScale = new Vector3(170, 170, 1);
            characterO.GetComponent<CharacterScript>().LoadPlayer(i);
        }
    }
}
