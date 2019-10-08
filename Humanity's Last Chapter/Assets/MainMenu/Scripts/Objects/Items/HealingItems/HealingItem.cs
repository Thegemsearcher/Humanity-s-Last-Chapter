using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealingItem : MonoBehaviour {

    public bool held;
    public string id;
    public string itemDescrip, itemName;
    private int healPower;
    
    public void GetData(HealingItemObject hio) {
        GetComponent<Image>().sprite = hio.texture;
        itemName = hio.itemName;
        id = hio.name;
        healPower = hio.healPower;
        itemDescrip = hio.description;

    }
}
