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

    private Object type;

    private List<string> inventory;

    public int ammoutOfItems;

    private void Start() {
        inventory = WorldScript.world.storageList;
        hio = Assets.assets.healingTemp;
        cio = Assets.assets.combatTemp;
        wpo = Assets.assets.weaponTemp;
        

        //GetComponent<StorageScript>().GetSlots();
        ItemSlots = GameObject.FindGameObjectsWithTag("ItemSlot");
        int i = 0;

        foreach (GameObject ItemSlot in ItemSlots) {
            iss = ItemSlot.GetComponent<ItemSlotScript>();
            if (i >= inventory.Count) {
                break;
            }
            
            switch (inventory[i][0]) {
                case 'h': //Healingitem
                    Debug.Log("Inventory: " + cio.Length);
                    for (int j = 0; j < hio.Length; j++) {
                        
                        if (hio[j].name == inventory[i]) {
                            ItemO = Instantiate(HeItem, ItemSlot.transform);
                            hi = ItemO.GetComponent<HealingItem>();
                            hi.GetData(hio[j]);
                            iss.GetItem(hi.itemName, hi.itemDescrip);
                            break;
                        }
                    }
                    break;

                case 'c':
                    for (int j = 0; j < cio.Length; j++) {
                        if (cio[j].name == inventory[i]) {
                            ItemO = Instantiate(CoItem, ItemSlot.transform);
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
                            ItemO = Instantiate(WpItem, ItemSlot.transform);
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



            //if (!(iss.isActive)) {

            //    switch (Random.Range(0, 2)) {
            //        case 0:

            //            ItemO = Instantiate(HeItem, ItemSlot.transform);
            //            hi = ItemO.GetComponent<HealingItem>();
            //            hi.GetData(hio[Random.Range(0, hio.Length)]);
            //            iss.GetItem(hi.itemName, hi.itemDescrip);
            //            break;
            //        case 1:
            //            ItemO = Instantiate(CoItem, ItemSlot.transform);
            //            ci = ItemO.GetComponent<CombatItem>();
            //            ci.GetData(cio[Random.Range(0, cio.Length)]);
            //            iss.GetItem(ci.itemName, ci.itemDescrip);
            //            break;
            //    }

            //    i++;
            //    if (i >= ammoutOfItems) {
            //        break;
            //    }
            //}
            i++;
        }
    }


}
