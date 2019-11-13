using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour {

    private GameObject[] shopSlots;
    private GameObject LoadManager;

    public GameObject ItemSlot;
    public int slotsCounter;

    private void Start() {
        for (int i = 0; i < slotsCounter; i++) {
            Instantiate(ItemSlot, transform);
        }
        shopSlots = GameObject.FindGameObjectsWithTag("StoreSlot");
        LoadManager = GameObject.FindGameObjectWithTag("LoadManager");
        LoadManager.GetComponent<CreateItems>().FillSlots(WorldScript.world.shopArr, shopSlots);
    }
}
