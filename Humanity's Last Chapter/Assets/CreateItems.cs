using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItems : MonoBehaviour {

    public HealingItemObject[] hio;
    public CombatItemObject[] cio;
    public GameObject HeItem, CoItem;
    private GameObject ItemO;
    private GameObject[] ItemSlots;

    private ItemSlotScript iss;
    private HealingItem hi;
    private CombatItem ci;

    public int ammoutOfItems;

    private void Start() {
        GetComponent<StorageScript>().GetSlots();
        ItemSlots = GameObject.FindGameObjectsWithTag("ItemSlot");
        int i = 0;
        

        foreach (GameObject ItemSlot in ItemSlots) {
            iss = ItemSlot.GetComponent<ItemSlotScript>();
            if (!(iss.isActive)) {

                switch(Random.Range(0,2)) {
                    case 0:
                        
                        ItemO = Instantiate(HeItem, ItemSlot.transform);
                        hi = ItemO.GetComponent<HealingItem>();
                        hi.GetData(hio[Random.Range(0, hio.Length)]);
                        iss.GetItem(hi.itemName, hi.itemDescrip);
                        break;
                    case 1:
                        ItemO = Instantiate(CoItem, ItemSlot.transform);
                        ci = ItemO.GetComponent<CombatItem>();
                        ci.GetData(cio[Random.Range(0, cio.Length)]);
                        iss.GetItem(ci.itemName, ci.itemDescrip);
                        break;
                }
                
                i++;
                if(i >= ammoutOfItems) {
                    break;
                }
            }
        }
    }


}
