using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData {

    public int id, health, hp, maxHp;
    public string name, wpId;
    public string[] itemID;

    public CharacterData(CharacterScript character, stats Stats) {
        id = character.id;
        health = character.health;
        name = character.name;
        wpId = character.wpId;
        itemID = character.itemID;
        this.hp = Stats.hp;
        this.maxHp = Stats.maxHp;

    }
}
