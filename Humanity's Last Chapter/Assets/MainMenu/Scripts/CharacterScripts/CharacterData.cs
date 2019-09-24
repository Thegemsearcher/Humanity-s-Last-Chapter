using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData{
    
    public int id, health;
    public string name;

    public CharacterData(CharacterScript character) {
        id = character.id;
        health = character.health;
        name = character.name;
    }
}
