using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    public string name = "";
    public int health, id;
    private string[] firstName = { "Fred", "Greg", "Meg", "Yrg" };
    private string[] lastName = { "McGreg", "SaintYeet", "SoonDed" };
    public string wpId;
    public string[] itemID;
    public bool inHospital, isEnlisted;

    private stats statsScript;

    void Start() {
        statsScript = GetComponent<stats>();
        itemID = new string[6];
        if (name == "") {
            name = NameGenerator();
            id = GetId();
            wpId = "wp0";
        }
    }

    private string NameGenerator() {
        name = firstName[(int)Random.Range(0, firstName.Length)] + " " + lastName[(int)Random.Range(0, lastName.Length)];
        return name;
    }

    private int GetId() {
        int characterCounter = GameObject.FindGameObjectWithTag("CharacterManager").transform.childCount;
        //Debug.Log("characterCounter: " + characterCounter);
        id = characterCounter - 1;
        return id;
    }

    public void SavePlayer() {
        int i = 0;
        foreach (Transform item in gameObject.GetComponent<stats>().characterUI.transform.GetChild(3).transform) {
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

        if(isEnlisted) {
            statsScript.hp -= 2;
        }
        SaveSystem.SaveCharacter(this, GetComponent<stats>());
    }

    public void LoadPlayer(int id) {
        CharacterData data = SaveSystem.LoadCharacter(id);

        this.name = data.name;
        this.health = data.health;
        this.id = data.id;
        this.itemID = data.itemID;
        GetComponent<stats>().GetStats(data.maxHp, data.hp);
    }

    public void GetID() {
        id = GetId();
    }
    
}
