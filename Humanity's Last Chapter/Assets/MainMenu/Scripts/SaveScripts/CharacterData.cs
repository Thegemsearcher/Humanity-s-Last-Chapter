﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData {

    public int hp, maxHp, str, def, Int, dex, cha, ldr, nrg, snt, exp;
    public string strName, wpId, headId, clothId, id;
    public string[] itemID;
    public bool shit;
    public List<string> quirkID;


    public CharacterData(CharacterScript character, Stats stats) {
        quirkID = new List<string>();
        
        id = character.id;
        headId = character.headId;
        clothId = character.clothId;
        strName = character.strName;
        wpId = character.rangedId;
        itemID = character.inventory;
        shit = stats.shit;
        hp = stats.hp;
        maxHp = stats.maxHp;
        quirkID = stats.quirkIDList;

        str = stats.str;
        def = stats.def;
        Int = stats.Int;
        dex = stats.dex;
        cha = stats.cha;
        ldr = stats.ldr;
        snt = stats.snt;
        exp = stats.exp;


    }
}
