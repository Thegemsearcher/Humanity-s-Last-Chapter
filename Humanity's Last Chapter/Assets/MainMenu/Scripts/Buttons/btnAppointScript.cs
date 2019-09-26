using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnAppointScript : MonoBehaviour { //Borde heta RoleManager

    public GameObject btnAppointO, btnRemoveO;
    private GameObject partyView;
    private GameObject[] characters;
    public Text txtRole, txtName, txtSkill;
    private CharacterWindow windowScript;
    string role, name, skill;
    public int roleId;
    private int characterID;
    private bool isAppointed;

    private void Start() {
        partyView = GameObject.FindGameObjectWithTag("PartyView");
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
        characterID = partyView.GetComponent<partySelectorScript>().AppointCharacter(roleId);
        
        if (characterID >= 0) {
            characters = GameObject.FindGameObjectsWithTag("CharacterWindow");
            foreach(GameObject window in characters) {
                windowScript = window.GetComponent<CharacterWindow>();
                if(windowScript.ID == characterID) {
                    txtName.text = windowScript.name;
                    txtSkill.text = 0.ToString(); //0 ska sen ersättas med karaktärens skill i den valda rollen, vet inte hur vi gör det än
                    break;
                }
            }
            isAppointed = true;
            ShowBtn();
        }
        else {
            Debug.Log("No character selected!");
        }
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
}
