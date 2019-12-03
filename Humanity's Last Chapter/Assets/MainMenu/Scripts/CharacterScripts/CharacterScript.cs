using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterScript : MonoBehaviour {
    public string strName = "";
    public int id, inventorySize;
    private string[] firstName = { "Fred", "Greg", "Meg", "Yrg" };
    private string[] lastName = { "McGreg", "SaintYeet", "SoonDed" };
    public string rangedId, combatId, healingId, clothId, headId;
    public string[] inventory;
    public bool inHospital, isEnlisted;

    private Stats statsScript;

    void Start() {
        statsScript = GetComponent<Stats>();
        combatId = "ci" + Random.Range(0, Assets.assets.combatTemp.Length);
        healingId = "hi" + Random.Range(0, Assets.assets.healingTemp.Length);
        if (strName == "") {
            inventorySize = 5;
            strName = NameGenerator();
            id = GetId();
            rangedId = "wp" + Random.Range(0, Assets.assets.weaponTemp.Length);
            inventory = new string[inventorySize];
        }
        
    }

    public void NewCharacter(string strName, string clothId, string headId) {
        this.strName = strName;
        this.clothId = clothId;
        this.headId = headId;
    }

    private string NameGenerator() {
        strName = firstName[(int)Random.Range(0, firstName.Length)] + " " + lastName[(int)Random.Range(0, lastName.Length)];
        return strName;
    }

    private int GetId() {
        int characterCounter = GameObject.FindGameObjectWithTag("CharacterManager").transform.childCount;
        id = characterCounter - 1;
        return id;
    }

    public void SavePlayer() {
        if (statsScript.hp > 0) {
            int i = 0;
            foreach (Transform item in gameObject.GetComponent<Stats>().characterUI.transform.GetChild(3).transform) {
                if (item.tag == "Item") {
                    if (item.GetComponent<ItemScript>().IsActive()) {
                        inventory[i] = item.GetComponent<ItemScript>().ItemID;
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
        rangedId = data.rangedId;
        clothId = data.clothId;
        headId = data.headId;
        inventory = data.inventory;
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

    public void OnDeath() {
        PrepareInventory();
        GetComponent<InventoryScript>().GetInventory(inventory, strName);
    }

    private void PrepareInventory() {
        int i = 0;
        if (rangedId != null) {
            inventory[i] = rangedId;
        } else {
            inventory[i] = "";
        }
        i++;

        if (combatId != null) {
            inventory[i] = combatId;
        } else {
            inventory[i] = "";
        }
        i++;

        if (healingId != null) {
            inventory[i] = healingId;
        } else {
            inventory[i] = "";
        }
        i++;

        if (clothId != null) {
            inventory[i] = clothId;
        } else {
            inventory[i] = "";
        }
        i++;

        if (headId != null) {
            inventory[i] = headId;
        } else {
            inventory[i] = "";
        }
    }
    
}
