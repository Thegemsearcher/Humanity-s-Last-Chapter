using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateItems : MonoBehaviour {

    public Text txtDescName, txtDescDesc; //Info rutornas text i StorageWindow
    public GameObject Item;
    private GameObject ItemO;

    private ItemSlotScript iss;
    private ItemInfo itemInfo;

    public void FillSlots(string[] inventory, GameObject[] itemSlots, GameObject DescParent) {

        for (int i = 0; i < inventory.Length; i++) {
            iss = itemSlots[i].GetComponent<ItemSlotScript>();

            if (!(inventory[i] == "")) {
                switch (inventory[i][0]) {
                    case 'h': //Healingitem
                        foreach (HealingItemObject healing in Assets.assets.healingTemp) {
                            if (healing.name == inventory[i]) {
                                ItemO = Instantiate(Item);
                                ItemO.transform.SetParent(itemSlots[i].transform, false);
                                itemInfo = ItemO.GetComponent<ItemInfo>();
                                itemInfo.GetData(healing.texture, healing.itemName, healing.description, healing.name, healing.cost, txtDescName, txtDescDesc);
                                iss.GetComponent<ItemSlotScript>().GetItem(healing.itemName, healing.description, DescParent);
                                break;
                            }
                        }
                        break;

                    case 'c':
                        foreach (CombatItemObject combat in Assets.assets.combatTemp) {
                            if (combat.name == inventory[i]) {
                                ItemO = Instantiate(Item);
                                ItemO.transform.SetParent(itemSlots[i].transform, false);
                                itemInfo = ItemO.GetComponent<ItemInfo>();
                                itemInfo.GetData(combat.icon, combat.itemName, combat.description, combat.name, combat.cost, txtDescName, txtDescDesc);
                                iss.GetComponent<ItemSlotScript>().GetItem(combat.itemName, combat.description, DescParent);
                                break;
                            }
                        }
                        break;

                    case 'w':
                        foreach (WeaponObject weapon in Assets.assets.weaponTemp) {
                            if (weapon.name == inventory[i]) {
                                ItemO = Instantiate(Item);
                                ItemO.transform.SetParent(itemSlots[i].transform, false);
                                itemInfo = ItemO.GetComponent<ItemInfo>();
                                itemInfo.GetData(weapon.sprite, weapon.weaponName, weapon.description, weapon.name, weapon.cost, txtDescName, txtDescDesc);
                                iss.GetComponent<ItemSlotScript>().GetItem(weapon.weaponName, weapon.description, DescParent);
                                break;
                            }
                        }
                        break;
                    default:
                        Debug.Log("Can't find Item! inventory[" + i + "]: " + inventory[i]);
                        break;
                }
            }
        }
    }
}
