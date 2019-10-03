using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireCharacter : MonoBehaviour {
    public GameObject HireBTN;
    public Text txtHire;
    private GameObject Manager, World;
    public int cost;
    private int childCounter;
    private CharacterScript characterScript;
    private UIBoiScript boiScript;
    private stats statsScript;

    private void Start() {
        Manager = GameObject.FindGameObjectWithTag("CharacterManager");
        World = GameObject.Find("WorldManager");
        statsScript = GetComponent<stats>();

        cost = statsScript.GetCost();
        txtHire.text = "Hire! (" + cost + ")";
    }

    public void btnHire() {
        characterScript = GetComponent<CharacterScript>();
        boiScript = GetComponent<UIBoiScript>();
        
        if(cost <= World.GetComponent<WorldScript>().gold) {
            World.GetComponent<WorldScript>().gold -= cost;
            childCounter = Manager.transform.childCount;
            transform.SetParent(Manager.transform, false);
            characterScript.GetID();
            boiScript.GetPos(childCounter);
            GetComponent<UIBoiScript>().isOwned = true;
            HireBTN.SetActive(false);
        }
        else {
            Debug.Log("Not enough gold!");
        }

        
    }

    public void ShowBTN() {
        HireBTN.SetActive(true);
    }

}
