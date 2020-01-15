﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireCharacter : MonoBehaviour {
    public GameObject UICharacter, WorldObject;
    public Text txtCost;
    private GameObject Manager, holder;
    public int cost;
    private CharacterScript characterScript;
    private Stats stats;

    private void Start() {
        Manager = GameObject.FindGameObjectWithTag("CharacterManager");
        stats = GetComponent<Stats>();

        cost = stats.GetCost();
        txtCost.text = "Cost: " + cost;
    }

    public void btnHire() {
        characterScript = GetComponent<CharacterScript>();

        if (cost <= WorldScript.world.gold) {
            WorldScript.world.BarrackPepList.Remove(WorldObject);
            WorldScript.world.gold -= cost;
            holder = Instantiate(UICharacter);
            holder.transform.SetParent(Manager.transform, false);
            holder.GetComponent<CharacterScript>().LoadPlayer(characterScript);
            holder.GetComponent<Stats>().LoadPlayer(stats);
            holder.GetComponent<CharacterScript>().GetId();
            
            Destroy(gameObject);
        } else {
            Debug.Log("Not enough gold!");
        }


    }
}
