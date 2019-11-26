using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacterBox : MonoBehaviour {

    public GameObject CharacterBox, InventoryParent;
    public GameObject BoxDad, ItemSlot;
    private GameObject Holder;
    private GameObject[] CharacterArr, itemSlots;

    private void Start() {

        //Skapar Character boxes
        CharacterArr = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject Character in CharacterArr) {
            Holder = Instantiate(CharacterBox);
            Holder.transform.SetParent(BoxDad.transform, false);
            Holder.GetComponent<CharacterBox>().GetData(Character, gameObject);
        }

        //Skapar Inventory
        for (int i = 0; i < WorldScript.world.storageSize; i++) {
            Holder = Instantiate(ItemSlot);
            Holder.transform.SetParent(InventoryParent.transform, false);
            Holder.GetComponent<ItemSlotScript>().slotNr = i;
            Holder.transform.tag = "InventorySlot";
        }
        itemSlots = GameObject.FindGameObjectsWithTag("InventorySlot");
        GetComponent<CreateItems>().FillSlots(WorldScript.world.storageArr, itemSlots, gameObject);
    }
    public void Return() {
        Destroy(gameObject);
    }
}


