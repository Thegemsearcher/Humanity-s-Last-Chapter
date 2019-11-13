using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItems : MonoBehaviour {

    private HealingItemObject[] hio;
    private CombatItemObject[] cio;
    private WeaponObject[] wpo;
    public GameObject HeItem, CoItem, WpItem;
    private GameObject ItemO;
    private GameObject[] ItemSlots;

    private ItemSlotScript iss;
    private HealingItem hi;
    private CombatItem ci;
    private WeaponDisplay wp;

    private string[] inventory;

    public int ammoutOfItems;

    private void Start() {
        inventory = new string[WorldScript.world.storageSize];
        inventory = WorldScript.world.storageArr;
        hio = Assets.assets.healingTemp;
        cio = Assets.assets.combatTemp;
        wpo = Assets.assets.weaponTemp;

        //GetComponent<StorageScript>().GetSlots();
        ItemSlots = GameObject.FindGameObjectsWithTag("ItemSlot");
        //int i = 0;

        for (int i = 0; i < WorldScript.world.storageSize; i++) {
            iss = ItemSlots[i].GetComponent<ItemSlotScript>();

            if (!(inventory[i] == "")) {
                switch (inventory[i][0]) {
                    case 'h': //Healingitem
                        for (int j = 0; j < hio.Length; j++) {
                            if (hio[j].name == inventory[i]) {
                                ItemO = Instantiate(HeItem, ItemSlots[i].transform);
                                hi = ItemO.GetComponent<HealingItem>();
                                hi.GetData(hio[j], ItemSlots, i);
                                iss.GetItem(hi.itemName, hi.itemDescrip);
                                break;
                            }
                        }
                        break;

                    case 'c':
                        for (int j = 0; j < cio.Length; j++) {
                            if (cio[j].name == inventory[i]) {
                                ItemO = Instantiate(CoItem, ItemSlots[i].transform);
                                ci = ItemO.GetComponent<CombatItem>();
                                ci.GetData(cio[j]);
                                iss.GetItem(ci.itemName, ci.itemDescrip);
                                break;
                            }
                        }
                        break;

                    case 'w':
                        for (int j = 0; j < wpo.Length; j++) {
                            if (wpo[j].name == inventory[i]) {
                                ItemO = Instantiate(WpItem, ItemSlots[i].transform);
                                wp = ItemO.GetComponent<WeaponDisplay>();
                                wp.GetData(wpo[j]);
                                iss.GetItem(wp.weaponName, wp.description);
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
