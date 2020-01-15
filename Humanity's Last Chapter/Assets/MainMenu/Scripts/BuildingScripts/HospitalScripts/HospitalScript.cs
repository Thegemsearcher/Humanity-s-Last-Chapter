using System.Collections.Generic;
using UnityEngine;

public class HospitalScript : MonoBehaviour {

    public GameObject UIHospital, UISlots;
    private GameObject UIHolder, forHospitalParent, forHealingParent;
    private GameObject[] Characters;
    public List<GameObject> SlotList;
    private Stats statsScript;
    private CharacterScript characterScript;
    public int healingSlots;
    private bool showCharacter;

    void Start() {
        SlotList = new List<GameObject>();
        UICharacters();
        HealingSlots();
    }

    private void UICharacters() {
        Characters = GameObject.FindGameObjectsWithTag("Character");
        forHospitalParent = GameObject.Find("forHospital");
        showCharacter = false;


        foreach (GameObject character in Characters) {  //Går igenom alla karaktärer
            statsScript = character.GetComponent<Stats>();

            if (statsScript.hp <= statsScript.maxHp) { //För att bara få de skadade karaktärena
                showCharacter = true;
            } else {
                foreach (QuirkObject quirk in statsScript.quirkList) {  //Går in i alla quirks för att se om karaktären är skadad
                    if (quirk.quirkType == QuirkScript.QuirkType.woundQuirk) {
                        showCharacter = true;
                        break;
                    }
                }
            }
            if (showCharacter) {    //Om karaktären har mindre hp än max eller har en woundQuirk kommer den att ritas us i hospital
                characterScript = character.GetComponent<CharacterScript>();

                UIHolder = Instantiate(UIHospital);
                UIHolder.transform.SetParent(forHospitalParent.transform, false);
                UIHolder.GetComponent<CharacterScript>().LoadPlayer(characterScript);
                UIHolder.GetComponent<Stats>().LoadPlayer(statsScript);
                UIHolder.GetComponent<UIHospitalBoi>().Hospital = gameObject;
                statsScript.maxHp++;
            }

            
        }

    }

    private void HealingSlots() {
        forHealingParent = GameObject.Find("forHealingSlots");
        healingSlots = WorldScript.world.hospitalLevel + 1;
    }

    public void HealCharacter(CharacterScript characterScript, Stats stats) {
        characterScript.isEnlisted = false;
        characterScript.inHospital = true;
        UIHolder = Instantiate(UIHospital);
        UIHolder.transform.SetParent(forHealingParent.transform, false);
        //UIHolder.GetComponent<CharacterScript>().LoadPlayer(characterScript);
        //UIHolder.GetComponent<Stats>().LoadPlayer(stats);
        UIHolder.GetComponent<UIHospitalBoi>().Hospital = gameObject;
    }

    public void RemoveCharacter(CharacterScript characterScript, Stats stats) {
        characterScript.inHospital = false;
        UIHolder = Instantiate(UIHospital);
        UIHolder.transform.SetParent(forHospitalParent.transform, false);
        UIHolder.GetComponent<CharacterScript>().LoadPlayer(characterScript);
        UIHolder.GetComponent<Stats>().LoadPlayer(stats);
        UIHolder.GetComponent<UIHospitalBoi>().Hospital = gameObject;
    }

    public List<GameObject> GetSlot() { //Vet inte varför detta behövs...
        return SlotList;
    }

    public void Exit() {
        Destroy(gameObject);
    }
}
