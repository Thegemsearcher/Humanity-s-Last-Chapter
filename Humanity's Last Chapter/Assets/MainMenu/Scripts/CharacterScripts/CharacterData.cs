using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData {

    public int id, hp, maxHp;
    public string strName, wpId;
    public string[] itemID;

    public CharacterData(CharacterScript character, Stats stats) {
        id = character.id;
        strName = character.strName;
        wpId = character.rangedId;
        itemID = character.itemID;

        hp = stats.hp;
        maxHp = stats.maxHp;

    }
}
