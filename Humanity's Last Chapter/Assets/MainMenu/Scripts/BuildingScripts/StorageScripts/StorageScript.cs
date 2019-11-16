using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageScript : MonoBehaviour {
    
    public GameObject ItemSlot;
    private GameObject LoadManager;
    private GameObject[] itemSlots;
    public int slotsCounter;

    private void Start() {
        for(int i = 0; i < slotsCounter; i++) {
            Instantiate(ItemSlot, transform);
        }
        itemSlots = GameObject.FindGameObjectsWithTag("ItemSlot");
        LoadManager = GameObject.FindGameObjectWithTag("LoadManager");
        LoadManager.GetComponent<CreateItems>().FillSlots(WorldScript.world.storageArr, itemSlots);
    }
}
