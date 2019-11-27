using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBox : MonoBehaviour {

    private CharacterScript characterScript;
    public Text txtName;
    public Sprite cloth;

    public GameObject[] itemSlots;
    public GameObject clothSlot;
    public GameObject rangedSlot;

    private GameObject ItemO;

    public GameObject Item;
    private ItemSlotScript iss;
    private GameObject Character, DescParent;

    private string rangedId, clothId;
    private string[] inventoryArr;
    private ItemInfo itemInfo;

    public void GetData(GameObject Character, GameObject DescParent) {
        this.Character = Character;
        this.DescParent = DescParent;
        characterScript = Character.GetComponent<CharacterScript>();
        txtName.text = characterScript.strName;

        //for (int i = 0; i < itemSlots.Length; i++) {
        //    if(characterScript.inventory[i] != "") {
        //        CreateItem(characterScript.inventory[i], itemSlots[i]);
        //    }
        //}

        if (characterScript.rangedId != "") { //Spawnar vapen i weaponSlot
            ItemO = Instantiate(Item);
            ItemO.transform.SetParent(rangedSlot.transform, false);

            rangedId = characterScript.rangedId;
            foreach (WeaponObject weapon in Assets.assets.weaponTemp) {
                if(weapon.name == rangedId) {
                    itemInfo = ItemO.GetComponent<ItemInfo>();
                    itemInfo.GetData(weapon.sprite, weapon.weaponName, weapon.description, weapon.name, weapon.cost);
                    rangedSlot.GetComponent<ItemSlotScript>().GetItem(weapon.weaponName, weapon.description, DescParent);
                }
            }
        }

        //För att ändra kläder!
    }

    private void OnDestroy() {
        if (rangedSlot.GetComponentInChildren<ItemInfo>() != null) {
            rangedId = rangedSlot.GetComponentInChildren<ItemInfo>().id;
        } else {
            rangedId = "";
        }
        
        inventoryArr = new string[itemSlots.Length];
        for (int i = 0; i < inventoryArr.Length; i++) {
            if(itemSlots[i].GetComponentInChildren<ItemInfo>() != null) {
                inventoryArr[i] = itemSlots[i].GetComponentInChildren<ItemInfo>().id;
                characterScript.inventory[i] = inventoryArr[i];
                Debug.Log("ID: " + inventoryArr[i]);
            }
            
        }
        characterScript.rangedId = rangedId;
        //Updaterar characterScript;
    }

    private void CreateItem(string id, GameObject Slot) {
        iss = Slot.GetComponent<ItemSlotScript>();
        switch (id[0]) {
            case 'h': //Healingitem
                foreach (HealingItemObject healing in Assets.assets.healingTemp) {
                    if (healing.name == id) {
                        ItemO = Instantiate(Item);
                        ItemO.transform.SetParent(Slot.transform, false);
                        itemInfo = ItemO.GetComponent<ItemInfo>();
                        itemInfo.GetData(healing.texture, healing.itemName, healing.description, healing.name, healing.cost);
                        iss.GetComponent<ItemSlotScript>().GetItem(healing.itemName, healing.description, DescParent);
                        break;
                    }
                }
                break;

            case 'c':
                foreach (CombatItemObject combat in Assets.assets.combatTemp) {
                    if (combat.name == id) {
                        ItemO = Instantiate(Item);
                        ItemO.transform.SetParent(Slot.transform, false);
                        itemInfo = ItemO.GetComponent<ItemInfo>();
                        itemInfo.GetData(combat.icon, combat.itemName, combat.description, combat.name, combat.cost);
                        iss.GetComponent<ItemSlotScript>().GetItem(combat.itemName, combat.description, DescParent);
                        break;
                    }
                }
                break;

            case 'w':
                foreach (WeaponObject weapon in Assets.assets.weaponTemp) {
                    if (weapon.name == id) {
                        ItemO = Instantiate(Item);
                        ItemO.transform.SetParent(Slot.transform, false);
                        itemInfo = ItemO.GetComponent<ItemInfo>();
                        itemInfo.GetData(weapon.sprite, weapon.weaponName, weapon.description, weapon.name, weapon.cost);
                        iss.GetComponent<ItemSlotScript>().GetItem(weapon.weaponName, weapon.description, DescParent);
                        break;
                    }
                }
                break;
        }
    }
}
