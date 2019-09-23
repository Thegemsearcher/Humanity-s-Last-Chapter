using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour {
    public string name = "";
    public int health, id;
    private string[] firstName = { "Fred", "Greg", "Meg", "Yrg" };
    private string[] lastName = { "McGreg", "SaintYeet", "SoonDed" };

    GameObject[] charactersO;

    void Start() {
        Debug.Log("Start");
        if (name == "") {
            name = NameGenerator();
            id = GetId();
        }
        
    }
    private string NameGenerator() {
        name = firstName[(int)Random.Range(0, firstName.Length)] + " " + lastName[(int)Random.Range(0, lastName.Length)];
        return name;
    }

    private int GetId() {
        int characterCounter = GameObject.Find("CharacterManager").transform.childCount;
        id = characterCounter-1;
        return id;
    }

    public void SavePlayer() {
        SaveSystem.SaveCharacter(this);
    }

    public void LoadPlayer(int id) {
        Debug.Log("LoadPlayer");
        CharacterData data = SaveSystem.LoadCharacter(id);
        Debug.Log("ID: " + id + " Data Name: " + data.name);

        this.name = data.name;
        this.health = data.health;
        this.id = data.id;
    }
}
