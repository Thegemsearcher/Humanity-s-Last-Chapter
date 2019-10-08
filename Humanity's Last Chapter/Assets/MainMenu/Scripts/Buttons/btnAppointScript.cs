﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnAppointScript : MonoBehaviour { //Borde heta RoleManager

    public GameObject btnAppointO, btnRemoveO, characterWindow;
    private GameObject partyView, forCommand;
    private GameObject[] characters;
    public Text txtRole, txtName, txtSkill;
    private CharacterScript characterScript;
    string role, name, skill;
    public int roleId;
    private int characterID;
    private bool isAppointed;

    private void Start() {
        characterWindow = GameObject.FindGameObjectWithTag("EnlistList");
        partyView = GameObject.FindGameObjectWithTag("PartyView");
        forCommand = GameObject.Find("forCommand");


        switch(roleId) {
            case 0:
                role = "Commander";
                break;
            case 1:
                role = "Scavanger";
                break;
            case 2:
                role = "Researcher";
                break;
            case 3:
                role = "Navigator";
                break;
            case 4:
                role = "Explorer";
                break;
            default:
                role = "Guard";
                break;
        }
        name = "-";
        skill = "-";

        txtRole.text = role;
        txtName.text = name;
        txtSkill.text = skill;

        isAppointed = false;
        ShowBtn();
    }

    public void btnAppoint() {
        forCommand.GetComponent<EnlistList>().IsEnlisted(roleId);
    }

    public void btnRemove() {
        partyView.GetComponent<partySelectorScript>().RemoveCharacter(roleId);
        txtName.text = name;
        txtSkill.text = skill;
        isAppointed = false;
        ShowBtn();
    }

    public void ShowBtn() {
        if(isAppointed) {
            btnAppointO.SetActive(false);
            btnRemoveO.SetActive(true);
        }
        else {
            btnAppointO.SetActive(true);
            btnRemoveO.SetActive(false);
        }
    }

    public void GetEnlist(string enlistName, int skill, int characterID) {
        txtName.text = enlistName;
        txtSkill.text = skill.ToString();
        this.characterID = characterID;
        partyView.GetComponent<partySelectorScript>().AppointCharacter(roleId, characterID);
        isAppointed = true;
        ShowBtn();
    }
}
