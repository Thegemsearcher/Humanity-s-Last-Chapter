using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackWindow : MonoBehaviour {

    private GameObject holder;
    private List<WeaponObject> startWeaponList;
    private List<ClothItemObject> startClothList;
    private List<ClothItemObject> startHeadList;

    private int rand;

    private void Start() {
        if (startWeaponList == null) {
            PrepareLists();
        }

        foreach (GameObject character in WorldScript.world.BarrackPepList) {
            holder = Instantiate(character);
            holder.GetComponent<HireCharacter>().WorldObject = character;
            holder.transform.SetParent(gameObject.transform, false);
            GetEquipment();
        }
    }

    public void BtnExit() {
        Destroy(gameObject);
    }

    private void PrepareLists() {
        startWeaponList = new List<WeaponObject>();
        startClothList = new List<ClothItemObject>();
        startHeadList = new List<ClothItemObject>();

        foreach (WeaponObject weapon in Assets.assets.weaponTemp) {
            if (weapon.wpLevel <= 0) {
                startWeaponList.Add(weapon);
            }
        }

        foreach (ClothItemObject cloth in Assets.assets.clothTemp) {
            if (cloth.clothCategory == ClothScript.ClothCategory.StartGear) {
                switch (cloth.clothType) {
                    case ClothScript.ClothType.Cloth:
                        startClothList.Add(cloth);
                        break;
                    case ClothScript.ClothType.HeadGear:
                        startHeadList.Add(cloth);
                        break;
                    default:
                        Debug.Log("Item '" + cloth.name + "' don't have a clothType");
                        break;
                }
            }
        }
    }

    private void GetEquipment() {
        if (startWeaponList.Count > 0) {
            rand = Random.Range(0, startWeaponList.Count);
            holder.GetComponent<CharacterScript>().rangedId = startWeaponList[rand].name;
        }

        if (startClothList.Count > 0) {
            rand = Random.Range(0, startClothList.Count);
            holder.GetComponent<PortraitScript>().ChangeCloth(startClothList[rand]);
        }

        if (startHeadList.Count > 0) {
            rand = Random.Range(0, startHeadList.Count);
            holder.GetComponent<PortraitScript>().ChangeCloth(startHeadList[rand]);
        }
    }
}
