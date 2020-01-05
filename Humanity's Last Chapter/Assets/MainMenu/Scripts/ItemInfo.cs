using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler { //Markus - Används för att enkelt få data från objectet oberoend från vilken sorts object det är

    private Text itemName, itemDesc;
    public string strName, strDesc, id;
    public int cost;
    public Sprite texture;

    public void GetData(Sprite texture, string strName, string strDesc, string id, int cost, Text itemName, Text itemDesc) {
        this.texture = texture;
        this.strName = strName;
        this.strDesc = strDesc;
        this.id = id;
        this.cost = cost;
        this.itemName = itemName;
        this.itemDesc = itemDesc;
        GetComponent<SpriteRenderer>().sprite = texture;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (itemName != null && itemDesc != null) {
            itemName.text = strName;
            itemDesc.text = strDesc;
        } else {
            Debug.Log("Can't find textBox!");
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (itemName != null && itemDesc != null) {
            itemName.text = "";
            itemDesc.text = "";
        } else {
            Debug.Log("Can't find textBox!");
        }
    }
}
