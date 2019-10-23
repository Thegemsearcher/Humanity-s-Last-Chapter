using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyScript : MonoBehaviour {
    private GameObject characterO;
    public GameObject character, UIHealth;
    int characterCounter;
    private int[] missionOrder;
    private stats characterStats;
    private CharacterScript characterScript;
    private UIHealthBoi uiHealth;

    void Start() {
        //characterCounter = System.IO.Directory.GetFiles(Application.persistentDataPath + "/Characters/").Length; //Ska fixa att den läser av från /Party/ när den är redo
        //for (int i = 0; i < characterCounter; i++) { //Gör vi såhär så raderar vi inte character utan kanske har en bool som säger om de ska visas eller inte
        //    characterO = Instantiate(character) as GameObject;
        //    characterO.transform.parent = GameObject.FindGameObjectWithTag("CharacterManager").transform;
        //    characterO.transform.localScale = new Vector3(170, 170, 1);
        //    characterO.GetComponent<CharacterScript>().LoadPlayer(i);
        //}

        missionOrder = SaveSystem.LoadPartyOrder();
        for (int i = 0; i < missionOrder.Length; i++) {
            if(missionOrder[i] >= 0) {
                CreateCharacter(i);
            }
        }
    }

    public void CreateCharacter(int i) {
        characterO = Instantiate(character) as GameObject;
        //characterO.transform.parent = GameObject.FindGameObjectWithTag("CharacterManager").transform;
        characterO.transform.localScale = new Vector3(1, 1, 1);
        characterO.transform.position = new Vector3(1, 1);
        characterO.GetComponent<CharacterScript>().LoadPlayer(missionOrder[i]);
        
        characterO.GetComponent<PersonalMovement>().relativePos = new Vector3(i, i);
        characterO.GetComponent<PersonalMovement>().AddRelativeWaypoint(transform.position);
        //rollen karaktären har borde gå att bestämmas med i
        gameObject.GetComponent<CharacterMovement>().AddPc(characterO);

        characterStats = characterO.GetComponent<stats>();
        characterScript = characterO.GetComponent<CharacterScript>();
        CreateUI(characterScript, characterStats);
    }
    
    public void CreateUI(CharacterScript characterScript, stats characterStats) {
        characterO = Instantiate(UIHealth);
        uiHealth = characterO.GetComponent<UIHealthBoi>();
        uiHealth.GetData(characterScript.name, characterScript.id, characterStats.hp, characterStats.maxHp);
        characterO.transform.SetParent(GameObject.Find("forCharacter").transform, false);
    }
}
