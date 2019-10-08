using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageScript : MonoBehaviour {
    
    public GameObject ItemSlot;
    public int slotsCounter;

    public void GetSlots() {
        for(int i = 0; i < slotsCounter; i++) {
            Instantiate(ItemSlot, transform);
        }
        
    }

}
