using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostRewardScript : MonoBehaviour {

    public GameObject ForLoot, ForInventory, itemSlot, item, descParent;
    public Text txtDescName, txtDescDesc;

    private GameObject slotHolder, itemHolder;

    private ItemSlotScript iss;
    private ItemInfo itemInfo;
    
    private string lootId, inventoryId;

    private void Start() {
        PrepareLootSlots();
        PrepareItemSlots();
    }

    private void PrepareLootSlots() {
        for (int i = 0; i < 64; i++) { //64 är hur många rutor vi vill ha
            slotHolder = Instantiate(itemSlot);
            slotHolder.transform.SetParent(ForLoot.transform, false);
            
            if (WorldScript.world.LootList.Count > 0) {
                lootId = MostValueItem();
                iss = slotHolder.GetComponent<ItemSlotScript>();

                if (!(lootId == "")) {
                    switch (lootId[0]) {
                        case 'h': //Healingitem
                            foreach (HealingItemObject healing in Assets.assets.healingTemp) {
                                if (healing.name == lootId) {
                                    itemHolder = Instantiate(item);
                                    itemHolder.transform.SetParent(slotHolder.transform, false);
                                    itemHolder.transform.localScale = new Vector3(50, 50, 1);
                                    itemInfo = itemHolder.GetComponent<ItemInfo>();
                                    itemInfo.GetData(healing.icon, healing.itemName, healing.description, healing.name, healing.cost, txtDescName, txtDescDesc);
                                    iss.GetComponent<ItemSlotScript>().GetItem(healing.itemName, healing.description, descParent);
                                    break;
                                }
                            }
                            break;

                        case 'c':
                            bool isCombat = false;
                            foreach (CombatItemObject combat in Assets.assets.combatTemp) {
                                if (combat.name == lootId) {
                                    itemHolder = Instantiate(item);
                                    itemHolder.transform.SetParent(slotHolder.transform, false);
                                    itemHolder.transform.localScale = new Vector3(50, 50, 1);
                                    itemInfo = itemHolder.GetComponent<ItemInfo>();
                                    itemInfo.GetData(combat.icon, combat.itemName, combat.description, combat.name, combat.cost, txtDescName, txtDescDesc);
                                    iss.GetComponent<ItemSlotScript>().GetItem(combat.itemName, combat.description, descParent);
                                    isCombat = true;
                                    break;
                                }
                            }
                            if (!isCombat) {
                                foreach (ClothItemObject cloth in Assets.assets.clothTemp) {
                                    if (cloth.name == lootId) {
                                        itemHolder = Instantiate(item);
                                        itemHolder.transform.SetParent(slotHolder.transform, false);
                                        itemInfo = itemHolder.GetComponent<ItemInfo>();
                                        itemInfo.GetData(cloth.icon, cloth.itemName, cloth.description, cloth.name, cloth.cost, txtDescName, txtDescDesc);
                                        iss.GetComponent<ItemSlotScript>().GetItem(cloth.itemName, cloth.description, descParent);
                                        break;
                                    }
                                }

                            }
                            break;


                        case 'w':
                            foreach (WeaponObject weapon in Assets.assets.weaponTemp) {
                                if (weapon.name == lootId) {
                                    itemHolder = Instantiate(item);
                                    itemHolder.transform.SetParent(slotHolder.transform, false);
                                    itemInfo = itemHolder.GetComponent<ItemInfo>();
                                    itemInfo.GetData(weapon.icon, weapon.weaponName, weapon.description, weapon.name, weapon.cost, txtDescName, txtDescDesc);
                                    iss.GetComponent<ItemSlotScript>().GetItem(weapon.weaponName, weapon.description, descParent);
                                    break;
                                }
                            }
                            break;
                        default:
                            Debug.Log("(PrepareLootSlot) Can't find Item! LootId: " + lootId);
                            break;
                    }
                    WorldScript.world.LootList.Remove(lootId);
                }
            }
        }
    }

    private void PrepareItemSlots() {
        for (int i = 0; i < 64; i++) {
            slotHolder = Instantiate(itemSlot);
            slotHolder.transform.SetParent(ForInventory.transform, false);

            if (WorldScript.world.storageArr[i] != null || WorldScript.world.storageArr[i] != "") {
                iss = slotHolder.GetComponent<ItemSlotScript>();
                inventoryId = WorldScript.world.storageArr[i];
                if (!(inventoryId == "")) {
                    switch (inventoryId[0]) {
                        case 'h': //Healingitem
                            foreach (HealingItemObject healing in Assets.assets.healingTemp) {
                                if (healing.name == inventoryId) {
                                    itemHolder = Instantiate(item);
                                    Debug.Log("Hmmmm");
                                    itemHolder.transform.SetParent(slotHolder.transform, false);
                                    Debug.Log("Did it get a parent?");
                                    itemHolder.transform.localScale = new Vector3(50, 50, 1);
                                    itemInfo = itemHolder.GetComponent<ItemInfo>();
                                    itemInfo.GetData(healing.icon, healing.itemName, healing.description, healing.name, healing.cost, txtDescName, txtDescDesc);
                                    iss.GetComponent<ItemSlotScript>().GetItem(healing.itemName, healing.description, descParent);
                                    break;
                                }
                            }
                            break;

                        case 'c':
                            bool isCombat = false;
                            foreach (CombatItemObject combat in Assets.assets.combatTemp) {
                                if (combat.name == inventoryId) {
                                    itemHolder = Instantiate(item);
                                    itemHolder.transform.SetParent(slotHolder.transform, false);
                                    itemHolder.transform.localScale = new Vector3(50, 50, 1);
                                    itemInfo = itemHolder.GetComponent<ItemInfo>();
                                    itemInfo.GetData(combat.icon, combat.itemName, combat.description, combat.name, combat.cost, txtDescName, txtDescDesc);
                                    iss.GetComponent<ItemSlotScript>().GetItem(combat.itemName, combat.description, descParent);
                                    isCombat = true;
                                    break;
                                }
                            }
                            if (!isCombat) {
                                foreach (ClothItemObject cloth in Assets.assets.clothTemp) {
                                    if (cloth.name == inventoryId) {
                                        itemHolder = Instantiate(item);
                                        itemHolder.transform.SetParent(slotHolder.transform, false);
                                        itemInfo = itemHolder.GetComponent<ItemInfo>();
                                        itemInfo.GetData(cloth.icon, cloth.itemName, cloth.description, cloth.name, cloth.cost, txtDescName, txtDescDesc);
                                        iss.GetComponent<ItemSlotScript>().GetItem(cloth.itemName, cloth.description, descParent);
                                        break;
                                    }
                                }

                            }
                            break;


                        case 'w':
                            foreach (WeaponObject weapon in Assets.assets.weaponTemp) {
                                if (weapon.name == inventoryId) {
                                    itemHolder = Instantiate(item);
                                    itemHolder.transform.SetParent(slotHolder.transform, false);
                                    itemInfo = itemHolder.GetComponent<ItemInfo>();
                                    itemInfo.GetData(weapon.icon, weapon.weaponName, weapon.description, weapon.name, weapon.cost, txtDescName, txtDescDesc);
                                    iss.GetComponent<ItemSlotScript>().GetItem(weapon.weaponName, weapon.description, descParent);
                                    break;
                                }
                            }
                            break;
                        default:
                            Debug.Log("(PrepareLootSlot) Can't find Item! LootId: " + lootId);
                            break;
                    }
                }
            }
        }
        

    }

    private string MostValueItem() { //Hittar den mest värde fulla item så att den ritas ut överst och är garanterad att den kommer med
        string bestItem = null;
        int bestValue = -1000;

        foreach (string loot in WorldScript.world.LootList) {
            switch (loot[0]) {
                case 'h': //Healingitem
                    foreach (HealingItemObject healing in Assets.assets.healingTemp) {
                        if (healing.name == loot) {
                            if (healing.cost >= bestValue) {
                                bestValue = healing.cost;
                                bestItem = healing.name;
                            }
                            break;
                        }
                    }
                    break;

                case 'c':
                    bool isCombat = false;
                    foreach (CombatItemObject combat in Assets.assets.combatTemp) {
                        if (combat.name == loot) {
                            if (combat.cost >= bestValue) {
                                bestValue = combat.cost;
                                bestItem = combat.name;
                            }
                            isCombat = true;
                            break;
                        }
                    }
                    if (!isCombat) {
                        foreach (ClothItemObject cloth in Assets.assets.clothTemp) {
                            if (cloth.name == loot) {
                                if (cloth.cost >= bestValue) {
                                    bestValue = cloth.cost;
                                    bestItem = cloth.name;
                                }
                                break;
                            }
                        }

                    }
                    break;


                case 'w':
                    foreach (WeaponObject weapon in Assets.assets.weaponTemp) {
                        if (weapon.name == loot) {
                            if (weapon.cost >= bestValue) {
                                bestValue = weapon.cost;
                                bestItem = weapon.name;
                            }
                            break;
                        }
                    }
                    break;
                default:
                    Debug.Log("(MostValueItem) Can't find Item! Loot: " + loot);
                    break;
            }
        }
        return bestItem;
    }

    private void FindItem(string id) {

    }
}
