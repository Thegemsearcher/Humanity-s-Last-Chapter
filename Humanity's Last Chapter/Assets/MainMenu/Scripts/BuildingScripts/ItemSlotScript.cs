using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlotScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public bool isActive, inside;
    public string itemName, itemDescrip;
    public Text txtName, txtDescrip;

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
            txtName.text = itemName;
            txtDescrip.text = itemDescrip;
        }
        inside = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        txtName.text = "-";
        txtDescrip.text = "";
        inside = false;
    }

    public void GetItem(string itemName, string itemDescrip) {
        this.itemName = itemName;
        this.itemDescrip = itemDescrip;
        isActive = true;
    }
}
