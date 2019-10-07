﻿using UnityEngine;

[System.Serializable]
public class InteractObject : ScriptableObject {

    public string title = "t.ex. Talk with this person";
    public string verb = "t.ex. talk";
    public string id = "qg0";
    public string description = "It must have been that guy that made the distress call!";
    public bool isComplete, isBonus;
    public GameObject interactObjective; //Object to interact with

}
