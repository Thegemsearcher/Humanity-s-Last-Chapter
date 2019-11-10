using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterScript : MonoBehaviour {
    public string strName = "";
    public int health, id;
    private string[] firstName = { "Fred", "Greg", "Meg", "Yrg" };
    private string[] lastName = { "McGreg", "SaintYeet", "SoonDed" };
    public string wpId;
    public string[] itemID;
    public bool inHospital, isEnlisted;

    private Stats statsScript;

    void Start() {
        statsScript = GetComponent<Stats>();
        itemID = new string[6];
        if (strName == "") {
            strName = NameGenerator();
            id = GetId();
            wpId = "wp0";
        }
    }

    private string NameGenerator() {
        strName = firstName[(int)Random.Range(0, firstName.Length)] + " " + lastName[(int)Random.Range(0, lastName.Length)];
        return strName;
    }

    private int GetId() {
        int characterCounter = GameObject.FindGameObjectWithTag("CharacterManager").transform.childCount;
        //Debug.Log("characterCounter: " + characterCounter);
        id = characterCounter - 1;
        return id;
    }

    public void SavePlayer() {
        if (statsScript.hp > 0) {
            int i = 0;
            foreach (Transform item in gameObject.GetComponent<Stats>().characterUI.transform.GetChild(3).transform) {
                if (item.tag == "Item") {
                    if (item.GetComponent<ItemScript>().IsActive()) {
                        itemID[i] = item.GetComponent<ItemScript>().ItemID;
                        i++;
                    }
                }
            }

            if (inHospital) {
                statsScript.hp += 5;
                if (statsScript.hp > statsScript.maxHp) {
                    statsScript.hp = statsScript.maxHp;
                }
            }

            if (isEnlisted) {
                statsScript.hp -= 2;
            }
            SaveSystem.SaveCharacter(this, GetComponent<Stats>());
        } else {
            SaveSystem.DeleteCharacter(this);
        }
    }

    public void LoadPlayer(CharacterScript data) {
        strName = data.strName;
        id = data.id;
        wpId = data.wpId;
        itemID = data.itemID;
        inHospital = data.inHospital;
        isEnlisted = data.isEnlisted;

        //Stats ändringar
        if (inHospital) {
            statsScript.hp += 5;
            if (statsScript.hp > statsScript.maxHp) {
                statsScript.hp = statsScript.maxHp;
            }
        }
    }

    public void GetID() {
        id = GetId();
    }
    
}
