using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothScript : MonoBehaviour {

    private ClothItemObject headGear, cloth;
    private string headId, clothId;
    private ClothType clothType;
    private CharacterScript characterScript;
    private Stats stats;

    public enum ClothType {
        HeadGear,
        Cloth
    }

    private void Start() {
        characterScript = GetComponent<CharacterScript>();
        stats = GetComponent<Stats>();

        headId = characterScript.headId;
        clothId = characterScript.clothId;

        if (headId != null) {
            FindItem(headId);
        }
        if (clothId != null) {
            FindItem(clothId);
        }
    }

    private void FindItem(string id) {
        foreach (ClothItemObject clothItem in Assets.assets.clothTemp) {
            if (clothItem.name == id) {
                switch (clothItem.clothType) {
                    case ClothType.HeadGear:
                        headGear = clothItem;
                        break;
                    case ClothType.Cloth:
                        cloth = clothItem;
                        break;
                }
                break;
            }
        }
    }

    private void ChangeCloth(ClothItemObject item) {
        switch (item.clothType) { //Kollar vilken typ som blir ersatt
            case ClothType.HeadGear:
                characterScript.headId = item.name; //Ändrar id så character har rätt? Onödigt?
                changeStats(headGear, -1); //Tar bort all boost som gamla itemet hade
                changeStats(item, 1); //Lägger till boost som den nya itemet har
                headGear = item; //Updaterar så att den har det nya itemet som old
                break;
            case ClothType.Cloth:
                characterScript.clothId = item.name;
                changeStats(cloth, -1);
                changeStats(cloth, 1);
                cloth = item;
                break;
        }
    }
    private void changeStats(ClothItemObject item, int modifier) {
        stats.maxHp += (item.maxHp * modifier);
        stats.str = (item.maxHp * modifier);
        stats.def = (item.maxHp * modifier);
        stats.Int = (item.maxHp * modifier);
        stats.dex = (item.maxHp * modifier);
        stats.cha = (item.maxHp * modifier);
        stats.ldr = (item.maxHp * modifier);
        stats.nrg = (item.maxHp * modifier);
        stats.snt = (item.maxHp * modifier);
    }

    private void EquipItem(ClothItemObject NewItem) {


    }

    private void OnRectTransformRemoved() {
        
    }
}
