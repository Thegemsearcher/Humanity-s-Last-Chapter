using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class PartyScript : MonoBehaviour {
    private GameObject characterO;
    public GameObject character, UIHealth;
    private int partyMember;                //Används för att bestämma vilken position karaktären spawnar på
    private UIHealthBoi uiHealth;
    private List<CharacterScript> characterScriptList;
    private List<Stats> statsList;
    //private WorldScript worldScript;
    private Transform transParent;

    public GameObject weapon;
    private GameObject weaponO;

    void Start() {
        InstantiateLists();
        transParent = GameObject.FindGameObjectWithTag("CharacterManager").transform;

        if (Assets.assets == null) {
            Assets.assets = new Assets();
            Assets.assets.GetAssets();
        }

        if (WorldScript.world == null) {
            WorldScript.world = new WorldScript();
            WorldScript.world.Reset();
            TestCharacters();
        } else {
            LoadWorld();
        }
    }

    public void SpawnCharacters() {
        characterScriptList = WorldScript.world.characterList;
<<<<<<< Updated upstream
        statsList = WorldScript.world.statsList;

        partyMember = 0;
        transParent = GameObject.FindGameObjectWithTag("CharacterManager").transform;
=======
        Debug.Log(characterScriptList);
        foreach (CharacterScript characterScript in characterScriptList) {
            Debug.Log(characterScript);
        }
        statsList = WorldScript.world.statsList;

        partyMember = 0;
        

        GameObject[] abilitySlots = GameObject.FindGameObjectsWithTag("AbilitySlot");

>>>>>>> Stashed changes
        foreach (CharacterScript characterScript in characterScriptList) {

            //if(characterScript.GetComponent<CharacterScript>().isEnlisted) {
            characterO = Instantiate(character);

            characterO.GetComponent<CharacterScript>().LoadPlayer(characterScript);
            characterO.GetComponent<Stats>().LoadPlayer(statsList[partyMember]);

            //Annan kod
            characterO.GetComponent<PersonalMovement>().relativePos = new Vector3(partyMember, partyMember);
            characterO.GetComponent<PersonalMovement>().AddRelativeWaypoint(transform.position);
            gameObject.GetComponent<CharacterMovement>().AddPc(characterO);
<<<<<<< Updated upstream

            Debug.Log("wpID: " + characterScript.rangedId);
=======
>>>>>>> Stashed changes
            SpawnWeapon(characterScript.rangedId, characterO.transform);

            CreateUI(characterScript, statsList[partyMember]);

<<<<<<< Updated upstream
            characterO.transform.SetParent(transParent, false);
=======


            //characterO.transform.SetParent(transParent, false);

            //if (characterO == null)
            //    Debug.Log("wat");
            //if (characterO.GetComponent<CharacterScript>() != null) {
            //    if (characterO.GetComponent<CharacterScript>().itemID != null) {
            //        if (characterO.GetComponent<CharacterScript>().itemID.Length > 0) {
            //            GameObject go = Instantiate(AbilityToInstantiate);
            //            go.transform.SetParent(abilitySlots[partyMember].transform, false);
            //            go.GetComponent<AbilityScript>().AttachedSlot = abilitySlots[partyMember];

            //            //Assets.assets.combatTemp
            //            string id = characterO.GetComponent<CharacterScript>().itemID[0];
            //            if (id.Contains("ci")) {
            //                foreach (CombatItemObject item in Assets.assets.combatTemp) {
            //                    if (id == item.name) {
            //                        //weapon har all info man vill ha
            //                    }
            //                }
            //            }
            //            if (id.Contains("hi")) {
            //                foreach (HealingItemObject item in Assets.assets.healingTemp) {
            //                    if (id == item.name) {
            //                        //weapon har all info man vill ha
            //                    }
            //                }
            //            }

            //            abilitySlots[partyMember].GetComponent<AbilitySlotScript>().AttachedAbility = go;
            //        }


            //        //CombatItemObject c = new CombatItemObject();
            //        //if (characterO.GetComponent<CharacterScript>().itemID[0].TryGetComponent<CombatItemObject>(out c))
            //        //{
            //        //    go.GetComponent<AbilityScript>().abilityType = characterO.GetComponent<CharacterScript>().itemID[0].GetComponent<CombatItemObject>().abilityType;
            //        //} else
            //        //{
            //        //    go.GetComponent<AbilityScript>().abilityType = characterO.GetComponent<CharacterScript>().itemID[0].GetComponent<HealingItemObject>().abilityType;
            //        //}

            //    }
            //}
>>>>>>> Stashed changes
            partyMember++;
            //}

        }
        characterScriptList.Clear(); //Rensar listan
    }

    private void LoadWorld() {
        SpawnCharacters();
    }

    private void TestCharacters() { //Spawnar tre gubbar ifall man inte kommer från huben
<<<<<<< Updated upstream
=======

        //Ability test
        //Debug.Log("skapa en turret ability");
        //GameObject[] abilitySlots = GameObject.FindGameObjectsWithTag("AbilitySlot");
        //GameObject go = Instantiate(AbilityToInstantiate);
        //go.transform.SetParent(abilitySlots[0].transform, false);
        //go.GetComponent<AbilityScript>().AttachedSlot = abilitySlots[0];
        //go.GetComponent<AbilityScript>().abilityType = AbilityScript.AbilityType.turret;
        //abilitySlots[0].GetComponent<AbilitySlotScript>().AttachedAbility = go;

        //GameObject go2 = Instantiate(AbilityToInstantiate);
        //go2.transform.SetParent(abilitySlots[1].transform, false);
        //go2.GetComponent<AbilityScript>().AttachedSlot = abilitySlots[1];
        //go2.GetComponent<AbilityScript>().abilityType = AbilityScript.AbilityType.grenade;
        //abilitySlots[1].GetComponent<AbilitySlotScript>().AttachedAbility = go2;

>>>>>>> Stashed changes
        for (int i = 0; i < 3; i++) {
            characterO = Instantiate(character);

            characterO.GetComponent<PersonalMovement>().relativePos = new Vector3(i, i);
            characterO.GetComponent<PersonalMovement>().AddRelativeWaypoint(transform.position);
            gameObject.GetComponent<CharacterMovement>().AddPc(characterO);

            SpawnWeapon("wp" + Random.Range(0, Assets.assets.weaponTemp.Length), characterO.transform);

            //CreateUI(characterO.GetComponent<CharacterScript>(), statsList[i]);

            CreateUI(characterO.GetComponent<CharacterScript>(), characterO.GetComponent<Stats>());
        }
    }

    public void CreateUI(CharacterScript characterScript, Stats characterStats) {
        characterO = Instantiate(UIHealth);
        characterO.GetComponent<CharacterScript>().LoadPlayer(characterScript);
        characterO.transform.SetParent(transParent, false);
        //uiHealth = characterO.GetComponent<UIHealthBoi>();
        //uiHealth.GetData(characterScript.strName, characterScript.id, characterStats.hp, characterStats.maxHp); //Måste gå att kunna göra snyggare!
        //characterO.transform.SetParent(GameObject.Find("forCharacter").transform, false);
    }

    public void SpawnWeapon(string wpId, Transform parent) {
        weaponO = Instantiate(weapon, gameObject.transform.position, Quaternion.identity);
        weaponO.transform.SetParent(parent, false);
        weaponO.transform.localScale = new Vector3(1, 1, 1);

        foreach (WeaponObject wp in Assets.assets.weaponTemp) {
            if (wp.name == wpId) {
                weaponO.GetComponent<WeaponAttack>().GetData(wp);
                break;
            }
        }
    }


    private void InstantiateLists() {
        characterScriptList = new List<CharacterScript>();
        statsList = new List<Stats>();
    }
}
