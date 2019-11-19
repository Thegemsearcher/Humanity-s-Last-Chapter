using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBox : MonoBehaviour {

    private CharacterScript characterScript;
    public Text txtName;
    public Sprite cloth;

    public GameObject[] itemSlots;
    public GameObject clothSlot;
    public GameObject rangedSlot;

    private GameObject ItemO;

    public GameObject Item;

    private GameObject Character, DescParent;

    private string rangedId, clothId;
    private string[] inventoryArr;
    private ItemInfo itemInfo;

    public void GetData(GameObject Character, GameObject DescParent) {
        this.Character = Character;
        this.DescParent = DescParent;
        characterScript = Character.GetComponent<CharacterScript>();
        txtName.text = characterScript.strName;

        for (int i = 0; i < itemSlots.Length; i++) {
            if(characterScript.itemID[i] != "") {
                //Skapar ett item i itemSlot[i]
            }
        }

        if (characterScript.rangedId != "") { //Spawnar vapen i weaponSlot
            ItemO = Instantiate(Item);
            ItemO.transform.SetParent(rangedSlot.transform, false);

            rangedId = characterScript.rangedId;
            foreach (WeaponObject weapon in Assets.assets.weaponTemp) {
                if(weapon.name == rangedId) {
                    itemInfo = ItemO.GetComponent<ItemInfo>();
                    itemInfo.GetData(weapon.sprite, weapon.weaponName, weapon.description, weapon.name, weapon.cost);
                    rangedSlot.GetComponent<ItemSlotScript>().GetItem(weapon.weaponName, weapon.description, DescParent);
                }
            }
        }

        //För att ändra kläder!
    }

    private void OnDestroy() {
        rangedId = rangedSlot.GetComponentInChildren<ItemInfo>().id;
        Debug.Log("rangedID: " + rangedId);
        characterScript.rangedId = rangedId;
        //Updaterar characterScript;
    }
}
