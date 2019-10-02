using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireCharacter : MonoBehaviour {
    public GameObject HireBTN;
    private GameObject Manager;
    private int childCounter;
    private CharacterScript characterScript;
    private UIBoiScript boiScript;

    private void Start() {
        Manager = GameObject.FindGameObjectWithTag("CharacterManager");
    }

    public void btnHire() {
        characterScript = GetComponent<CharacterScript>();
        boiScript = GetComponent<UIBoiScript>();

        childCounter = Manager.transform.childCount;
        transform.SetParent(Manager.transform, false);
        characterScript.GetID();
        boiScript.GetPos(childCounter);
        GetComponent<UIBoiScript>().isOwned = true;
        HireBTN.SetActive(false);
    }

    public void ShowBTN() {
        HireBTN.SetActive(true);
    }

}
