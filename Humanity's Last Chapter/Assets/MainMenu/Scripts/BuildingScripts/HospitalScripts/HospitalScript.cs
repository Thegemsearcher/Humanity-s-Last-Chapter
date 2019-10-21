using System.Collections.Generic;
using UnityEngine;

public class HospitalScript : MonoBehaviour {

    public GameObject UIHospital, UISlots;
    private GameObject UIHolder, parent;
    private GameObject[] Characters;
    public List<GameObject> SlotList;
    private stats statsScript;
    private CharacterScript characterScript;
    private int buildingSlots;

    void Start() {
        SlotList = new List<GameObject>();
        UICharacters();
        HealingSlots();
    }

    private void UICharacters() {
        Characters = GameObject.FindGameObjectsWithTag("Character");
        parent = GameObject.Find("forHospital");


        foreach (GameObject character in Characters) {
            statsScript = character.GetComponent<stats>();

            if (statsScript.hp < statsScript.maxHp) { //För att bara få de skadade karaktärena
                characterScript = character.GetComponent<CharacterScript>();

                UIHolder = Instantiate(UIHospital);
                UIHolder.transform.SetParent(parent.transform, false);
                UIHolder.GetComponent<UIHealthBoi>().GetData(characterScript.name, characterScript.id, statsScript.hp, statsScript.maxHp);
            }
        }

    }

    private void HealingSlots() {
        parent = GameObject.Find("forHealingSlots");
        buildingSlots = (GetComponentInParent<buildingScript>().level * 2) + 1;
        for (int i = 0; i < buildingSlots; i++) {
            UIHolder = Instantiate(UISlots);
            UIHolder.transform.SetParent(parent.transform, false);
            SlotList.Add(UIHolder);
        }
    }

    public List<GameObject> GetSlot() { //Vet inte varför detta behövs...
        return SlotList;
    }
}
