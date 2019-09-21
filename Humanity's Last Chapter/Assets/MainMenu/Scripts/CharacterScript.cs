using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    public string name;
    public int health, id;
    private string[] firstName = { "Fred", "Greg", "Meg", "Yrg" };
    private string[] lastName = { "McGreg", "SaintYeet", "SoonDed" };

    GameObject[] charactersO;

    void Start() {
        name = NameGenerator();
        //id = GetId();
    }
    private string NameGenerator() {
        Debug.Log("Can it get name?");
        name = firstName[(int)Random.Range(0, firstName.Length)] + " " + lastName[(int)Random.Range(0, lastName.Length)];
        return name;
    }

    private int GetId() {
        Debug.Log("Can it get id?");
        id = 0;
        int oldId = id;
        bool testingId = true;
        Debug.Log("Test: 1");
        if (!(GameObject.FindGameObjectsWithTag("Character") == null)) {
            charactersO = GameObject.FindGameObjectsWithTag("Character"); //Här den krachar
        }
        Debug.Log("Test: 2");
        while (testingId) {
            Debug.Log("Test: 3");
            if (!(charactersO == null)) {
                foreach (GameObject go in charactersO) {
                    Debug.Log("ID: " + id + " Go id: " + go.GetComponent<CharacterScript>().id);
                    if (id == go.GetComponent<CharacterScript>().id) { //Kollar om det finns något objekt med samma id
                        id++;
                    }
                }
            }
            Debug.Log("Test: 4");
            if (oldId == id) {
                testingId = false; //Ingen ändring har skett så id:et är ledigt
            }
        }
        Debug.Log("Test: 5");
        return id;
    }

    public void SavePlayer() {
        SaveSystem.SaveCharacter(this);
    }

    public void LoadPlayer(int id) {
        CharacterData data = SaveSystem.LoadCharacter(id);

        name = data.name;
        health = data.health;
        id = data.id;
    }
}
