using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlotScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public bool isActive, inside;
    public string itemName, itemDescrip;
    public int slotNr;
    public Text txtName, txtDescrip;
    private GameObject Parent;

    void Start() {
        txtName = GameObject.FindGameObjectWithTag("TextItemName").GetComponent<Text>();
        txtDescrip = GameObject.FindGameObjectWithTag("TextItemDescrip").GetComponent<Text>();
    }

    public void Equip() {
        if(isActive) {
            isActive = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if(isActive) {
            Parent.GetComponent<UpdateInfo>().UpdateText(itemName, itemDescrip);
        }
        inside = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (isActive) {
            Parent.GetComponent<UpdateInfo>().UpdateText("-", "");
        }
        inside = false;
    }

    public void GetItem(string itemName, string itemDescrip, GameObject Parent) {
        this.itemName = itemName;
        this.itemDescrip = itemDescrip;
        this.Parent = Parent;
        isActive = true;
    }
}
