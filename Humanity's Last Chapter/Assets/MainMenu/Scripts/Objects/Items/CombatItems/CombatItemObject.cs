using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatItemObject : ScriptableObject {

    public Sprite texture;
    public string itemName = "t.ex. Strong Cookie";
    public string description = "t.ex. This cookie will give you strong power!!!";
    public int cost;
}
